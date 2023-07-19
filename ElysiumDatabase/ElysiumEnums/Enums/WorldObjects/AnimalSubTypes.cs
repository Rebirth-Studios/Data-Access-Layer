
namespace RebirthStudios.Enums.WorldObjects
{
	[RebirthChildEnum(typeof(AnimalClassificationTypes))]
	public enum AnimalSubTypes : byte
	{
		[RebirthName("None")]
		[RebirthSubType(0)]
		None = 0,
	}
}