using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum QualityTypes : byte
	{
		[RebirthName("None")]
		None = 0,
		[RebirthName("Poor")]
		Poor = 1,
		[RebirthName("Average")]
		Average = 2,
		[RebirthName("Above Average")]
		AboveAverage = 3,
		[RebirthName("Well Crafted")]
		WellCrafted = 4,
		[RebirthName("Superb")]
		Superb = 5,
		[RebirthName("Exquisite")]
		Exquisite = 6,
		[RebirthName("Masterwork")]
		Masterwork = 7,
		MAX_VALUE = 8,
	}
}