using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum QuestObjectiveTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Kill")]
		[RebirthDescription("Kill")]
		Kill = 1,
		[RebirthName("Collect")]
		[RebirthDescription("Pick up/ Loot the item and it is taken on quest completion")]
		Collect = 2,
		[RebirthName("Gather")]
		[RebirthDescription("Gathering of Gatherables (Ore Veins, Trees, Herbs, etc)")]
		Gather = 3,
		[RebirthName("Explore")]
		[RebirthDescription("Exploring certain zones or regions")]
		Explore = 4,
		[RebirthName("Craft")]
		[RebirthDescription("Requires the item to be crafted by the player, and is not taken on quest completion")]
		Craft = 5,
		[RebirthName("Close Rift")]
		[RebirthDescription("Successfully seal a rift and close it")]
		CloseRift = 6,
		[RebirthName("Level")]
		[RebirthDescription("Character Rank and Level")]
		Level = 7,
		[RebirthName("Skill")]
		[RebirthDescription("Supplies list of skills, then select skill and enter skill rank and level")]
		Skill = 8,
		[RebirthName("Ability")]
		[RebirthDescription("Supplies list of abilities, then select skill and enter skill rank and level")]
		Ability = 9,
		[RebirthName("Recipe")]
		[RebirthDescription("Requires a recipe to be unlocked")]
		Recipe = 10,
		MAX_VALUE = 11,
	}
}
