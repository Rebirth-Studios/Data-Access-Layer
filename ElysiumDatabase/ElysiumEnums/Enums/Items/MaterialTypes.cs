namespace RebirthStudios.Enums.Items
{
	public enum MaterialTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Ore")]
		[RebirthDescription("Mined from nodes")]
		Ore = 1,
		[RebirthName("Ingot")]
		[RebirthDescription("Crafted from ore")]
		Ingot = 2,
		[RebirthName("Hide")]
		[RebirthDescription("Harvested animal parts such as meat and organs used in Cooking and Alchemy")]
		Hide = 3,
		[RebirthName("Leather")]
		[RebirthDescription("Harvested from animals with skinning and unprocessed. Hides, Feathers, Scales, etc")]
		Leather = 4,
		[RebirthName("Herb")]
		[RebirthDescription("Processed animal skins includes traditional leather and scaled leather.")]
		Herb = 5,
		[RebirthName("Stone")]
		[RebirthDescription("Harvested with Herbalism and used in Alchemy and Cooking. Examples are leaves, berries, mushrooms, n")]
		Stone = 6,
		[RebirthName("Gem")]
		[RebirthDescription("Gem")]
		Gem = 7,
		[RebirthName("Jewel")]
		[RebirthDescription("Jewel")]
		Jewel = 8,
		[RebirthName("Log")]
		[RebirthDescription("Unprocessed wood harvested with Lumbering.")]
		Log = 9,
		[RebirthName("Wood")]
		[RebirthDescription("Processed wood")]
		Wood = 10,
		[RebirthName("Powder")]
		[RebirthDescription("Materials used in enchanting / runecrafting such as runes, enchanting dust, essences, and cores.")]
		Powder = 11,
		[RebirthName("Essense")]
		[RebirthDescription("Materials used in enchanting / runecrafting such as runes, enchanting dust, essences, and cores.")]
		Essence = 12,
		[RebirthName("Crystal")]
		[RebirthDescription("Crystal")]
		Crystal = 13,
		[RebirthName("Cloth")]
		[RebirthDescription("Procesed plant fibers used in tailoring")]
		Cloth = 14,
		[RebirthName("Meat")]
		[RebirthDescription("Meat")]
		Meat = 15,
		[RebirthName("Bug")]
		[RebirthDescription("Found while gathering plants")]
		Bug = 16,
		[RebirthName("Bone")]
		[RebirthDescription("Bone")]
		Bone = 17,
		[RebirthName("Feather")]
		[RebirthDescription("Feather")]
		Feather = 18,
		[RebirthName("Organ")]
		[RebirthDescription("Organ")]
		Organ = 19,
		[RebirthName("Fruit")]
		[RebirthDescription("Fruit")]
		Fruit = 20,
		[RebirthName("Scale")]
		[RebirthDescription("Scales")]
		Scale = 21,
		MAX_VALUE = 22,
	}
}