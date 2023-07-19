using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.WorldObjects
{
	public enum GatherableTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Ore Vein")]
		[RebirthDescription("Ore Vein")]
		OreVein = 1,
		[RebirthName("Gemstone Cluster")]
		[RebirthDescription("Gemstone Cluster")]
		GemstoneCluster = 2,
		[RebirthName("Stone")]
		[RebirthDescription("Tree")]
		Stone = 3,
		[RebirthName("Herb")]
		[RebirthDescription("Herbs")]
		Herb = 4,
		[RebirthName("Tree")]
		[RebirthDescription("Tree")]
		Tree = 5,
		[RebirthName("Herb")]
		[RebirthDescription("Herbs")]
		Bamboo = 6,
		MAX_VALUE = 7,
	}
}