using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum UnlockEffectType : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName(" Ability")]
		[RebirthDescription("Used by Consumables to Unlock Abilities")]
		Ability = 1,
		[RebirthName("Skill")]
		[RebirthDescription("Used by Consumables to Unlock Skills")]
		Skill = 2,
		[RebirthName("Recipe")]
		[RebirthDescription("Used by Consumables to Unlock Recipes")]
		Recipe = 3,
		MAX_VALUE = 4,
	}
}