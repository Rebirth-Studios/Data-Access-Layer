using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	[RebirthChildEnumAttribute(typeof(LootTableTypes))]
	public enum LootTableSubTypes : byte
	{
		[RebirthName("None")]
		[RebirthSubType(0)]
		None = 0,
		[RebirthName("Mining")]
		[RebirthSubType(1)]
		Mining = 1,
		[RebirthName("Woodcutting")]
		[RebirthSubType(1)]
		Woodcutting = 2,
		[RebirthName("Herbalism")]
		[RebirthSubType(1)]
		Herbalism = 3,
		[RebirthName("Skinning")]
		[RebirthSubType(1)]
		Skinning = 4,
	}
}