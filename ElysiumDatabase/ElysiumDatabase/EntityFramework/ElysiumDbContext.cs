using Microsoft.EntityFrameworkCore;
using RebirthStudios.DataAccessLayer.Configuration;
using RebirthStudios.DataAccessLayer.EntityFramework.Entities;

namespace RebirthStudios.DataAccessLayer.EntityFramework
{
    public sealed class ElysiumDbContext : DbContext
    {
        public ElysiumDbContext(DbContextOptions<ElysiumDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlayerAccount> PlayerAccounts => Set<PlayerAccount>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var playerAccount = modelBuilder.Entity<PlayerAccount>();

            playerAccount.ToTable("playersAccounts", DatabaseSchemas.Identity);
            playerAccount.HasKey(account => account.PlayerAccountId)
                .HasName("PK_playerAccounts");

            playerAccount.Property(account => account.PlayerAccountId)
                .HasColumnName("playerAccountId")
                .ValueGeneratedOnAdd();
            playerAccount.Property(account => account.SteamId)
                .HasColumnName("steamId")
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired();
            playerAccount.Property(account => account.SteamName)
                .HasColumnName("steamName")
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();
            playerAccount.Property(account => account.LastIpAddressOnLogin)
                .HasColumnName("lastIpAddressOnLogin")
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();
            playerAccount.Property(account => account.LastLoginTime)
                .HasColumnName("lastLoginTime")
                .HasColumnType("datetime")
                .IsRequired();
            playerAccount.Property(account => account.IsAdmin)
                .HasColumnName("isAdmin");

            playerAccount.HasIndex(account => account.SteamId)
                .IsUnique();
        }
    }
}
