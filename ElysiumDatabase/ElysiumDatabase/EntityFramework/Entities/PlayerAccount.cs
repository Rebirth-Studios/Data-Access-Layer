using System;

namespace RebirthStudios.DataAccessLayer.EntityFramework.Entities
{
    public sealed class PlayerAccount
    {
        public int PlayerAccountId { get; set; }

        public string SteamId { get; set; }

        public string SteamName { get; set; }

        public string LastIpAddressOnLogin { get; set; }

        public DateTime LastLoginTime { get; set; }

        public bool? IsAdmin { get; set; }
    }
}
