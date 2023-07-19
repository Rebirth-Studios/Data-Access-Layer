	 using RebirthStudios.Enums.Items;

	 namespace RebirthStudios.Enums
	 {
	public enum CalcStatTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Maximum Weight")]
		[RebirthDescription("(strength * statMultiplierMaxWeight * baseMaxWeight) + baseMaxWeight")]
		MaxWeight = 1,
		[RebirthName("Maximum Health")]
		[RebirthDescription("(((constitution * statMultiplierMaxHealth) + baseMaxHealth) + statEffectAddMaxHealth) * (1 + statEffectPercentMaxHealth)")]
		MaxHealth = 2,
		[RebirthName("Maximum Stamina")]
		[RebirthDescription("((constitution*statMultiplierMaxStamina) + baseMaxStamina)  + statEffectMaxStamina")]
		MaxStamina = 3,
		[RebirthName("Maximum Mana")]
		[RebirthDescription("((Intellect*StatMultiplier_MaxMana) +BaseMaxMana) + statEffectMaxMana")]
		MaxMana = 4,
		[RebirthName("Health Regen")]
		[RebirthDescription("((Constitution * StatMultiplier_HealthRegen) + BaseHealthRegen) * (1 + statEffectHealthRegen)")]
		HealthRegen = 5,
		[RebirthName("Stamina Regen")]
		[RebirthDescription("((Constitution * StatMultiplier_StaminaRegen) + BaseStaminaRegen)  * (1 + statEffectStaminaRegen)")]
		StaminaRegen = 6,
		[RebirthName("Mana Regen")]
		[RebirthDescription("((Intellect* StatMultiplier_ManaRegen) + BaseManaRegen)  * (1 + statEffectManaRegen)")]
		ManaRegen = 7,
		[RebirthName("Crouch Speed")]
		[RebirthDescription("(baseCrouchSpeedPercent * StatMultiplier_WalkSpeed)")]
		CrouchSpeed = 8,
		[RebirthName("Walk Speed")]
		[RebirthDescription("((Agility * StatMultiplier_MovementSpeed) + BaseWalkSpeed)  * (1 + statEffectWalkSpeed)")]
		WalkSpeed = 9,
		[RebirthName("Run Speed")]
		[RebirthDescription("(baseRunSpeedPercent * StatMultiplier_WalkSpeed)")]
		RunSpeed = 10,
		[RebirthName("Attack Speed")]
		[RebirthDescription("((Agility * StatMultiplier_AttackSpeed) + BaseAttackSpeed) * (1 + statEffectAttackSpeed)")]
		AttackSpeed = 11,
		[RebirthName("Melee Damage")]
		[RebirthDescription("((Strength * StatMultiplier_MeleeDamage) + BaseMeleeDamage)  * (1 + statEffectHealthRegen)")]
		MeleeDamage = 12,
		[RebirthName("Ranged Damage")]
		[RebirthDescription("((Strength * StatMultiplier_MeleeDamage) + BaseMeleeDamage)  * (1 + statEffectHealthRegen)")]
		RangedDamage = 13,
		[RebirthName("Magic Damage")]
		[RebirthDescription("((Strength * StatMultiplier_MeleeDamage) + BaseMeleeDamage)  * (1 + statEffectHealthRegen)")]
		MagicDamage = 14,
		[RebirthName("Critical Damage")]
		[RebirthDescription("((Dexterity * StatMultiplier_CriticalDamage) + BaseCriticalDamage)")]
		CriticalDamage = 15,
		[RebirthName("Critical Chance")]
		[RebirthDescription("???")]
		CriticalChance = 16,
		[RebirthName("Crafting Quality")]
		[RebirthDescription("((Dexterity * StatMultiplier_CraftingQuality) + BaseCraftingQuality)")]
		CraftingQuality = 17,
		[RebirthName("Learning Speed")]
		[RebirthDescription("((Mental * StatMultiplier_LearningSpeed) + BaseLearningSpeed)")]
		LearningSpeed = 18,
		[RebirthName("Experience Speed")]
		[RebirthDescription("baseExperienceRate + statEffectExperienceRate")]
		ExperienceSpeed = 19,
		[RebirthName("Jump Height")]
		[RebirthDescription("baseJumpHeight")]
		JumpHeight = 20,
		[RebirthName("Aggro Range")]
		[RebirthDescription("baseAggroRange")]
		AggroRange = 21,
		[RebirthName("Footstep Volume")]
		[RebirthDescription("baseFootstepVolume")]
		FootstepVolume = 22,
		MAX_VALUE = 23,
	}
	 }