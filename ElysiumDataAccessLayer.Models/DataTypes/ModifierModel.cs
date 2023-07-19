using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ModifierModel
    {
        [JsonProperty] public byte  ModifierTypeId { get; set; }
        [JsonProperty] public float ModifierValue  { get; set; }

        public ModifierModel()
        {
            
        }
        public ModifierModel(byte modifierTypeId, float modifierValue)
        {
            ModifierTypeId = modifierTypeId;
            ModifierValue  = modifierValue;
        }
    }
}