using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
    public enum TargetRestrictionTypes : byte
    {
        [RebirthName("None")]
        None = 0,
        [RebirthName("SelfOnly")]
        Common = 1,
        [RebirthName("FriendlyOnly")]
        Uncommon = 2,
        [RebirthName("SelfOrFriendly")]
        Rare = 3,
        [RebirthName("Party")]
        Epic = 4,
        [RebirthName("Enemy")]
        Unique = 5,
    }
}