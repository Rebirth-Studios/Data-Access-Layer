using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum RequirementTypes : byte
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
		[RebirthName("Achievement")]
		[RebirthDescription("Requires an achievment to be unlocked")]
		Achievement = 11,
		[RebirthName("Title")]
		[RebirthDescription("Requires a title to be unlocked")]
		Title = 12,
		[RebirthName("Milestone")]
		[RebirthDescription("Requires a milestone to be unlocked")]
		Milestone = 13,
		[RebirthName("Quest")]
		[RebirthDescription("Requires Quest to be completed")]
		Quest = 14,
		[RebirthName("Item")]
		[RebirthDescription("Item Requirements")]
		Item = 15,
		[RebirthName("Structure")]
		[RebirthDescription("Structure")]
		Structure = 16,
		MAX_VALUE = 17,
	}
}