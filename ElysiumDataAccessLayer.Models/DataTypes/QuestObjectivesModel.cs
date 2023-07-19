
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class QuestObjectivesModel
    {
        [JsonProperty] public string GlobalObject { get; private set; }
        [JsonProperty] public byte   QuestCategoryTypeId { get; private set; }
        [JsonProperty] public byte   QuestSubTypeId { get; private set; }
        [JsonProperty] public byte   QuestRankId { get; private set; }
        [JsonProperty] public float  ObjectiveValue { get; private set; }
        [JsonProperty] public string SingularName { get; private set; }
        [JsonProperty] public string PluralName { get; private set; }

        public QuestObjectivesModel()
        {
            
        }
        internal QuestObjectivesModel(string globalObject, byte questCategoryTypeId, byte questSubTypeId, byte questRankId, float objectiveValue, string singularName, string pluralName)
        {
            GlobalObject      = globalObject;
            QuestCategoryTypeId = questCategoryTypeId;
            QuestSubTypeId      = questSubTypeId;
            QuestRankId         = questRankId;
            ObjectiveValue      = objectiveValue;
            SingularName        = singularName;
            PluralName          = pluralName;
        }
    }
}

