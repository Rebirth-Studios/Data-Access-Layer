using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{

    public class QuestLineModel
    {
        [JsonProperty] public string GlobalObject         { get; private set; }
        [JsonProperty] public byte   GlobalStatusId       { get; private set; }
        [JsonProperty] public string ScriptableObjectPath { get; private set; }
        [JsonProperty] public string QuestLineName        { get; private set; }

        public QuestLineModel()
        {
            
        }
        
        public QuestLineModel(string globalObject, byte globalStatusId, string questLineName, string scriptableObjectPath)
        {
            GlobalObject       = globalObject;
            GlobalStatusId     = globalStatusId;
            QuestLineName        = questLineName;
            ScriptableObjectPath = scriptableObjectPath;
        }
    }
    
}
