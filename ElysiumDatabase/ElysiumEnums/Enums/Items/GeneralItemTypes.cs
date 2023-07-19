namespace RebirthStudios.Enums.Items
{
	public enum GeneralItemTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Drop")]
		[RebirthDescription("Drop")]
		Drop = 1,
		[RebirthName("Key")]
		Key = 2,
		[RebirthName("Misc")]
		[RebirthDescription("Drop")]
		Misc = 3,
		[RebirthName("Clothing")]
		Clothing = 4,
		[RebirthName("Tools")]
		[RebirthDescription("Non-equippable Tools. Ex. Enchanting Rod, Screw Driver")]
		Tools = 5,
		[RebirthName("Thread")]
		[RebirthDescription("Threads")]
		Thread = 6,
		[RebirthName("Egg")]
		[RebirthDescription("Eggs")]
		Egg = 7,
		[RebirthName("Rope")]
		[RebirthDescription("Rope")]
		Rope = 8,
		[RebirthName("Spice")]
		[RebirthDescription("Spices")]
		Spice = 9,
		[RebirthName("Core")]
		[RebirthDescription("Used in a number of recipes to produce magical items")]
		Core = 10,
		[RebirthName("Fish")]
		[RebirthDescription("Fish")]
		Fish = 11,
		[RebirthName("Dye")]
		[RebirthDescription("Dyes")]
		Dye = 12,
		MAX_VALUE = 13,
	}
}