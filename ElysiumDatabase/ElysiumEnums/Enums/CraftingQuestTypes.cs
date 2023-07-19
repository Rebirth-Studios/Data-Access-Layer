using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum CraftingQuestTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Blacksmithing")]
		[RebirthDescription("Blacksmithing")]
		Blacksmithing = 1,
		[RebirthName("Alchemy")]
		[RebirthDescription("Alchemy")]
		Alchemy = 2,
		[RebirthName("Leatherworking")]
		[RebirthDescription("Leatherworking")]
		Leatherworking = 3,
		[RebirthName("Tailoring")]
		[RebirthDescription("Tailoring")]
		Tailoring = 4,
		MAX_VALUE = 5,
	}
}