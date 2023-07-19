using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum ContainerTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Chest")]
		[RebirthDescription("Chest")]
		Chest = 1,
		[RebirthName("Bank")]
		[RebirthDescription("Bank")]
		Bank = 2,
		[RebirthName("Crafting Stations")]
		[RebirthDescription("Crafting Stations")]
		CraftingStation = 3,
		MAX_VALUE = 4,
	}
}