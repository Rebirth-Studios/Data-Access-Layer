using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class EnemyHumanoidModel : EntityModel
    {
        [JsonProperty] public byte EnemyHumanoidTypeId               { get; set; }
        [JsonProperty] public byte EnemyHumanoidClassificationTypeId { get; set; }
        [JsonProperty] public byte EnemyHumanoidSubTypeId            { get; set; }

        public EnemyHumanoidModel() : base()
        {
            
        }
        public EnemyHumanoidModel(
            ushort entityId,
            string globalObjectId,
            byte globalStatusId,
            string entityName, 
            string globalObjectPath,
            byte   tierId,
            byte   globalObjectTypeId,
            byte   worldObjectTypeId,
            byte   entityTypeId, 
            byte   enemyHumanoidTypeId,
            byte   enemyHumanoidClassificationTypeId, 
            byte   enemyHumanoidSubTypeId) : base(
            entityId, globalObjectId,globalStatusId, entityName, globalObjectPath,tierId, globalObjectTypeId, worldObjectTypeId, entityTypeId)
        {
        
            EnemyHumanoidTypeId               = enemyHumanoidTypeId;
            EnemyHumanoidClassificationTypeId = enemyHumanoidClassificationTypeId;
            EnemyHumanoidSubTypeId            = enemyHumanoidSubTypeId;
        }
    }
}

