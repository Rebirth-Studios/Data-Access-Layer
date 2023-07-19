using System;
using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.Elements
{
	public enum ElementalTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Fire")]
		Fire = 1,
		[RebirthName("Water")]
		Water = 2,
		[RebirthName("Earth")]
		Earth = 3,
		[RebirthName("Light")]
		Light = 4,
		[RebirthName("Dark")]
		Dark = 5,
		[RebirthName("Poison")]
		Poison = 6,
		[RebirthName("Physical")]
		Physical = 7,
		MAX_VALUE = 8,
	}
	public enum EffectType
	{
		Attribute = 0,
		Resistance = 1,
		BaseStat = 2,
		StatMultiplier = 3,
		CalculatedStat = 4,
		DamageType = 5,
		DamageNegation = 6,
	}
	public enum EffectValueType
	{
		Add = 1,
		Percentage = 2,
	}
}