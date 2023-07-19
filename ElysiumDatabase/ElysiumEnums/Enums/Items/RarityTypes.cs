using RebirthStudios.Enums.Items;
using RebirthStudios.Enums.Items.Weapons;

namespace RebirthStudios.Enums
{
	public enum RarityTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Common")]
		[RebirthDescription("None")]
		Common = 1,
		[RebirthName("Uncommon")]
		[RebirthDescription("None")]
		Uncommon = 2,
		[RebirthName("Rare")]
		[RebirthDescription("None")]
		Rare = 3,
		[RebirthName("Epic")]
		[RebirthDescription("None")]
		Epic = 4,
		[RebirthName("Unique")]
		[RebirthDescription("None")]
		Unique = 5,
		[RebirthName("Legendary")]
		[RebirthDescription("None")]
		Legendary = 6,
		[RebirthName("Mythic")]
		[RebirthDescription("None")]
		Mythic = 7,
		MAX_VALUE = 8,
	}
}