using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum LootTableTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Gathering")]
		[RebirthDescription("Gathering / Harvesting")]
		Gathering = 1,
		[RebirthName("Combat")]
		Combat = 2,
		[RebirthName("Treasure")]
		Treasure = 3,
		MAX_VALUE = 4,
	}
}