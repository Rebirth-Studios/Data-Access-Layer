using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.Abilities
{
	public enum AbilityTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Mobs")]
		[RebirthDescription("Attacks for mobs")]
		Mobs = 1,
		[RebirthName("Body Enhancement")]
		[RebirthDescription("Zero cast time")]
		BodyEnhancement = 2,
		[RebirthName("Resilence")]
		[RebirthDescription("Upfront cast time before activating")]
		Resilence = 3,
		[RebirthName("Healing")]
		[RebirthDescription("Ability is active while channelling")]
		Healing = 4,
		[RebirthName("Curse")]
		[RebirthDescription("Curses")]
		Curse = 5,
		MAX_VALUE = 6,
	}
}