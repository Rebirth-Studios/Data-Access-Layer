using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.WorldObjects
{
	public enum NpcTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Vendor")]
		Vendor = 1,
		[RebirthName("Quest Giver")]
		QuestGiver = 2,
		[RebirthName("General")]
		[RebirthDescription("General")]
		General = 3,
		MAX_VALUE = 4,
	}
}