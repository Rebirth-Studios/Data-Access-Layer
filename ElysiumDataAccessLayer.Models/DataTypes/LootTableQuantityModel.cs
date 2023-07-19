namespace RebirthStudios.DataAccessLayer.Models
{
    public class LootTableQuantityModel
    {
        public byte  Quantity { get; set; }
        public float QuantityChance { get; set; }

        public LootTableQuantityModel()
        {
            
        }
        public LootTableQuantityModel(byte quantity, float quantityChance)
        {
            Quantity       = quantity;
            QuantityChance = quantityChance;
        }
    }    
}
