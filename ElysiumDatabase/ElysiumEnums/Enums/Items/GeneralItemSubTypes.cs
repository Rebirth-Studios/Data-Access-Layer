namespace RebirthStudios.Enums.Items
{
	[RebirthChildEnumAttribute(typeof(GeneralItemClassificationTypes))]
	public enum GeneralItemSubTypes : byte
	{
		[RebirthName("None")]
		[RebirthSubType(0)]
		None = 0,
	}
}