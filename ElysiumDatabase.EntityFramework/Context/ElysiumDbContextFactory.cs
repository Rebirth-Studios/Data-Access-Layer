using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RebirthStudios.DataAccessLayer.EntityFramework
{
    public static class ElysiumDbContextFactory
    {
        public static IDbContextFactory<ElysiumDbContext> Create(string connectionString, int poolSize = 64)
        {
            if (poolSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(poolSize));
            }

            var options = new DbContextOptionsBuilder<ElysiumDbContext>()
                .UseSqlServer(connectionString, sqlServer =>
                    sqlServer.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(2),
                        errorNumbersToAdd: null))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            return new PooledDbContextFactory<ElysiumDbContext>(options, poolSize);
        }
    }
}
