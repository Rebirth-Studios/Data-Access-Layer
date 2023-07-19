using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class EntityModel
    {
        [JsonProperty] public ushort EntityId           { get; private set; }
        [JsonProperty] public string GlobalObject     { get; private set; }
        [JsonProperty] public byte GlobalStatusId     { get; private set; }
        [JsonProperty] public string EntityName         { get; private set; }
        [JsonProperty] public string GlobalObjectPath   { get; private set; }
        [JsonProperty] public byte   TierId             { get; private set; }
        [JsonProperty] public byte   GlobalObjectTypeId { get; private set; }
        [JsonProperty] public byte   WorldObjectTypeId  { get; private set; }
        [JsonProperty] public byte   EntityTypeId       { get; private set; }

        public EntityModel()
        {
            
        }
        
        public EntityModel(
            ushort entityId, 
            string globalObjectId,
            byte globalStatusId,
            string entityName, 
            string globalObjectPath,
            byte   tierId,
            byte   globalObjectTypeId,
            byte   worldObjectTypeId,
            byte   entityTypeId)
        {
            EntityId           = entityId;
            GlobalObject       = globalObjectId;
            GlobalStatusId     = globalStatusId;
            EntityName         = entityName;
            GlobalObjectPath   = globalObjectPath;
            TierId             = tierId;
            GlobalObjectTypeId = globalObjectTypeId;
            WorldObjectTypeId  = worldObjectTypeId;
            EntityTypeId       = entityTypeId;
        }
    }
}

