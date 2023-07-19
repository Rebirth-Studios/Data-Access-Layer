namespace RebirthStudios.Enums.Items
{
	[RebirthChildEnumAttribute(typeof(BagClassificationTypes))]
	public enum BagSubTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
		[RebirthName("Potion of Healing")]
		[RebirthDescription("Potion of Healing")]
		[RebirthSubType(1)]
		PotionHealing = 1,
		[RebirthName("Potion of Health Regeneration")]
		[RebirthDescription("Potion of Health Regeneration")]
		[RebirthSubType(1)]
		PotionHealthRegen = 2,
		[RebirthName("Potion of Instant Stamina")]
		[RebirthDescription("Potions")]
		[RebirthSubType(2)]
		PotionStaminaInstant = 3,
		[RebirthName("Potion of Endurance ")]
		[RebirthDescription("None")]
		[RebirthSubType(2)]
		PotionStaminaRegen = 4,
		[RebirthName("Potion of Instant Mana")]
		[RebirthDescription("None")]
		[RebirthSubType(3)]
		PotionManaInstant = 5,
		[RebirthName("Potion of Mana Regen")]
		[RebirthDescription("None")]
		[RebirthSubType(3)]
		PotionManaRegen = 6,
		[RebirthName("Book of Dexterity")]
		[RebirthDescription("None")]
		[RebirthSubType(25)]
		BookDexterity = 7,
		[RebirthName("Book of Mentality")]
		[RebirthDescription("None")]
		[RebirthSubType(25)]
		BookMentality = 8,
		[RebirthName("Book of Strength")]
		[RebirthDescription("None")]
		[RebirthSubType(25)]
		BookStrength = 9,
		[RebirthName("Book of Constitution")]
		[RebirthDescription("None")]
		[RebirthSubType(25)]
		BookConstitution = 10,
		[RebirthName("Book of Agility")]
		[RebirthDescription("None")]
		[RebirthSubType(25)]
		BookAgility = 11,
	}
}