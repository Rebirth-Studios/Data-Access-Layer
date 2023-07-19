namespace RebirthStudios.Enums.Items
{
	[RebirthChildEnumAttribute(typeof(MonsterTypes))]
	public enum MonsterClassificationTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
		[RebirthName("Mimic")]
		[RebirthDescription("Mimic")]
		[RebirthSubType(1)]
		Mimic = 1,
	}
}