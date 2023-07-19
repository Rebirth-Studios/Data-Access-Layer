using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum ArmorTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Cloth")]
		[RebirthDescription("Provides the least defense, but also the least amount of penalties")]
		Cloth = 1,
		[RebirthName("Leather")]
		[RebirthDescription("Provides decent defense, while not penalizing mana regen and casting")]
		Leather = 2,
		[RebirthName("Mail")]
		[RebirthDescription("Provides better decent than leather, but starts to affect mana regen and casting")]
		Mail = 3,
		[RebirthName("Plate")]
		[RebirthDescription("Provides the greatest amount of defense, but also has the highest penalties")]
		Plate = 4,
		MAX_VALUE = 5,
	}
}