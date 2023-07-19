using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.WorldObjects
{
	[RebirthChildEnumAttribute(typeof(EnemyHumanoidTypes))]
	public enum EnemyHumanoidClassificationTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
		[RebirthName("Goblin Melee")]
		[RebirthDescription("Goblin")]
		[RebirthSubType(1)]
		GoblinMelee = 1,
		[RebirthName("Goblin Magic Casters")]
		[RebirthDescription("Goblin")]
		[RebirthSubType(1)]
		GoblinMagic = 2,
		[RebirthName("Orc")]
		[RebirthDescription("Orc")]
		[RebirthSubType(2)]
		Orc = 3,
		[RebirthName("Skeleton")]
		[RebirthDescription("Skeleton")]
		[RebirthSubType(3)]
		Skeleton = 4,
		[RebirthName("Ghost")]
		[RebirthDescription("Ghost")]
		[RebirthSubType(3)]
		Ghost = 5,
		[RebirthName("Troll")]
		[RebirthDescription("Troll")]
		[RebirthSubType(4)]
		Troll = 6,
		[RebirthName("Golem")]
		[RebirthDescription("Golem")]
		[RebirthSubType(5)]
		Golem = 7,
		[RebirthName("God")]
		[RebirthDescription("God")]
		[RebirthSubType(6)]
		God = 8,
		[RebirthName("Demon")]
		[RebirthDescription("Demon")]
		[RebirthSubType(7)]
		Demon = 9,
		[RebirthName("Barbarian")]
		[RebirthDescription("Barbarian")]
		[RebirthSubType(8)]
		Barbarian = 10,
	}
}