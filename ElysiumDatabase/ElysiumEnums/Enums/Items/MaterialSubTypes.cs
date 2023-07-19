namespace RebirthStudios.Enums.Items
{
	[RebirthChildEnumAttribute(typeof(MaterialTypes))]
	public enum MaterialSubTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		[RebirthSubType(0)]
		None = 0,
	}
}