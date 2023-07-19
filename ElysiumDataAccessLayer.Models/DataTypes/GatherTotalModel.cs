using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class GatherTotalModel
    {
        [JsonProperty] public ushort TotalId { get; set; }
        [JsonProperty] public byte   GatherTypeId { get; set; } 
        [JsonProperty] public byte   GatherMainTypeId { get; set; } 
        [JsonProperty] public byte   GatherClassificationTypeId { get; set; } 
        [JsonProperty] public byte   GatherSubTypeId { get; set; } 
        [JsonProperty] public byte   TierId { get; set; } 
        [JsonProperty] public byte   DataAttributeId { get; set; } 
        [JsonProperty] public byte   ImbuedTypeId { get; set; } 
        [JsonProperty] public ushort ScriptableInteractableId { get; set; }

        public GatherTotalModel()
        {
            
        }
        
        public GatherTotalModel(
            ushort totalId,        
            byte gatherTypeId, 
            byte gatherMainTypeId, 
            byte   gatherClassificationTypeId, 
            byte                       gatherSubTypeId, 
            byte tierId,        
            byte dataAttributeId,
            byte imbuedTypeId,
            ushort scriptableInteractableId)
        {
            TotalId                    = totalId;
            GatherTypeId                    = gatherTypeId;
            GatherMainTypeId           = gatherMainTypeId;
            GatherClassificationTypeId = gatherClassificationTypeId;
            GatherSubTypeId            = gatherSubTypeId;
            TierId                     = tierId;
            DataAttributeId = dataAttributeId;
            ImbuedTypeId = imbuedTypeId;
            ScriptableInteractableId   = scriptableInteractableId;
        }
    } 
}

