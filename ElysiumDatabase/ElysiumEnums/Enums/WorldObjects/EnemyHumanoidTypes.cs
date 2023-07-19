using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.WorldObjects
{
	public enum EnemyHumanoidTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Goblin")]
		[RebirthDescription("Goblin Warrior")]
		Goblin = 1,
		[RebirthName("Orc")]
		[RebirthDescription("Orc")]
		Orc = 2,
		[RebirthName("Undead")]
		[RebirthDescription("Skeletons, Ghost, Ghouls")]
		Undead = 3,
		[RebirthName("Troll")]
		[RebirthDescription("Troll")]
		Troll = 4,
		[RebirthName("Golem")]
		[RebirthDescription("Golem")]
		Golem = 5,
		[RebirthName("Diety")]
		[RebirthDescription("Diety")]
		Diety = 6,
		[RebirthName("Demon")]
		[RebirthDescription("Demon")]
		Demon = 7,
		[RebirthName("Barbarian")]
		[RebirthDescription("Barbarian")]
		Barbarian = 8,
		MAX_VALUE = 9,
	}
}