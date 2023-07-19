using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class CollectedHistoryModel
    {
        [JsonProperty] public byte   RarityId { get; set; }
        [JsonProperty] public string ItemGlobalObject { get; set; }
        [JsonProperty] public byte   Quantity { get; set; }

        public CollectedHistoryModel()
        {
            
        }
        
        public CollectedHistoryModel(byte rarityId, string itemGlobalObject, byte quantity)
        {
            RarityId           = rarityId;
            ItemGlobalObject = itemGlobalObject;
            Quantity           = quantity;
        }
    }    
}
