namespace RebirthStudios.Enums.Items
{
	public enum BagTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Potion")]
		Potion = 1,
		[RebirthName("Scroll")]
		[RebirthDescription("Teaches a Recipe upon use")]
		Scroll = 2,
		[RebirthName("Book")]
		[RebirthDescription("Teaches an ability, skill or even a new attribute")]
		Book = 3,
		[RebirthName("Enhancement")]
		[RebirthDescription("Permanently enhances players attributes, abilities, experience, or items")]
		Enhancement = 4,
		[RebirthName("Rune")]
		[RebirthDescription("Runes")]
		Rune = 5,
		[RebirthName("Medical")]
		[RebirthDescription("Bandages")]
		Medical = 6,
		[RebirthName("Explosive")]
		[RebirthDescription("Explosives")]
		Explosive = 7,
		[RebirthName("Fishing")]
		[RebirthDescription("Increases fishing skill")]
		Fishing = 8,
		[RebirthName("Food")]
		Food = 9,
		[RebirthName("Lootable Container")]
		[RebirthDescription("Purse or Chest that gives coins or items when double clicked")]
		LootableContainer = 10,
		MAX_VALUE = 11,
	}
}