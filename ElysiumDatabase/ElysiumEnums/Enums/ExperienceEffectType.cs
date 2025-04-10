using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum ExperienceEffectType : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Experience Skill")]
		[RebirthDescription("Used for rewarding Skill Experience from a consumable")]
		ExperienceSkill = 1,
		[RebirthName("Experience Ability")]
		[RebirthDescription("Used for rewarding Ability Experience from a consumable")]
		ExperienceAbility = 2,
		[RebirthName("Experience Player")]
		[RebirthDescription("Used for rewarding Player Experience from a consumable")]
		ExperiencePlayer = 3,
		MAX_VALUE = 4,
	}
}