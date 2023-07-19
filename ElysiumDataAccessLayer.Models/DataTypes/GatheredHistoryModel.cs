using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    
    public class GatheredHistoryModel
    {
        [JsonProperty] public string GatherableGlobalObject { get; set; }
        [JsonProperty] public byte RankId { get; set; }
        [JsonProperty] public byte VariationId { get; set; }

        public GatheredHistoryModel()
        {
            
        }
        
        public GatheredHistoryModel(string gatherableGlobalObjectId, byte rankId, byte variationId)
        {
            GatherableGlobalObject = gatherableGlobalObjectId;
            RankId = rankId;
            VariationId = variationId;
        }
    }
}
