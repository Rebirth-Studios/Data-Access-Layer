using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class StatModel
    {
        [JsonProperty] public byte  StatTypeId {get; set; }
        [JsonProperty] public byte  StatId     {get; set; }
        [JsonProperty] public float StatValue  {get; set; }
        [JsonProperty] public float MinValue  {get; set; }
        [JsonProperty] public float MaxValue  {get; set; }

        public StatModel()
        {
            
        }
        public StatModel(byte statTypeId, byte statId, float statValue, float minValue, float maxValue)
        {
            StatTypeId = statTypeId;
            StatId     = statId;
            StatValue  = statValue;
            MinValue   = minValue;
            MaxValue   = maxValue;
        }
    }
}

