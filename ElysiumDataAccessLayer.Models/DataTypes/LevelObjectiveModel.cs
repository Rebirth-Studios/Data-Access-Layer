using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class LevelObjectiveModel
    {
        [JsonProperty] public string ObjectiveGlobalObject  { get; set; }
        [JsonProperty] public string ObjectiveName            { get; set; }
        [JsonProperty] public short  RequiredAmount           { get; set; }
        [JsonProperty] public byte   ObjectiveTypeId          { get; set; }
        [JsonProperty] public byte   RankId                   { get; set; }
        [JsonProperty] public byte   LevelId                  { get; set; }

        public LevelObjectiveModel()
        {
            
        }
        public LevelObjectiveModel(string objectiveGlobalObject, string objectiveName, short requiredAmount, 
            byte                           objectiveTypeId,         byte   rankId,        byte  levelId)
        {
            ObjectiveGlobalObject = objectiveGlobalObject;
            ObjectiveName           = objectiveName;
            RequiredAmount          = requiredAmount;
            ObjectiveTypeId         = objectiveTypeId;
            RankId                  = rankId;
            LevelId                 = levelId;
        }
    }
}

