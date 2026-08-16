using System;

namespace RebirthStudios.DataAccessLayer.EntityFramework.Entities
{
    public sealed class PlayerAccount
    {
        public int PlayerAccountId { get; set; }

        public string SteamId { get; set; } = string.Empty;

        public string SteamName { get; set; } = string.Empty;

        public string LastIpAddressOnLogin { get; set; } = string.Empty;

        public DateTime LastLoginTime { get; set; }

        public bool? IsAdmin { get; set; }
    }
}
