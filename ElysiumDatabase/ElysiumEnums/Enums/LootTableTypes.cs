using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum LootTableTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Gatherable")]
		[RebirthDescription("Gathering / Harvesting")]
		Gatherable = 1,
		[RebirthName("Entity")]
		Entity = 2,
		[RebirthName("Container")]
		Container = 3,
		MAX_VALUE = 4,
	}
}