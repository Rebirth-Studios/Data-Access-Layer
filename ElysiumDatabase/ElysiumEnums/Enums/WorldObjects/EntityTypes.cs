namespace RebirthStudios.Enums.Items
{
	public enum EntityTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Animal")]
		[RebirthDescription("Boars, Rabbits, Wolves, Bears, Deer, etc")]
		Animal = 1,
		[RebirthName("Enemy Humanoid")]
		[RebirthDescription("Goblins, Undead, Trolls, etc")]
		EnemyHumanoid = 2,
		[RebirthName("Monster")]
		[RebirthDescription("Mimics. etc")]
		Monster = 3,
		[RebirthName("NPC")]
		[RebirthDescription("Vendors, Quest Givers, Villagers")]
		NPC = 4,
		[RebirthName("PC")]
		[RebirthDescription("Players")]
		PC = 5,
		MAX_VALUE = 6,
	}
}