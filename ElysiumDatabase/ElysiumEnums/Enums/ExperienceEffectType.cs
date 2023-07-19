using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum ExperienceEffectType : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Skill")]
		[RebirthDescription("Used for rewarding Skill Experience from a consumable")]
		Skill = 1,
		[RebirthName("Ability")]
		[RebirthDescription("Used for rewarding Ability Experience from a consumable")]
		Ability = 2,
		[RebirthName("Player")]
		[RebirthDescription("Used for rewarding Player Experience from a consumable")]
		Player = 3,
		MAX_VALUE = 4,
	}
}