	 using RebirthStudios.Enums.Items;

	 namespace RebirthStudios.Enums
	 {
	public enum BaseStatTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Base Maximum Weight")]
		[RebirthDescription("Base Maximum Weight")]
		MaxWeight = 1,
		[RebirthName("Base Maximum Health")]
		[RebirthDescription("Base Maximum Health")]
		MaxHealth = 2,
		[RebirthName("Base Maximum Stamina")]
		[RebirthDescription("Base Maximum Stamina")]
		MaxStamina = 3,
		[RebirthName("Base Maximum Mana")]
		[RebirthDescription("Base Maximum Mana")]
		MaxMana = 4,
		[RebirthName("Base Health Regen")]
		[RebirthDescription("Base Health Regen")]
		HealthRegen = 5,
		[RebirthName("Base Stamina Regen")]
		[RebirthDescription("Base Stamina Regen")]
		StaminaRegen = 6,
		[RebirthName("Base Mana Regen")]
		[RebirthDescription("Base Mana Regen")]
		ManaRegen = 7,
		[RebirthName("Base Crouch Speed")]
		[RebirthDescription("Base Crouch Speed")]
		CrouchSpeedPercent = 8,
		[RebirthName("Base Walk Speed")]
		[RebirthDescription("Base Walk Speed")]
		WalkSpeed = 9,
		[RebirthName("Base Run Speed")]
		[RebirthDescription("Base Run Speed")]
		RunSpeedPercent = 10,
		[RebirthName("Base Attack Speed")]
		[RebirthDescription("Base Attack Speed")]
		AttackSpeed = 11,
		[RebirthName("Base Melee Damage")]
		[RebirthDescription("Base Melee Damage")]
		MeleeDamage = 12,
		[RebirthName("Base Ranged Damage")]
		[RebirthDescription("Base Ranged Damage")]
		RangedDamage = 13,
		[RebirthName("Base Magic Damage")]
		[RebirthDescription("Base Magic Damage")]
		MagicDamage = 14,
		[RebirthName("Base Critical Damage")]
		[RebirthDescription("Base Critical Damage")]
		CriticalDamage = 15,
		[RebirthName("Base Critical Damage")]
		[RebirthDescription("Base Critical Damage")]
		CriticalChance = 16,
		[RebirthName("Base Crafting Quality")]
		[RebirthDescription("Base Crafting Quality")]
		CraftingQuality = 17,
		[RebirthName("Base Learning Rate")]
		[RebirthDescription("Base Learning Rate")]
		LearningRate = 18,
		[RebirthName("Base Experience Rate")]
		[RebirthDescription("Base Experience Rate")]
		ExperienceRate = 19,
		[RebirthName("Base Jump Height")]
		[RebirthDescription("Base Jump Height")]
		JumpHeight = 20,
		[RebirthName("Base Aggro Range")]
		[RebirthDescription(" Base Aggro Range")]
		AggroRange = 21,
		[RebirthName("Base Foot Step Volume")]
		[RebirthDescription("Base Foot Step Volume")]
		FootstepVolume = 22,
		[RebirthName("Base Gathering Quantity Bonus")]
		[RebirthDescription("Base Gathering Quantity Bonus")]
		GatheringQuantityBonus = 23,
		[RebirthName("Base Gathering Rarity Bonus")]
		[RebirthDescription("Base Gathering Rarity Bonus")]
		GatheringRarityBonus = 24,
		[RebirthName("Base Gathering Drop Bonus")]
		[RebirthDescription("Base Gathering Drop Bonus")]
		GatheringDropBonus = 25,
		[RebirthName("Base Combat Quantity Bonus")]
		[RebirthDescription("Base Combat Quantity Bonus")]
		CombatQuantityBonus = 26,
		[RebirthName("Base Combat Rarity Bonus")]
		[RebirthDescription("Base Combat Rarity Bonus")]
		CombatRarityBonus = 27,
		[RebirthName("Base Combat Drop Chance Bonus")]
		[RebirthDescription("Base Combat Drop Chance Bonus")]
		CombatDropBonus = 28,
		[RebirthName("Base Mining Quantity Bonus")]
		[RebirthDescription("Base Mining Quantity Bonus")]
		MiningQuantityBonus = 29,
		[RebirthName("Base Mining Rarity Bonus")]
		[RebirthDescription("Base Mining Rarity Bonus")]
		MiningRarityBonus = 30,
		[RebirthName("Base Mining Drop Bonus")]
		[RebirthDescription("Base Mining Drop Bonus")]
		MiningDropBonus = 31,
		[RebirthName("Base Woodcutting Quantity Bonus")]
		[RebirthDescription("Base Woodcutting Quantity Bonus")]
		WoodcuttingQuantityBonus = 32,
		[RebirthName("Base Woodcutting Rarity Bonus")]
		[RebirthDescription("Base Woodcutting Rarity Bonus")]
		WoodcuttingRarityBonus = 33,
		[RebirthName("Base Woodcutting Drop Bonus")]
		[RebirthDescription("Base Woodcutting Drop Bonus")]
		WoodcuttingDropBonus = 34,
		[RebirthName("Base Herbalism Quantity Bonus")]
		[RebirthDescription("Base Herbalism Quantity Bonus")]
		HerbalismQuantityBonus = 35,
		[RebirthName("Base Herbalism Rarity Bonus")]
		[RebirthDescription("Base Herbalism Rarity Bonus")]
		HerbalismRarityBonus = 36,
		[RebirthName("Base Herbalism Drop Bonus")]
		[RebirthDescription("Base Herbalism Drop Bonus")]
		HerbalismDropBonus = 37,
		[RebirthName("Base Skinning Quantity Bonus")]
		[RebirthDescription("Base Skinning Quantity Bonus")]
		SkinningQuantityBonus = 38,
		[RebirthName("Base Skinning Rarity Bonus")]
		[RebirthDescription("Base Skinning Rarity Bonus")]
		SkinningRarityBonus = 39,
		[RebirthName("Base Skinning Drop Bonus")]
		[RebirthDescription("Base Skinning Drop Bonus")]
		SkinningDropBonus = 40,
		MAX_VALUE = 41,
	}
	 }