using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class LootTableDropModel
    {
        [JsonProperty] public string ItemGlobalObject;
        [JsonProperty] public float  DropChance;
        [JsonProperty] public byte   QualityId;
        [JsonProperty] public string RecipeGlobalObject;
        [JsonProperty] public string RecipeScriptableObjectPath;

        public LootTableDropModel()
        {
            
        }
        
        public LootTableDropModel(string itemGlobalObject,   float  dropChance, byte qualityId, 
            string                         recipeGlobalObject, string recipeScriptableObjectPath)
        {
            ItemGlobalObject         = itemGlobalObject;
            DropChance                 = dropChance;
            QualityId                  = qualityId;
            RecipeGlobalObject       = recipeGlobalObject;
            RecipeScriptableObjectPath = recipeScriptableObjectPath;
        }
    } 
}

