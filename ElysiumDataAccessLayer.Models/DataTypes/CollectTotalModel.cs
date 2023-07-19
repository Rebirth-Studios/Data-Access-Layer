using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class CollectTotalModel
    {
        [JsonProperty] public ushort TotalId { get; set; }
        [JsonProperty] public byte   CollectTypeId { get; set; } 
        [JsonProperty] public byte   CollectMainTypeId { get; set; } 
        [JsonProperty] public byte   CollectClassificationTypeId { get; set; } 
        [JsonProperty] public byte   CollectSubTypeId { get; set; } 
        [JsonProperty] public byte   RarityId { get; set; } 
        [JsonProperty] public ushort ItemId { get; set; }

        public CollectTotalModel()
        {
            
        }
        public CollectTotalModel(ushort totalId, byte collectTypeId, byte collectMainTypeId, byte collectClassificationTypeId, 
            byte collectSubTypeId, byte rarityId, ushort itemId)
        {
            TotalId                     = totalId;
            CollectTypeId               = collectTypeId;
            CollectMainTypeId           = collectMainTypeId;
            CollectClassificationTypeId = collectClassificationTypeId;
            CollectSubTypeId            = collectSubTypeId;
            RarityId                    = rarityId;
            ItemId                      = itemId;
        }
    }
}

