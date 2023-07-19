using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.Abilities
{
	public enum CostValueTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("No Cost")]
		None = 0,
		[RebirthName("Per Second")]
		[RebirthDescription("Per Second")]
		PerSecond = 1,
		[RebirthName("Initial")]
		[RebirthDescription("Initial")]
		Initial = 2,
		MAX_VALUE = 3,
	}
}
