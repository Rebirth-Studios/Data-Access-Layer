namespace RebirthStudios.Enums.Items
{
	public enum WorldObjectTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Interactable")]
		[RebirthDescription("Gatherables, Containers, Crafting Stations, Quest Boards, Mailboxes, etc")]
		Interactable = 1,
		[RebirthName("Entity")]
		[RebirthDescription("Animals, Enemy Humanoids, Monsters, NPCs and Players")]
		Entity = 2,
		[RebirthName("Structure")]
		[RebirthDescription("Ruins, Goblin Camps, Rifts, etc")]
		Structure = 3,
		MAX_VALUE = 4,
	}
}