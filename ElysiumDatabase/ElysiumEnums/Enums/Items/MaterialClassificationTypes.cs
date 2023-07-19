using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.Items
{
	[RebirthChildEnumAttribute(typeof(MaterialTypes))]
	public enum MaterialClassificationTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
		[RebirthName("Ore")]
		[RebirthDescription("Ore")]
		[RebirthSubType(1)]
		Ore = 1,
		[RebirthName("Leather")]
		[RebirthDescription("Leather")]
		[RebirthSubType(4)]
		Leather = 2,
		[RebirthName("Stone")]
		[RebirthDescription("Stone")]
		[RebirthSubType(6)]
		Stone = 3,
		[RebirthName("Log")]
		[RebirthDescription("Log")]
		[RebirthSubType(9)]
		Log = 4,
		[RebirthName("Wood")]
		[RebirthDescription("Wood")]
		[RebirthSubType(10)]
		Wood = 5,
		[RebirthName("Powder")]
		[RebirthDescription("Powder")]
		[RebirthSubType(11)]
		Powder = 6,
		[RebirthName("Cloth")]
		[RebirthDescription("Cloth")]
		[RebirthSubType(14)]
		Cloth = 7,
		[RebirthName("Meat")]
		[RebirthDescription("Meat")]
		[RebirthSubType(15)]
		Meat = 8,
		[RebirthName("Bug")]
		[RebirthDescription("Bug")]
		[RebirthSubType(16)]
		Bug = 9,
		[RebirthName("Bone")]
		[RebirthDescription("Bone")]
		[RebirthSubType(17)]
		Bone = 10,
		[RebirthName("Feather")]
		[RebirthDescription("Feather")]
		[RebirthSubType(18)]
		Feather = 11,
		[RebirthName("Organ")]
		[RebirthDescription("Organ")]
		[RebirthSubType(19)]
		Organ = 12,
		[RebirthName("Scale")]
		[RebirthDescription("Scale")]
		[RebirthSubType(21)]
		Scale = 13,
		[RebirthName("Fruit")]
		[RebirthDescription("Fruit")]
		[RebirthSubType(20)]
		Fruit = 14,
		[RebirthName("Nut")]
		[RebirthDescription("Nut")]
		[RebirthSubType(20)]
		Nut = 15,
		[RebirthName("Root")]
		[RebirthDescription("Roots from a plant")]
		[RebirthSubType(5)]
		Root = 16,
		[RebirthName("Leaf")]
		[RebirthDescription("Leaf from a plant")]
		[RebirthSubType(5)]
		Leaf = 17,
		[RebirthName("Mushroom")]
		[RebirthDescription("A fungus based herb, usually found in dark or shaded areas")]
		[RebirthSubType(5)]
		Mushroom = 18,
		[RebirthName("Flower")]
		[RebirthDescription("Flower")]
		[RebirthSubType(5)]
		Flower = 19,
		[RebirthName("Sap")]
		[RebirthDescription("Gathered from Lumbering")]
		[RebirthSubType(5)]
		Sap = 20,
		[RebirthName("Alloy")]
		[RebirthDescription("An ingot consisting of more than 1 type of metal")]
		[RebirthSubType(2)]
		Alloy = 21,
		[RebirthName("Gem")]
		[RebirthDescription("None")]
		[RebirthSubType(7)]
		Gem = 22,
		[RebirthName("Jewel")]
		[RebirthDescription("None")]
		[RebirthSubType(8)]
		Jewel = 23,
		[RebirthName("Lesser Essence")]
		[RebirthDescription("None")]
		[RebirthSubType(12)]
		LesserEssence = 24,
		[RebirthName("Greater Essence")]
		[RebirthDescription("None")]
		[RebirthSubType(12)]
		GreaterEssence = 25,
		[RebirthName("Crystal")]
		[RebirthDescription("When processed, produces large amounts of enchanting dust")]
		[RebirthSubType(13)]
		Crystal = 26,
		[RebirthName("Crystal Fragment")]
		[RebirthDescription("When processed, produces small amounts of enchanting dust")]
		[RebirthSubType(13)]
		CrystalFragment = 27,
		[RebirthName("Scaled Hide")]
		[RebirthDescription("Scaled Hides")]
		[RebirthSubType(3)]
		ScaledHide = 28,
	}
}