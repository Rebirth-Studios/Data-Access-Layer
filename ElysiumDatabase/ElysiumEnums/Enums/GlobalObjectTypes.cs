using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum GlobalObjectTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Ability")]
		Ability = 1,
		[RebirthName("Achievement")]
		Achievement = 2,
		[RebirthName("Base")]
		Base = 3,
		[RebirthName("Effect")]
		Effect = 4,
		[RebirthName("Effect Group")]
		EffectGroup = 5,
		[RebirthName("GearSet")]
		GearSet = 6,
		[RebirthName("Item")]
		Item = 7,
		[RebirthName("LootTable")]
		LootTable = 8,
		[RebirthName("Milestone")]
		Milestone = 9,
		[RebirthName("Quest")]
		Quest = 10,
		[RebirthName("Questline")]
		Questline = 11,
		[RebirthName("Recipe")]
		Recipe = 12,
		[RebirthName("Skill")]
		Skill = 13,
		[RebirthName("SpawnTable")]
		SpawnTable = 14,
		[RebirthName("Title")]
		Title = 15,
		[RebirthName("Total")]
		Total = 16,
		[RebirthName("WorldObject")]
		WorldObject = 17,
		MAX_VALUE = 18,
	}
}