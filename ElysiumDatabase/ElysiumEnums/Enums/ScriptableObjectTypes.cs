using RebirthStudios.Enums.Items;
using RebirthStudios.Enums.Items.Weapons;

namespace RebirthStudios.Enums
{
	public enum ScriptableObjectTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Animal")]
		Animal = 1,
		[RebirthName("Enemy Humanoid")]
		EnemyHumanoid = 2,
		[RebirthName("Monster")]
		Monster = 3,
		[RebirthName("NPC")]
		NPC = 4,
		[RebirthName("PC")]
		PC = 5,
		[RebirthName("Armor")]
		Armor = 6,
		[RebirthName("Jewelry")]
		Jewelry = 7,
		[RebirthName("Weapon")]
		Weapon = 8,
		[RebirthName("Bank")]
		Bank = 9,
		[RebirthName("Container")]
		Container = 10,
		[RebirthName("Dropped Item")]
		DroppedItem = 11,
		[RebirthName("Gatherable Node")]
		Gatherable = 12,
		[RebirthName("Mailbox")]
		Mailbox = 13,
		[RebirthName("Quest Board")]
		QuestBoard = 14,
		[RebirthName("Ammunition")]
		Ammunition = 15,
		[RebirthName("Bag")]
		Bag = 16,
		[RebirthName("Consumable")]
		Consumable = 17,
		[RebirthName("Currency")]
		Currency = 18,
		[RebirthName("General Item")]
		GeneralItem = 19,
		[RebirthName("Material")]
		Material = 20,
		[RebirthName("Ability")]
		Ability = 21,
		[RebirthName("Achievement")]
		Achievement = 22,
		[RebirthName("Base Weapon")]
		Base = 23,
		[RebirthName("Effect Group")]
		EffectGroup = 24,
		[RebirthName("GearSet")]
		GearSet = 25,
		[RebirthName("Items")]
		Item = 26,
		[RebirthName("Loot Table")]
		LootTable = 27,
		[RebirthName("Milestone")]
		Milestone = 28,
		[RebirthName("Quest")]
		Quest = 29,
		[RebirthName("Questline")]
		Questline = 30,
		[RebirthName("Recipe")]
		Recipe = 31,
		[RebirthName("Skill")]
		Skill = 32,
		[RebirthName("Spawn Table")]
		SpawnTable = 33,
		[RebirthName("Title")]
		Title = 34,
		[RebirthName("Total")]
		Total = 35,
		[RebirthName("Dungeon Structure")]
		DungeonStructure = 36,
		[RebirthName("Enemy Humanoid Structure")]
		EnemyHumanoidStructure = 37,
		[RebirthName("Ruin Structure")]
		RuinStructure = 38,
		[RebirthName("Village Defense Structure")]
		VillageDefenseStructure = 39,
		[RebirthName("Village Structure")]
		VillageStructure = 40,
		[RebirthName("Total Attacks")]
		TotalAttacks = 41,
		[RebirthName("Total Collected")]
		TotalCollected = 42,
		[RebirthName("Total Consumed")]
		TotalConsumed = 43,
		[RebirthName("Total Crafted")]
		TotalCrafted = 44,
		[RebirthName("Total Explored")]
		TotalExplored = 45,
		[RebirthName("Total Gathered")]
		TotalGathered = 46,
		[RebirthName("Total Killed")]
		TotalKilled = 47,
		[RebirthName("Total Looted")]
		TotalLooted = 48,
		[RebirthName("Total Missions")]
		TotalMissions = 49,
		[RebirthName("Total Quests")]
		TotalQuests = 50,
		[RebirthName("Total Sealed")]
		TotalSealed = 51,
		[RebirthName("Total Deaths")]
		TotalDeaths = 52,
		[RebirthName("Total Sold")]
		TotalSold = 53,
		[RebirthName("Total Purchased")]
		TotalPurchased = 54,
		[RebirthName("Total Stat")]
		TotalStat = 55,
		[RebirthName("Total Currency")]
		TotalCurrency = 56,
		[RebirthName("Total Upgrades")]
		TotalUpgrades = 57,
		MAX_VALUE = 58,
	}
}