namespace RebirthStudios.Enums.Items
{
	[RebirthChildEnumAttribute(typeof(GeneralItemTypes))]
	public enum GeneralItemClassificationTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
		[RebirthName("Skull")]
		[RebirthDescription("Skull")]
		[RebirthSubType(1)]
		Skull = 1,
		[RebirthName("Coin")]
		[RebirthDescription("Unique / Ancient coins")]
		[RebirthSubType(1)]
		Coin = 2,
		[RebirthName("Bowl")]
		[RebirthDescription("Bowl")]
		[RebirthSubType(3)]
		Bowl = 3,
		[RebirthName("Bucket")]
		[RebirthDescription("Bucket")]
		[RebirthSubType(3)]
		Bucket = 4,
		[RebirthName("Goblet")]
		[RebirthDescription("Goblet")]
		[RebirthSubType(3)]
		Goblet = 5,
		[RebirthName("Mug")]
		[RebirthDescription("Mug")]
		[RebirthSubType(3)]
		Mug = 6,
		[RebirthName("TradeContainer")]
		[RebirthDescription("Trade Container")]
		[RebirthSubType(3)]
		TradeContainer = 7,
		[RebirthName("Crate")]
		[RebirthDescription("Crate")]
		[RebirthSubType(3)]
		Crate = 8,
		[RebirthName("Key")]
		[RebirthDescription("Key")]
		[RebirthSubType(2)]
		Key = 9,
		[RebirthName("Shirt")]
		[RebirthDescription("Shirt")]
		[RebirthSubType(4)]
		Shirt = 10,
		[RebirthName("Screw Driver")]
		[RebirthDescription("Screw Driver")]
		[RebirthSubType(5)]
		ScrewDriver = 11,
		[RebirthName("Enchanting Rod")]
		[RebirthDescription("Enchanting Rod")]
		[RebirthSubType(5)]
		EnchantingRod = 12,
	}
}