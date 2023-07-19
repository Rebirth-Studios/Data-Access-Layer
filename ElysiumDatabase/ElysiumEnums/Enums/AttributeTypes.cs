using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum AttributeTypes : byte
	{
		[RebirthName("Strength")]
		[RebirthDescription("Strength - Increase melee damage and max weight")]
		Strength = 0,
		[RebirthName("Agility")]
		[RebirthDescription("Agility - Attack Speed and movement speed")]
		Agility = 1,
		[RebirthName("Constitution")]
		[RebirthDescription("Constitution - Increases Max Health, Health Regen")]
		Constitution = 2,
		[RebirthName("Dexterity")]
		[RebirthDescription("Dexterity - Crafting quality, Range Damage")]
		Dexterity = 3,
		[RebirthName("Intellect")]
		[RebirthDescription("Intellect - Increase magic damage, Max Mana")]
		Intellect = 4,
		[RebirthName("Luck")]
		[RebirthDescription("Increases Stuff")]
		Luck = 5,
		[RebirthName("Dynamo")]
		[RebirthDescription("Increases Stamina Regen")]
		Dynamo = 6,
		[RebirthName("Indomitable")]
		[RebirthDescription("Has a certain probability of invalidating a portion of the incoming damage. The lower the health, the higher the probability.")]
		Indomitable = 7,
		[RebirthName("Persistence")]
		[RebirthDescription("Stuff")]
		Persistence = 8,
		[RebirthName("Fortitude")]
		[RebirthDescription("Reduces Melee, Reduces debuffs from starvation")]
		Fortitude = 9,
		[RebirthName("Composure")]
		[RebirthDescription("Composure is a stat that increases the recovery rate from status conditions")]
		Composure = 10,
		[RebirthName("Mentality")]
		[RebirthDescription("Increases Learning Speed, Mana Regen")]
		Mentality = 11,
		[RebirthName("Endurance")]
		[RebirthDescription("Increases Stamina Regen, Max Stamina")]
		Endurance = 12,
		MAX_VALUE = 13,
	}
}