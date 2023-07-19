using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum GatheringQuestTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Gathering")]
		[RebirthDescription("Gather resources the village needs")]
		Mining = 1,
		[RebirthName("Gathering")]
		[RebirthDescription("Gather resources the village needs")]
		Lumbering = 2,
		[RebirthName("Herbalism")]
		[RebirthDescription("Gather resources the village needs")]
		Herbalism = 3,
		[RebirthName("Skinning")]
		[RebirthDescription("Gather resources the village needs")]
		Skinning = 4,
		[RebirthName("Smelting")]
		[RebirthDescription("Gather resources the village needs")]
		Smelting = 5,
		[RebirthName("Upgrades")]
		[RebirthDescription("Upgrade the village")]
		Upgrades = 6,
		MAX_VALUE = 7,
	}
}