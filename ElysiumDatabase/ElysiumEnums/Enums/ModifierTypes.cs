using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum ModifierTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Damage")]
		Damage = 1,
		[RebirthName("Durability")]
		Durability = 2,
		[RebirthName("Weight")]
		Weight = 3,
		[RebirthName("Mana Capacity")]
		ManaCapacity = 4,
		[RebirthName("Attack Speed")]
		AttackSpeed = 5,
		[RebirthName("Color")]
		ColorId = 6,
		[RebirthName("Defense")]
		Defense = 7,
		[RebirthName("Experience")]
		[RebirthDescription("Skill Experience gain when crafting")]
		Experience = 8,
		[RebirthName("Value")]
		[RebirthDescription("Gold, Silver and Copper Value")]
		Value = 9,
		[RebirthName("Tool Power")]
		[RebirthDescription("Tool Power for Common Rarity Items")]
		ToolPower = 10,
		[RebirthName("Mana Regen Penalty")]
		[RebirthDescription("Lowers Mana Regen Rate")]
		ManaRegenPenalty = 11,
		[RebirthName("Stamina Burn Penalty")]
		[RebirthDescription("Use increased when moving and attacking")]
		StaminaBurnPenalty = 12,
		[RebirthName("Movement Speed Penalty")]
		[RebirthDescription("You move slower bitch")]
		MovementSpeedPenalty = 13,
		MAX_VALUE = 14,
	}
}