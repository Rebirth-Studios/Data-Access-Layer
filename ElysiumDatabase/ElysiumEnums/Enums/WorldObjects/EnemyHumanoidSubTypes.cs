namespace RebirthStudios.Enums.WorldObjects
{
	[RebirthChildEnum(typeof(EnemyHumanoidClassificationTypes))]
	public enum EnemyHumanoidSubTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
	}
}