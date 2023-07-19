using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class TotalModel
    {
        [JsonProperty] public ushort TotalId              { get; set; }
        [JsonProperty] public string TotalGlobalObject  { get; set; }
        [JsonProperty] public string TotalName            { get; set; }
        [JsonProperty] public string ScriptableObjectPath { get; set; }

        public TotalModel()
        {
            
        }
        
        public TotalModel(ushort totalId, string totalGlobalObjectId, string totalName, string scriptableObjectPath)
        {
            TotalId              = totalId;
            TotalGlobalObject  = totalGlobalObjectId;
            TotalName            = totalName;
            ScriptableObjectPath = scriptableObjectPath;
        }
    }
}

