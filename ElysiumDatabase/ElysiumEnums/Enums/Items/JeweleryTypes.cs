using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.Items
{
	public enum JeweleryTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Ring")]
		Ring = 1,
		[RebirthName("Necklace")]
		Necklace = 2,
		MAX_VALUE = 3,
	}
}