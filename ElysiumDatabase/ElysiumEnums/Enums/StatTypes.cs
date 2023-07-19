using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.Stats
{
	public enum StatTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Primary Attribute")]
		[RebirthDescription("Base Attributes that can be increased with attribute points, and are always showns")]
		AttributePrimary = 1,
		[RebirthName("Secondary Attribute")]
		[RebirthDescription("Hidden Attributes that cannot be increase with attribute points but through other means")]
		AttributeSecondary = 2,
		[RebirthName("Resistance")]
		[RebirthDescription("Damage and Resilience to specific damage/elemental types and reduce the damage dealt by them")]
		Resistance = 3,
		[RebirthName("Base")]
		[RebirthDescription("Base")]
		Base = 4,
		[RebirthName("Multiplier")]
		[RebirthDescription("Multiplier")]
		Multiplier = 5,
		[RebirthName("Calc")]
		[RebirthDescription("Base * Multiplier = Calc")]
		Calc = 6,
		[RebirthName("Attribute Points")]
		[RebirthDescription("Unspent Attribute points")]
		AttributePoints = 7,
		[RebirthName("Current Stats")]
		[RebirthDescription("Current Stats")]
		CurrentStats = 8,
		[RebirthName("Damage")]
		[RebirthDescription("Damage")]
		DamageType = 9,
		[RebirthName("Damage Reduction")]
		[RebirthDescription("Damage Reduction")]
		DamageReduction = 10,
		[RebirthName("Conditions")]
		[RebirthDescription("Stunned, Cursed, etc")]
		Condition = 11,
		MAX_VALUE = 12,
	}
}