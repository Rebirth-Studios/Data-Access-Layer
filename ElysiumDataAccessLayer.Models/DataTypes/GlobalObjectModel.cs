using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ScriptableObjectModel
    {
        [JsonProperty] public string GlobalObject;
        [JsonProperty] public byte   GlobalStatusId;
        [JsonProperty] public string ScriptableObjectPath;
        [JsonProperty] public string SingularName;
        [JsonProperty] public string PluralName;
        [JsonProperty] public byte   ObjectTypeId;

        public ScriptableObjectModel()
        {
            
        }
        
        public ScriptableObjectModel(string globalObject, byte globalStatusId, string scriptableObjectPath, 
            string singularName, string pluralName, byte objectTypeId)
        {
            GlobalObject   = globalObject;
            GlobalStatusId = globalStatusId;
            ScriptableObjectPath = scriptableObjectPath;
            SingularName     = singularName;
            PluralName       = pluralName;
            ObjectTypeId     = objectTypeId;
        }
    }
}

