using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class SpawnTableModel
    {
        [JsonProperty] public string GlobalObject { get; set; }
        [JsonProperty] public byte GlobalStatusId { get; set; }
        [JsonProperty] public string SpawnTableName { get; set; }
        [JsonProperty] public string ScriptableObjectPath { get; set; }
        [JsonProperty] public int    RespawnTime { get; set; }
        [JsonProperty] public byte   GlobalObjectTypeId { get; set; }
        [JsonProperty] public string BaseSpawnableObjectGlobalObject { get; set; }
        

        public SpawnTableModel(string globalObject, byte globalStatusId, string spawnTableName, string scriptableObjectPath, int respawnTime, byte globalObjectTypeId, string baseSpawnableObjectGlobalObjectId)
        {
            GlobalObject                    = globalObject;
            GlobalStatusId                  = globalStatusId;
            SpawnTableName                  = spawnTableName;
            ScriptableObjectPath            = scriptableObjectPath;
            RespawnTime                     = respawnTime;
            GlobalObjectTypeId              = globalObjectTypeId;
            BaseSpawnableObjectGlobalObject = baseSpawnableObjectGlobalObjectId;
        }
    } 
}

