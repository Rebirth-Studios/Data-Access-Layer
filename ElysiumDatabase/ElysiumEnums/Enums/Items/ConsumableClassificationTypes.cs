namespace RebirthStudios.Enums.Items
{
	[RebirthChildEnumAttribute(typeof(ConsumableTypes))]
	public enum ConsumableClassificationTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("none")]
		[RebirthSubType(0)]
		None = 0,
		[RebirthName("Potion of Health")]
		[RebirthDescription("Health Potion")]
		[RebirthSubType(1)]
		PotionHealth = 1,
		[RebirthName("Potion of Stamina")]
		[RebirthDescription("Stamina Potion")]
		[RebirthSubType(1)]
		PotionStamina = 2,
		[RebirthName("Potion of Mana")]
		[RebirthDescription("Mana Potion")]
		[RebirthSubType(1)]
		PotionMana = 3,
		[RebirthName("Potion of Explosion")]
		[RebirthDescription("Explosive Potion")]
		[RebirthSubType(1)]
		PotionExplosive = 4,
		[RebirthName("Potion of Mystery")]
		[RebirthDescription("Potion of Mystery")]
		[RebirthSubType(1)]
		PotionMystery = 5,
		[RebirthName(" Potion of Rejuvenation")]
		[RebirthDescription(" Potion of Rejuvenation")]
		[RebirthSubType(1)]
		PotionRejuvenation = 6,
		[RebirthName("Skill Book")]
		[RebirthDescription("Skill Book")]
		[RebirthSubType(3)]
		BookSkill = 7,
		[RebirthName("Recipe Book")]
		[RebirthDescription("Recipe Book")]
		[RebirthSubType(3)]
		BookRecipe = 8,
		[RebirthName("Ability Book")]
		[RebirthDescription("Ability Book")]
		[RebirthSubType(3)]
		BookAbility = 9,
		[RebirthName("Recipe Scroll")]
		[RebirthDescription("Recipe Scroll")]
		[RebirthSubType(4)]
		ScrollRecipe = 10,
		[RebirthName("Skill Scroll")]
		[RebirthDescription("Skill Scroll")]
		[RebirthSubType(4)]
		ScrollSkill = 11,
		[RebirthName("Ability Scroll")]
		[RebirthDescription("Ability Scroll")]
		[RebirthSubType(4)]
		ScrollAbility = 12,
		[RebirthName("Purse")]
		[RebirthDescription("When opened gives a random amount of gold, silver, and copper")]
		[RebirthSubType(10)]
		Purse = 13,
		[RebirthName("Chest")]
		[RebirthDescription("When opened gives random items. Example LockBox")]
		[RebirthSubType(10)]
		Chest = 14,
		[RebirthName("Bomb")]
		[RebirthDescription("Bombs")]
		[RebirthSubType(7)]
		Bomb = 15,
		[RebirthName("Experience Stone")]
		[RebirthDescription("Experience Stones")]
		[RebirthSubType(11)]
		StoneExperience = 16,
		[RebirthName("Bandage")]
		[RebirthDescription("Bandages")]
		[RebirthSubType(6)]
		Bandage = 17,
		[RebirthName("Fishing Lure")]
		[RebirthDescription("Fishing Lure")]
		[RebirthSubType(9)]
		FishingLure = 18,
		[RebirthName("Explosion Rune")]
		[RebirthDescription("Explosion Runes")]
		[RebirthSubType(8)]
		RuneExplosion = 19,
		[RebirthName("Snack")]
		[RebirthDescription("Snack")]
		[RebirthSubType(2)]
		Snack = 20,
		[RebirthName("Meal")]
		[RebirthDescription("Meal")]
		[RebirthSubType(2)]
		Meal = 21,
		[RebirthName("Feast")]
		[RebirthDescription("Feast")]
		[RebirthSubType(2)]
		Feast = 22,
		[RebirthName("Fruit")]
		[RebirthDescription("Fruit")]
		[RebirthSubType(2)]
		Fruit = 23,
		[RebirthName("Potion of Other")]
		[RebirthDescription("Misc Potions")]
		[RebirthSubType(1)]
		PotionOther = 24,
		[RebirthName("Attribute Book")]
		[RebirthDescription("Attribute Book")]
		[RebirthSubType(3)]
		BookAttribute = 25,
	}
}