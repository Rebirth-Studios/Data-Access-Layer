using System;
using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.WorldObjects
{
	[RebirthChildEnumAttribute(typeof(GatherableClassificationTypes))]
	public enum GatherableSubTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
	}
}