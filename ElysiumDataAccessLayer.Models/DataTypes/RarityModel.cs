using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class RarityModel
    {
        [JsonProperty] public byte   RarityId        { get; set; }
        [JsonProperty] public string RarityName      { get; set; }
        [JsonProperty] public float  ValueMultiplier { get; set; }
        [JsonProperty] public string RarityColor     { get; set; }
        [JsonProperty] public string Description     { get; set; }

        public RarityModel(byte rarityId, string rarityName, float valueMultiplier, string rarityColor, string description)
        {
            RarityId        = rarityId;
            RarityName      = rarityName;
            ValueMultiplier = valueMultiplier;
            RarityColor     = rarityColor;
            Description     = description;
        }
    }
 
}

