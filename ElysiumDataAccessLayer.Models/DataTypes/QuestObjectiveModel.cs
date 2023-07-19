using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class QuestObjectiveModel
    {
        [JsonProperty] public string GlobalObject                  { get; private set; }
        [JsonProperty] public string ObjectiveScriptableObjectPath { get; private set; }
        [JsonProperty] public string ObjectiveName                 { get; private set; }
        [JsonProperty] public short  CurrentProgress               { get; private set; }
        [JsonProperty] public short  RequiredAmount                { get; private set; }
        [JsonProperty] public byte   ObjectiveTypeId               { get; private set; }
        
        public QuestObjectiveModel(string globalObjectId,
            string                         objectiveScriptableObjectPath,
            string                         objectiveName,
            short                          currentProgress,
            short                          requiredAmount,
            byte                           objectiveTypeId)
        {
            GlobalObject                = globalObjectId;
            ObjectiveScriptableObjectPath = objectiveScriptableObjectPath;
            ObjectiveName                 = objectiveName;
            CurrentProgress               = currentProgress;
            RequiredAmount                = requiredAmount;
            ObjectiveTypeId               = objectiveTypeId;
        }
    }
}

