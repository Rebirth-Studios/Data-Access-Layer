using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.Skills
{
	public enum SkillTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Base")]
		[RebirthDescription("Base")]
		Base = 1,
		[RebirthName("Advanced")]
		[RebirthDescription("Advanced")]
		Advanced = 2,
		MAX_VALUE = 3,
	}
}