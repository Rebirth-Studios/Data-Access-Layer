using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class LootTableRarityModel
    {
        [JsonProperty] public byte  RarityId { get; set; }
        [JsonProperty] public float RarityChance { get; set; }

        public LootTableRarityModel()
        {
            
        }
        
        public LootTableRarityModel(byte rarityId, float rarityChance)
        {
            RarityId     = rarityId;
            RarityChance = rarityChance;
        }
    }
}

