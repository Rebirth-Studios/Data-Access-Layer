using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum CurrentStatTypes : byte
	{
		[RebirthName("Health")]
		[RebirthDescription("Current Health")]
		CurrentHealth = 0,
		[RebirthName("Stamina")]
		[RebirthDescription("Current Stamina")]
		CurrentStamina = 1,
		[RebirthName("Mana")]
		[RebirthDescription("Current Mana")]
		CurrentMana = 2,
		[RebirthName("Tier")]
		[RebirthDescription("Current Tier")]
		CurrentTier = 3,
		[RebirthName("Level")]
		[RebirthDescription("Current Rank")]
		CurrentLevel = 4,
		[RebirthName("Experience")]
		[RebirthDescription("Current Experience")]
		CurrentExperience = 5,
		[RebirthName("LowestAttributeValue")]
		[RebirthDescription("Current Value of lowest primary attribute")]
		CurrentLowestAttributeValue = 6,
		[RebirthName("TotalAttributePoints")]
		[RebirthDescription("Current Value of all primary attributes combined")]
		CurrentTotalAttributePoints = 7,
		[RebirthName("TotalDeaths")]
		[RebirthDescription("Number of times character has died")]
		TotalDeaths = 8,
		[RebirthName("Titles")]
		[RebirthDescription("Current number of titles")]
		Titles = 9,
		MAX_VALUE = 10,
	}
}