using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class RecipeModel
    {
        [JsonProperty] public ushort RecipeId             { get; set; }
        [JsonProperty] public string GlobalObject       { get; set; }
        [JsonProperty] public byte   GlobalStatusId       {get;  set; }
        [JsonProperty] public string RecipeName           { get; set; }
        [JsonProperty] public string RecipeDescription    { get; set; }
        [JsonProperty] public byte   RecipeTierId         { get; set; }
        [JsonProperty] public ushort SkillId              { get; set; }
        [JsonProperty] public byte   GlobalObjectTypeId   { get; set; }
        [JsonProperty] public string ScriptableObjectPath { get; set; }
        [JsonProperty] public byte   ContainerTypeId      { get; set; }
        [JsonProperty] public float  CraftDuration        { get; set; }
        [JsonProperty] public byte   RequiredSkillTier   { get; set; }
        [JsonProperty] public byte   RequiredSkillLevel   { get; set; }
        [JsonProperty] public uint   RecipeExperience     { get; set; }
        [JsonProperty] public bool   DynamicRecipe        { get; set; }

        public RecipeModel(ushort recipeId, string globalObject, byte globalStatusId, string recipeName, string recipeDescription, 
            byte recipeTierId, ushort skillId, byte globalObjectTypeId, string scriptableObjectPath, byte containerTypeId, 
            float craftDuration, byte requiredSkillTier, byte requiredSkillLevel, uint recipeExperience, bool dynamicRecipe)
        {
            RecipeId             = recipeId;
            GlobalObject       = globalObject;
            GlobalStatusId       = globalStatusId;
            RecipeName           = recipeName;
            RecipeDescription    = recipeDescription;
            RecipeTierId         = recipeTierId;
            SkillId              = skillId;
            GlobalObjectTypeId   = globalObjectTypeId;
            ScriptableObjectPath = scriptableObjectPath;
            ContainerTypeId      = containerTypeId;
            CraftDuration        = craftDuration;
            RequiredSkillTier   = requiredSkillTier;
            RequiredSkillLevel   = requiredSkillLevel;
            RecipeExperience     = recipeExperience;
            DynamicRecipe        = dynamicRecipe;
        }
    }
}

