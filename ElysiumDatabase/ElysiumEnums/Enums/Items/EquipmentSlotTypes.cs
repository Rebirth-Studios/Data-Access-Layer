namespace RebirthStudios.Enums.Items
{
	public enum EquipmentSlotTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Helmet")]
		Helmet = 1,
		[RebirthName("Necklace")]
		Necklace = 2,
		[RebirthName("Shoulders")]
		Shoulders = 3,
		[RebirthName("Cloak")]
		Cloak = 4,
		[RebirthName("Chestplate")]
		Chestplate = 5,
		[RebirthName("Bracers")]
		Bracers = 6,
		[RebirthName("Gloves")]
		Gloves = 7,
		[RebirthName("Belt")]
		Belt = 8,
		[RebirthName("Leggings")]
		Leggings = 9,
		[RebirthName("Boots")]
		Boots = 10,
		[RebirthName("Ring1")]
		Ring1 = 11,
		[RebirthName("Ring2")]
		Ring2 = 12,
		[RebirthName("Mainhand")]
		Mainhand = 13,
		[RebirthName("Offhand")]
		Offhand = 14,
		[RebirthName("Ranged")]
		Ranged = 15,
		MAX_VALUE = 16,
	}
}