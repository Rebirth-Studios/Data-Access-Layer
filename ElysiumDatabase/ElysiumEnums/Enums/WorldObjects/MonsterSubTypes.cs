using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.WorldObjects
{
	[RebirthChildEnumAttribute(typeof(MonsterClassificationTypes))]
	public enum MonsterSubTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
	}
}