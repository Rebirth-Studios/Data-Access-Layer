using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum AnimalTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Bear")]
		[RebirthDescription("Bear")]
		Bear = 1,
		[RebirthName("Boar")]
		[RebirthDescription("Boar")]
		Boar = 2,
		[RebirthName("Fox")]
		[RebirthDescription("Fox")]
		Fox = 3,
		[RebirthName("Deer")]
		[RebirthDescription("Deer")]
		Deer = 4,
		[RebirthName("Rabbit")]
		[RebirthDescription("Rabbit")]
		Rabbit = 5,
		[RebirthName("Wolf")]
		[RebirthDescription("Wolf")]
		Wolf = 6,
		MAX_VALUE = 7,
	}
}