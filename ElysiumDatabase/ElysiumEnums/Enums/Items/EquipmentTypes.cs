using System;

namespace RebirthStudios.Enums.Items
{
	public enum EquipmentTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Armor")]
		[RebirthDescription("Chestplates, Helmets, Leggings, Gloves, etc")]
		Armor = 1,
		[RebirthName("Weapon")]
		[RebirthDescription("Battle Axes, Shortswords, Daggers, Bow, etc")]
		Weapon = 2,
		[RebirthName("Jewelry")]
		[RebirthDescription("Necklaces, Rings and Trinkets")]
		Jewelry = 3,
		MAX_VALUE = 4,
	}
}