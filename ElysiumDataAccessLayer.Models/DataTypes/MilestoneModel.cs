using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class MilestoneModel
    {
        [JsonProperty] public ushort MilestoneId { get; private set; }
        [JsonProperty] public string GlobalObject { get; private set; }
        [JsonProperty] public string MilestoneName { get; private set; }
        [JsonProperty] public uint   RequiredTotal { get; private set; }
        [JsonProperty] public string ScriptableObjectPath { get; private set; }

        public MilestoneModel()
        {
            
        }
        
        public MilestoneModel(ushort milestoneId, string globalObjectId, string milestoneName, uint requiredTotal, string scriptableObjectPath)
        {
            MilestoneId          = milestoneId;
            GlobalObject       = globalObjectId;
            MilestoneName        = milestoneName;
            RequiredTotal        = requiredTotal;
            ScriptableObjectPath = scriptableObjectPath;
        }
    }

}

