using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class EquipmentRequirementModel
    {
        [JsonProperty] public byte RequiredStatTypeId { get; set;}
        [JsonProperty] public byte RequiredStatId     { get; set;}
        [JsonProperty] public int  RequiredAmount     { get; set;}
            
        public EquipmentRequirementModel(byte requiredStatTypeId, byte requiredStatId, int requiredAmount)
        {
            RequiredStatTypeId = requiredStatTypeId;
            RequiredStatId     = requiredStatId;
            RequiredAmount     = requiredAmount;
        }
    }
}