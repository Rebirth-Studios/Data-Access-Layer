using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class CraftTotalModel
    {
        [JsonProperty] public ushort TotalId { get; set; }
        [JsonProperty] public byte   ItemTypeId { get; set; } 
        [JsonProperty] public byte   ClassificationId { get; set; } 
        [JsonProperty] public byte   ItemSubTypeId { get; set; } 
        [JsonProperty] public byte   ItemSubSubTypeId { get; set; } 
        [JsonProperty] public byte   RarityId { get; set; }
        [JsonProperty] public ushort ItemId { get; set; }

        public CraftTotalModel()
        {
            
        }
        public CraftTotalModel(ushort totalId, byte itemTypeId, byte classificationId, byte itemSubTypeId, byte itemSubSubTypeId, byte rarityId, ushort itemId)
        {
            TotalId          = totalId;
            ItemTypeId       = itemTypeId;
            ClassificationId = classificationId;
            ItemSubTypeId    = itemSubTypeId;
            ItemSubSubTypeId = itemSubSubTypeId;
            RarityId         = rarityId;
            ItemId           = itemId;
        }
    } 
}

