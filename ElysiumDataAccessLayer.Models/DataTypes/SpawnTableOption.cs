using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class SpawnTableOption
    {
       [JsonProperty] public string SpawnableObjectPath { get; set; }
       [JsonProperty] public byte   RankId { get; set; }
       [JsonProperty] public byte   VariationId { get; set; }
       [JsonProperty] public int    MinRange { get; set; }
       [JsonProperty] public int    MaxRange { get; set; }

       public SpawnTableOption()
       {
           
       }
       
       public SpawnTableOption(string spawnableObjectPath, byte rankId, byte variationId, int minRange, int maxRange)
       {
            SpawnableObjectPath = spawnableObjectPath;
            RankId              = rankId;
            VariationId              = variationId;
            MinRange            = minRange;
            MaxRange            = maxRange;
       }
    }  
}
