namespace RebirthStudios.Enums.Items
{
	public enum ItemTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Ammunition")]
		[RebirthDescription("None")]
		Ammunition = 1,
		[RebirthName("Bag")]
		[RebirthDescription("None")]
		Bag = 2,
		[RebirthName("Consumable")]
		[RebirthDescription("None")]
		Consumable = 3,
		[RebirthName("Currency")]
		[RebirthDescription("None")]
		Currency = 4,
		[RebirthName("Equipment")]
		[RebirthDescription("None")]
		Equipment = 5,
		[RebirthName("General Item")]
		[RebirthDescription("None")]
		GeneralItem = 6,
		[RebirthName("Material")]
		[RebirthDescription("None")]
		Material = 7,
		MAX_VALUE = 8,
	}
}