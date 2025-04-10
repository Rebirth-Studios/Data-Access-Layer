using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class StatEffectModel
    {
        [JsonProperty] public byte EffectSubType { get; set; }
        [JsonProperty] public byte StatId { get; set; }
        [JsonProperty] public byte ValueType { get; set; }
        [JsonProperty] public decimal  Value { get; set; }

        public StatEffectModel(byte effectSubType, byte statId, byte valueType, decimal value)
        {
            EffectSubType = effectSubType;
            StatId        = statId;
            ValueType     = valueType;
            Value         = value;
        }
    }
}

