using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class RecipeProductModel
    {
        [JsonProperty] public string GlobalObject   { get; private set; }
        [JsonProperty] public byte   GlobalStatusId { get; private set; }
        [JsonProperty] public byte   Quantity       { get; private set; }

        public RecipeProductModel(string recipeGlobalObject, byte globalStatusId, byte quantity)
        {
            GlobalObject   = recipeGlobalObject;
            GlobalStatusId = globalStatusId;
            Quantity       = quantity;
        }
    }
}