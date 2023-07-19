using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum QuestCategoryTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Adventuring")]
		[RebirthDescription("Hunting animals for food and/or materials")]
		Adventuring = 1,
		[RebirthName("Gathering")]
		[RebirthDescription("Gather resources the village needs")]
		Gathering = 2,
		[RebirthName("Crafting")]
		[RebirthDescription("Craft items needed by the village")]
		Crafting = 3,
		MAX_VALUE = 4,
	}
}