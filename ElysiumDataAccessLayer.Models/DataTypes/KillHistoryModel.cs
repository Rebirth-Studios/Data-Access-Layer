using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class KillHistoryModel
    {
        [JsonProperty] public string EntityGlobalObject { get; set; }

        public KillHistoryModel()
        {
            
        }
        
        public KillHistoryModel(string entityGlobalObjectId)
        {
            EntityGlobalObject = entityGlobalObjectId;
        }
    }
}

