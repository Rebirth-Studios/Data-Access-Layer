using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum AwardEffectType : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Award Achievement")]
		[RebirthDescription("Award Achievement")]
		AwardAchievement = 1,
		[RebirthName("Award Title")]
		[RebirthDescription("Award Title")]
		AwardTitle = 2,
		MAX_VALUE = 3,
	}
}