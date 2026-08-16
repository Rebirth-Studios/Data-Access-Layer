using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RebirthStudios.DataAccessLayer.EntityFramework;
using RebirthStudios.DataAccessLayer.EntityFramework.Entities;
using RebirthStudios.Logging;

namespace RebirthStudios.DataAccessLayer.EntityFramework
{
    public sealed class PlayerAccountStore : IDisposable
    {
        private readonly IDbContextFactory<ElysiumDbContext> _contextFactory;
        private readonly ILogger _logger;
        private readonly ConcurrentQueue<PendingUpdate> _pendingUpdates = new ConcurrentQueue<PendingUpdate>();
        private readonly SemaphoreSlim _flushGate = new SemaphoreSlim(1, 1);

        public PlayerAccountStore(
            IDbContextFactory<ElysiumDbContext> contextFactory,
            ILogger logger)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public int PendingWriteCount => _pendingUpdates.Count;

        public async Task<PlayerAccount> FindBySteamIdAsync(
            string steamId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(steamId))
            {
                throw new ArgumentException("Steam ID is required.", nameof(steamId));
            }

            await using var context = await _contextFactory
                .CreateDbContextAsync(cancellationToken)
                .ConfigureAwait(false);

            return await context.PlayerAccounts
                .AsNoTracking()
                .SingleOrDefaultAsync(account => account.SteamId == steamId, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<PlayerAccount> FindBySteamNameAsync(
            string steamName,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(steamName))
            {
                throw new ArgumentException("Steam name is required.", nameof(steamName));
            }

            await using var context = await _contextFactory
                .CreateDbContextAsync(cancellationToken)
                .ConfigureAwait(false);

            return await context.PlayerAccounts
                .AsNoTracking()
                .OrderBy(account => account.PlayerAccountId)
                .FirstOrDefaultAsync(account => account.SteamName == steamName, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<PlayerAccount>> GetPageAsync(
            int skip,
            int take,
            CancellationToken cancellationToken = default)
        {
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip));
            }

            if (take is < 1 or > 500)
            {
                throw new ArgumentOutOfRangeException(nameof(take), "Page size must be between 1 and 500.");
            }

            await using var context = await _contextFactory
                .CreateDbContextAsync(cancellationToken)
                .ConfigureAwait(false);

            return await context.PlayerAccounts
                .AsNoTracking()
                .OrderBy(account => account.PlayerAccountId)
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<PlayerAccount> CreateAsync(
            string steamId,
            string steamName,
            string lastIpAddressOnLogin,
            DateTime lastLoginTime,
            bool? isAdmin = false,
            CancellationToken cancellationToken = default)
        {
            ValidateRequiredValue(steamId, 64, nameof(steamId));
            ValidateRequiredValue(steamName, 255, nameof(steamName));
            ValidateRequiredValue(lastIpAddressOnLogin, 255, nameof(lastIpAddressOnLogin));

            var account = new PlayerAccount
            {
                SteamId = steamId,
                SteamName = steamName,
                LastIpAddressOnLogin = lastIpAddressOnLogin,
                LastLoginTime = lastLoginTime,
                IsAdmin = isAdmin
            };

            await using var context = await _contextFactory
                .CreateDbContextAsync(cancellationToken)
                .ConfigureAwait(false);

            context.PlayerAccounts.Add(account);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return account;
        }

        public void QueueLoginUpdate(
            int playerAccountId,
            string lastIpAddressOnLogin,
            DateTime lastLoginTime)
        {
            ValidatePlayerAccountId(playerAccountId);
            ValidateRequiredValue(lastIpAddressOnLogin, 255, nameof(lastIpAddressOnLogin));

            _pendingUpdates.Enqueue(PendingUpdate.Login(
                playerAccountId,
                lastIpAddressOnLogin,
                lastLoginTime));
        }

        public void QueueAdminUpdate(int playerAccountId, bool? isAdmin)
        {
            ValidatePlayerAccountId(playerAccountId);
            _pendingUpdates.Enqueue(PendingUpdate.Admin(playerAccountId, isAdmin));
        }

        public async Task<int> FlushPendingWritesAsync(CancellationToken cancellationToken = default)
        {
            await _flushGate.WaitAsync(cancellationToken).ConfigureAwait(false);

            var updates = new Dictionary<int, CoalescedUpdate>();
            try
            {
                while (_pendingUpdates.TryDequeue(out var pending))
                {
                    if (!updates.TryGetValue(pending.PlayerAccountId, out var update))
                    {
                        update = new CoalescedUpdate(pending.PlayerAccountId);
                        updates.Add(pending.PlayerAccountId, update);
                    }

                    update.Apply(pending);
                }

                if (updates.Count == 0)
                {
                    return 0;
                }

                await using var context = await _contextFactory
                    .CreateDbContextAsync(cancellationToken)
                    .ConfigureAwait(false);

                var ids = updates.Keys.ToArray();
                var accounts = await context.PlayerAccounts
                    .AsTracking()
                    .Where(account => ids.Contains(account.PlayerAccountId))
                    .ToDictionaryAsync(account => account.PlayerAccountId, cancellationToken)
                    .ConfigureAwait(false);

                foreach (var update in updates.Values)
                {
                    if (!accounts.TryGetValue(update.PlayerAccountId, out var account))
                    {
                        _logger.LogWarning(
                            $"Skipped deferred player-account update because account {update.PlayerAccountId} does not exist.");
                        continue;
                    }

                    update.ApplyTo(account);
                }

                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return accounts.Count;
            }
            catch (Exception exception)
            {
                foreach (var update in updates.Values)
                {
                    _pendingUpdates.Enqueue(update.ToPendingUpdate());
                }

                _logger.LogException(exception);
                throw;
            }
            finally
            {
                _flushGate.Release();
            }
        }

        public void Dispose()
        {
            _flushGate.Dispose();
        }

        private static void ValidatePlayerAccountId(int playerAccountId)
        {
            if (playerAccountId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(playerAccountId));
            }
        }

        private static void ValidateRequiredValue(string value, int maxLength, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value is required.", parameterName);
            }

            if (value.Length > maxLength)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"Value cannot exceed {maxLength} characters.");
            }
        }

        private sealed class PendingUpdate
        {
            private PendingUpdate(int playerAccountId)
            {
                PlayerAccountId = playerAccountId;
            }

            public int PlayerAccountId { get; }
            public bool HasLoginUpdate { get; private set; }
            public string LastIpAddressOnLogin { get; private set; }
            public DateTime LastLoginTime { get; private set; }
            public bool HasAdminUpdate { get; private set; }
            public bool? IsAdmin { get; private set; }

            public static PendingUpdate Login(int playerAccountId, string ipAddress, DateTime loginTime)
            {
                return new PendingUpdate(playerAccountId)
                {
                    HasLoginUpdate = true,
                    LastIpAddressOnLogin = ipAddress,
                    LastLoginTime = loginTime
                };
            }

            public static PendingUpdate Admin(int playerAccountId, bool? isAdmin)
            {
                return new PendingUpdate(playerAccountId)
                {
                    HasAdminUpdate = true,
                    IsAdmin = isAdmin
                };
            }

            public static PendingUpdate Combined(
                int playerAccountId,
                bool hasLoginUpdate,
                string ipAddress,
                DateTime loginTime,
                bool hasAdminUpdate,
                bool? isAdmin)
            {
                return new PendingUpdate(playerAccountId)
                {
                    HasLoginUpdate = hasLoginUpdate,
                    LastIpAddressOnLogin = ipAddress,
                    LastLoginTime = loginTime,
                    HasAdminUpdate = hasAdminUpdate,
                    IsAdmin = isAdmin
                };
            }
        }

        private sealed class CoalescedUpdate
        {
            public CoalescedUpdate(int playerAccountId)
            {
                PlayerAccountId = playerAccountId;
            }

            public int PlayerAccountId { get; }
            private bool HasLoginUpdate { get; set; }
            private string LastIpAddressOnLogin { get; set; }
            private DateTime LastLoginTime { get; set; }
            private bool HasAdminUpdate { get; set; }
            private bool? IsAdmin { get; set; }

            public void Apply(PendingUpdate update)
            {
                if (update.HasLoginUpdate)
                {
                    HasLoginUpdate = true;
                    LastIpAddressOnLogin = update.LastIpAddressOnLogin;
                    LastLoginTime = update.LastLoginTime;
                }

                if (update.HasAdminUpdate)
                {
                    HasAdminUpdate = true;
                    IsAdmin = update.IsAdmin;
                }
            }

            public void ApplyTo(PlayerAccount account)
            {
                if (HasLoginUpdate)
                {
                    account.LastIpAddressOnLogin = LastIpAddressOnLogin;
                    account.LastLoginTime = LastLoginTime;
                }

                if (HasAdminUpdate)
                {
                    account.IsAdmin = IsAdmin;
                }
            }

            public PendingUpdate ToPendingUpdate()
            {
                return PendingUpdate.Combined(
                    PlayerAccountId,
                    HasLoginUpdate,
                    LastIpAddressOnLogin,
                    LastLoginTime,
                    HasAdminUpdate,
                    IsAdmin);
            }
        }
    }
}
