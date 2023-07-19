using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum UseEffectType : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Stat")]
		[RebirthDescription("Stat Effect, includes regular experience")]
		Stat = 1,
		[RebirthName("Unlock")]
		[RebirthDescription("Unlock ability, skill, recipe, etc")]
		Unlock = 2,
		[RebirthName("Award")]
		[RebirthDescription("Title, Achievement, etc")]
		Award = 3,
		[RebirthName("Experience")]
		[RebirthDescription("Skill and Ability experience")]
		Experience = 4,
		MAX_VALUE = 5,
	}
}