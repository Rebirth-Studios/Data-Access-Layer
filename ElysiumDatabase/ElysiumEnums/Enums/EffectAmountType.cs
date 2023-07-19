namespace RebirthStudios.Enums
{
	public enum EffectAmountType : byte
	{
		[RebirthName("Append")]
		[RebirthDescription("Adds or Subtracts")]
		Append = 0,
		[RebirthName("Set")]
		[RebirthDescription("Sets")]
		Set = 1,
		[RebirthName("PercentageAdditive")]
		[RebirthDescription("PercentageAdditive")]
		PercentageAdditive = 2,
		[RebirthName("PercentageMultiplicative")]
		[RebirthDescription("PercentageMultiplicative")]
		PercentageMultiplicative = 3,
		MAX_VALUE = 4,
	}
}