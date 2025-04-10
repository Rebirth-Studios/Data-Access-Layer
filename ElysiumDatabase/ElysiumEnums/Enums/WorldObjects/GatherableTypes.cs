using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.WorldObjects
{
	public enum GatherableTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Mining")]
		[RebirthDescription("Ore Vein")]
		Mining = 1,
		[RebirthName("Gemstone Cluster")]
		[RebirthDescription("Gemstone Cluster")]
		GemstoneCluster = 2,
		[RebirthName("Stonecutting")]
		[RebirthDescription("Tree")]
		Stonecutting = 3,
		[RebirthName("Herbalism")]
		[RebirthDescription("Herbs")]
		Herbalism = 4,
		[RebirthName("Woodcutting")]
		[RebirthDescription("Tree")]
		Woodcutting = 5,
		[RebirthName("Skinning")]
		[RebirthDescription("Herbs")]
		Skinning = 6,
		MAX_VALUE = 7,
	}
}