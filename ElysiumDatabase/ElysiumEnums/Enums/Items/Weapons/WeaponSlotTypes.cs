using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums.Items.Weapons
{
	public enum WeaponSlotTypes : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("One-Hand")]
		[RebirthDescription("Can be wielded in Main-Hand or Off-Hand.")]
		OneHanded = 1,
		[RebirthName("Main-Hand")]
		[RebirthDescription("Exclusively wielded in Main-Hand.")]
		Mainhand = 2,
		[RebirthName("Two-Hand")]
		[RebirthDescription("Takes both Main-Hand and Off-Hand slots to wield.")]
		TwoHanded = 3,
		[RebirthName("Off-Hand")]
		[RebirthDescription("Exclusively wielded in Off-Hand.")]
		Offhand = 4,
		[RebirthName("Ranged")]
		[RebirthDescription("Exclusively wielded in Ranged")]
		Ranged = 5,
		MAX_VALUE = 6,
	}
}