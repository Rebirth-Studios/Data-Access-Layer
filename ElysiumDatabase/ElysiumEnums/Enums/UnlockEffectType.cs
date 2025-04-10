using RebirthStudios.Enums.Items;

namespace RebirthStudios.Enums
{
	public enum UnlockEffectType : byte
	{
		[RebirthName("None")]
		[RebirthDescription("None")]
		None = 0,
		[RebirthName("Unlock Ability")]
		[RebirthDescription("Used by Consumables to Unlock Abilities")]
		UnlockAbility = 1,
		[RebirthName("Unlock Skill")]
		[RebirthDescription("Used by Consumables to Unlock Skills")]
		UnlockSkill = 2,
		[RebirthName("Unlock Recipe")]
		[RebirthDescription("Used by Consumables to Unlock Recipes")]
		UnlockRecipe = 3,
		MAX_VALUE = 4,
	}
}