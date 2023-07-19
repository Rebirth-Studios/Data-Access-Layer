using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class RecipeIngredientModel
    {
        [JsonProperty] public string IngredientGlobalObject { get; private set; }
        [JsonProperty] public byte GlobalStatusId { get; private set; }
        [JsonProperty] public byte   RequiredQuantity { get; private set; }
        [JsonProperty] public float  IngredientWeight { get; private set; }
        [JsonProperty] public byte   IngredientSlot { get; private set; }
        [JsonProperty] public bool   PrimaryIngredient { get; private set; }

        public RecipeIngredientModel(string ingredientGlobalObject, byte globalStatusId, byte requiredQuantity, float ingredientWeight,
            byte                              ingredientSlot,         bool primaryIngredient)
        {
            IngredientGlobalObject = ingredientGlobalObject;
            GlobalStatusId         = globalStatusId;
            RequiredQuantity       = requiredQuantity;
            IngredientWeight       = ingredientWeight;
            IngredientSlot         = ingredientSlot;
            PrimaryIngredient      = primaryIngredient;
        }
    }
}

