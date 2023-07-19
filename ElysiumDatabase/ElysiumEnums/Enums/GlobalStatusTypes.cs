namespace RebirthStudios.Enums.Items
{
	public enum GlobalStatusTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Hidden")]
		[RebirthDescription("hidden from players but affects them")]
		Hidden = 1,
		[RebirthName("Active")]
		[RebirthDescription("active (displayed to players)")]
		Active = 2,
		[RebirthName("Locked")]
		[RebirthDescription("do not import")]
		Locked = 3,
		[RebirthName("Completed")]
		[RebirthDescription("used for quests")]
		Completed = 4,
		[RebirthName("Abandoned")]
		[RebirthDescription("used for quests")]
		Abandoned = 5,
		[RebirthName("Unlocked")]
		[RebirthDescription("does not affect players and is hidden")]
		Unlocked = 6,
		[RebirthName("Consumed")]
		[RebirthDescription("player used the item")]
		Consumed = 7,
		[RebirthName("Deleted")]
		[RebirthDescription("player deleted item")]
		Deleted = 8,
		MAX_VALUE = 9,
	}
}