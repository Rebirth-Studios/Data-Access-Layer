namespace RebirthStudios.DataAccessLayer.Models
{
    public class IngredientModel
    {
        public string IngredientItemId { get; set; }
        public float  IngredientWeight { get; set; }
        public bool   PrimaryIngredient { get; set; }

        public IngredientModel()
        {
            
        }
        public IngredientModel(
            string ingredientItemId, 
            float  ingredientWeight,
            bool   primaryIngredient)
        {
            IngredientItemId  = ingredientItemId;
            IngredientWeight  = ingredientWeight;
            PrimaryIngredient = primaryIngredient;
        }
    }
}

