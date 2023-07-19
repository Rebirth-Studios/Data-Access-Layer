using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum AwardEffectType : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Achievement")]
		[RebirthDescription("Award Achievement")]
		Achievement = 1,
		[RebirthName("Title")]
		[RebirthDescription("Award Title")]
		Title = 2,
		MAX_VALUE = 3,
	}
}