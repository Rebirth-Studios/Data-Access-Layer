 using RebirthStudios.Enums.Items;

 namespace RebirthStudios.Enums
 {
	public enum StatMultiplierTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Stat Multiplier Max Weight")]
		[RebirthDescription("How much to increase max weight for each stat/attribute point")]
		MaxWeight = 1,
		[RebirthName("Stat Multiplier Max Health")]
		[RebirthDescription("How much to increase max health for each stat/attribute point")]
		MaxHealth = 2,
		[RebirthName("Stat Multiplier Max Stamina")]
		[RebirthDescription("How much to increase max stamina for each stat/attribute point")]
		MaxStamina = 3,
		[RebirthName("Stat Multiplier Max Mana")]
		[RebirthDescription("How much to increase max mana for each stat/attribute point")]
		MaxMana = 4,
		[RebirthName("Stat Multiplier Health Regen")]
		[RebirthDescription("How much to increase health regen for each stat/attribute point")]
		HealthRegen = 5,
		[RebirthName("Stat Multiplier Stamina Regen")]
		[RebirthDescription("How much to increase stamina regen for each stat/attribute point")]
		StaminaRegen = 6,
		[RebirthName("Stat Multiplier Mana Regen")]
		[RebirthDescription("???")]
		ManaRegen = 7,
		[RebirthName("Stat Multiplier Crouch Speed")]
		[RebirthDescription("How much to increase walk speed for each stat/attribute point")]
		CrouchSpeedPercent = 8,
		[RebirthName("Stat Multiplier Walk Speed")]
		[RebirthDescription("???")]
		WalkSpeed = 9,
		[RebirthName("Stat Multiplier Run Speed")]
		[RebirthDescription("How much to increase walk speed for each stat/attribute point")]
		RunSpeedPercent = 10,
		[RebirthName("Stat Multiplier Attack Speed")]
		[RebirthDescription("How much to increase attack speed for each stat/attribute point")]
		AttackSpeed = 11,
		[RebirthName("Stat Multiplier Melee Damage")]
		[RebirthDescription("How much to increase melee damage for each stat/attribute point")]
		MeleeDamage = 12,
		[RebirthName("Stat Multiplier Ranged Damage")]
		[RebirthDescription("How much to increase ranged damage for each stat/attribute point")]
		RangedDamage = 13,
		[RebirthName("Stat Multiplier Magic Damage")]
		[RebirthDescription("How much to increase magic damage for each stat/attribute point")]
		MagicDamage = 14,
		[RebirthName("Stat Multiplier Critical Damage")]
		[RebirthDescription("How much to increase critical damage for each stat/attribute point")]
		CriticalDamage = 15,
		[RebirthName("Stat Multiplier Critical Chance")]
		[RebirthDescription("How much to increase critical chance for each stat/attribute point")]
		CriticalChance = 16,
		[RebirthName("Stat Multiplier Crafting Quality")]
		[RebirthDescription("How much to increase crafting quality for each stat/attribute point")]
		CraftingQuality = 17,
		[RebirthName("Stat Multiplier Learning Speed")]
		[RebirthDescription("How much to increase learning speed for each stat/attribute point")]
		LearningSpeed = 18,
		[RebirthName("Stat Multiplier Experience Speed")]
		[RebirthDescription("How much to increase experience speed for each stat/attribute point")]
		ExperienceSpeed = 19,
		[RebirthName("Stat Multiplier Jump Height")]
		[RebirthDescription("???")]
		JumpHeight = 20,
		[RebirthName("Stat Multiplier Aggro Range")]
		[RebirthDescription("???")]
		AggroRange = 21,
		[RebirthName("Stat Multiplier Footstep Volume")]
		[RebirthDescription("???")]
		FootstepVolume = 22,
		MAX_VALUE = 23,
	} 
 }