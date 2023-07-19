using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class LootTableModel
    {
        [JsonProperty] public string GlobalObject {get; set; }
        [JsonProperty] public byte GlobalStatusId {get; set; }
        [JsonProperty] public string LootTableName {get; set; }
        [JsonProperty] public string ScriptableObjectPath {get; set; }
        [JsonProperty] public byte   LootTableTypeId {get; set; }
        [JsonProperty] public byte   LootTableSubTypeId {get; set; }
        [JsonProperty] public byte   GlobalObjectTypeId {get; set; }

        public LootTableModel()
        {
            
        }
        
        public LootTableModel(string globalObject, byte globalStatusId, string lootTableName, string scriptableObjectPath, 
            byte lootTableTypeId, byte lootTableSubTypeId, byte globalObjectTypeId)
        {
            GlobalObject         = globalObject;
            GlobalStatusId       = globalStatusId;
            LootTableName        = lootTableName;
            ScriptableObjectPath = scriptableObjectPath;
            LootTableTypeId      = lootTableTypeId;
            LootTableSubTypeId   = lootTableSubTypeId;
            GlobalObjectTypeId   = globalObjectTypeId;
        }
    }  
}

