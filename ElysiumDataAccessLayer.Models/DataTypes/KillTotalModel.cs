using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class KillTotalModel
    {
        [JsonProperty] public ushort TotalId { get; set; }
        [JsonProperty] public byte   KillTypeId { get; set; }
        [JsonProperty] public byte   KillMainTypeId { get; set; }
        [JsonProperty] public byte   KillClassificationTypeId { get; set; } 
        [JsonProperty] public byte   KillSubTypeId { get; set; }   
        [JsonProperty] public byte   EntityTierId { get; set; }
        [JsonProperty] public byte DataAttributeId { get; set; }
        [JsonProperty] public byte ImbuedTypeId { get; set; }
        [JsonProperty] public byte DifficultyTypeId { get; set; }

        [JsonProperty] public ushort EntityId { get; set; }

        public KillTotalModel()
        {
            
        }

        public KillTotalModel(ushort totalId,
            byte                     killTypeId,
            byte                     killMainTypeId, 
            byte                     killClassificationTypeId, 
            byte                     killSubTypeId,
            byte                     entityTierId, 
            byte                     dataAttributeId, 
            byte                     imbuedTypeId, 
            byte                     difficultyTypeId, 
            ushort                   entityId)
        {
            TotalId                  = totalId;
            KillTypeId               = killTypeId;
            KillMainTypeId           = killMainTypeId;
            KillClassificationTypeId = killClassificationTypeId;
            KillSubTypeId            = killSubTypeId;
            EntityTierId             = entityTierId;
            DataAttributeId          = dataAttributeId;
            ImbuedTypeId             = imbuedTypeId;
            DifficultyTypeId         = difficultyTypeId;
            EntityId                 = entityId;
        }
    }
}

