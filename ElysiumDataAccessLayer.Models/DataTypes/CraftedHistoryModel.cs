using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class CraftedHistoryModel
    {
        [JsonProperty] public byte   RarityId {get; set; }
        [JsonProperty] public string ItemGlobalObject {get; set; }
        [JsonProperty] public byte   Quantity {get; set; }


        public CraftedHistoryModel()
        {
            
        }
        public CraftedHistoryModel(byte rarityId, string itemGlobalObject, byte quantity)
        {
            RarityId           = rarityId;
            ItemGlobalObject = itemGlobalObject;
            Quantity           = quantity;
        }
    }    
}

