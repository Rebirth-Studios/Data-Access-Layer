using RebirthStudios.Enums;
using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.WorldObjects
{
	[RebirthChildEnumAttribute(typeof(AnimalTypes))]
	public enum AnimalClassificationTypes : byte
	{
		[RebirthName("None")]
		[RebirthSubType(0)]
		None = 0,
		[RebirthName("Bear")]
		[RebirthSubType(3)]
		Bear = 1,
		[RebirthName("Boar")]
		[RebirthSubType(3)]
		Boar = 2,
		[RebirthName("Fox")]
		[RebirthSubType(1)]
		Fox = 3,
		[RebirthName("Deer")]
		[RebirthSubType(2)]
		Deer = 4,
		[RebirthName("Rabbit")]
		[RebirthSubType(1)]
		Rabbit = 5,
		[RebirthName("Wolf")]
		[RebirthSubType(2)]
		Wolf = 6,
	}
}