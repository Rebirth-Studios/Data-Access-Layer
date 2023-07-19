using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class MonsterModel : EntityModel
    {
        [JsonProperty] public byte MonsterTypeId               { get; set; }
        [JsonProperty] public byte MonsterClassificationTypeId { get; set; }
        [JsonProperty] public byte MonsterSubTypeId            { get; set; }

        public MonsterModel()
        {
            
        }
        public MonsterModel(
            ushort entityId, 
            string globalObjectId,
            byte globalStatusId, 
            string entityName, 
            string globalObjectPath,
            byte   tierId,
            byte   globalObjectTypeId,
            byte   worldObjectTypeId, 
            byte   entityTypeId,
            byte   monsterTypeId,
            byte   monsterClassificationTypeId,
            byte   monsterSubTypeId) : base(entityId, globalObjectId, globalStatusId, entityName, 
            globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId, entityTypeId)
        {
            MonsterTypeId               = monsterTypeId;
            MonsterClassificationTypeId = monsterClassificationTypeId; 
            MonsterSubTypeId            = monsterSubTypeId;
        }

    }

}

