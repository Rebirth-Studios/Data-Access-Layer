namespace RebirthStudios.Enums
{
	public enum EffectAmountType : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Append")]
		[RebirthDescription("Adds or Subtracts")]
		Append = 1,
		[RebirthName("Set")]
		[RebirthDescription("Sets")]
		Set = 2,
		[RebirthName("PercentageAdditive")]
		[RebirthDescription("PercentageAdditive")]
		PercentageAdditive = 3,
		[RebirthName("PercentageMultiplicative")]
		[RebirthDescription("PercentageMultiplicative")]
		PercentageMultiplicative = 4,
		MAX_VALUE = 5,
	}
}