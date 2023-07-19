using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum InteractableTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Dropped Item")]
		[RebirthDescription("Dropped Items")]
		DroppedItem = 1,
		[RebirthName("Gatherable Node")]
		[RebirthDescription("Veins, Trees, Mushrooms, etc")]
		Gatherable = 2,
		[RebirthName("Corpses")]
		[RebirthDescription("Corpses")]
		Corpse = 3,
		[RebirthName("Container")]
		[RebirthDescription("Containers")]
		Container = 4,
		[RebirthName("Quest Board")]
		[RebirthDescription("Quest Boards")]
		QuestBoard = 5,
		[RebirthName("Bank")]
		[RebirthDescription("Banks")]
		Bank = 6,
		[RebirthName("Mailbox")]
		[RebirthDescription("Mailboxes")]
		Mailbox = 7,
		[RebirthName("Vendor")]
		[RebirthDescription("Vendors")]
		Vendor = 8,
		[RebirthName("Quest Giver")]
		[RebirthDescription("QuestGivers")]
		QuestGiver = 9,
		[RebirthName("Controllable")]
		[RebirthDescription("Levers, buttons, etc")]
		Controllable = 10,
		MAX_VALUE = 11,
	}
}