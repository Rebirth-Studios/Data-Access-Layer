using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.WorldObjects
{
	[RebirthChildEnumAttribute(typeof(GatherableTypes))]
	public enum GatherableClassificationTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
		[RebirthName("Ore Vein")]
		[RebirthDescription("Ore Vein")]
		[RebirthSubType(1)]
		OreVein = 1,
		[RebirthName("Rich Ore Vein")]
		[RebirthDescription("Rich Ore Vein")]
		[RebirthSubType(1)]
		OreVeinRich = 2,
		[RebirthName("Deep Ore Vein")]
		[RebirthDescription("Deep Ore Vein")]
		[RebirthSubType(1)]
		OreVeinDeep = 3,
		[RebirthName("Gemstone Cluster")]
		[RebirthDescription("Gemstone Cluster")]
		[RebirthSubType(2)]
		GemstoneCluster = 4,
		[RebirthName("Pure Gemstone Cluster")]
		[RebirthDescription("Pure Gemstone Cluster")]
		[RebirthSubType(2)]
		GemstoneClusterPure = 5,
		[RebirthName("Ancient Gemstone Cluster")]
		[RebirthDescription("Ancient Gemstone Cluster")]
		[RebirthSubType(2)]
		GemstoneClusterAncient = 6,
		[RebirthName("Stone")]
		[RebirthDescription("Stone")]
		[RebirthSubType(3)]
		Stone = 7,
		[RebirthName("Mushrooms")]
		[RebirthDescription("Mushrooms")]
		[RebirthSubType(4)]
		MushroomNode = 8,
		[RebirthName("Flower")]
		[RebirthDescription("Herbs")]
		[RebirthSubType(4)]
		Flower = 9,
		[RebirthName("Root")]
		[RebirthDescription("Herbs")]
		[RebirthSubType(4)]
		Root = 10,
		[RebirthName("Young Tree")]
		[RebirthDescription("Young Tree")]
		[RebirthSubType(5)]
		TreeYoung = 11,
		[RebirthName("Mature Tree")]
		[RebirthDescription("Mature Tree")]
		[RebirthSubType(5)]
		TreeMature = 12,
		[RebirthName("Dead Tree")]
		[RebirthDescription("Dead Tree")]
		[RebirthSubType(5)]
		TreeDead = 13,
	}
}