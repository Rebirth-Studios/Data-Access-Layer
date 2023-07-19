using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum AdventuringQuestTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Hunting")]
		[RebirthDescription("Hunting animals for food and/or materials")]
		Hunting = 1,
		[RebirthName("Scouting")]
		[RebirthDescription("Find locations of rumored rifts or enemy encampments")]
		Scouting = 2,
		[RebirthName("Slayer")]
		[RebirthDescription("Killing humanoids like Goblins")]
		Slayer = 3,
		[RebirthName("Bug Hunt")]
		[RebirthDescription("Strange Monster Rumors")]
		BugHunt = 4,
		[RebirthName("Seal Rift")]
		[RebirthDescription("Defeat the anchor monster in a rift (boss) to cause it to seal")]
		SealRift = 5,
		[RebirthName("Special Event")]
		[RebirthDescription("Special Events")]
		SpecialEvent = 6,
		MAX_VALUE = 7,
	}
}