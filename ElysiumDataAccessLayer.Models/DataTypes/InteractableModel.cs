using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class InteractableModel
    {
        [JsonProperty] public ushort InteractableId     { get; private set; }
        [JsonProperty] public string GlobalObject       { get; private set; }
        [JsonProperty] public byte   GlobalStatusId     { get; private set; }
        [JsonProperty] public string InteractableName   { get; private set; }
        [JsonProperty] public string GlobalObjectPath   { get; private set; }
        [JsonProperty] public byte   TierId             { get; private set; }
        [JsonProperty] public byte   GlobalObjectTypeId { get; private set; }
        [JsonProperty] public byte   WorldObjectTypeId  { get; private set; }
        [JsonProperty] public byte   InteractableTypeId { get; private set; }
        [JsonProperty] public ushort InteractableHealth { get; private set; }
        [JsonProperty] public bool   Immortal           { get; private set; }
        [JsonProperty] public string   SkillGlobalObject           { get; private set; }

        public InteractableModel()
        {
            
        }
        
        public InteractableModel(
            ushort interactableId,
            string globalObject,
            byte   globalStatusId,
            string interactableName,
            string globalObjectPath,
            byte   tierId, 
            byte   globalObjectTypeId,
            byte   worldObjectTypeId,
            byte   interactableTypeId,
            ushort interactableHealth,
            bool   immortal,
            string skillGlobalObject)
        {
            GlobalObjectPath   = globalObjectPath;
            GlobalObject     = globalObject;
            GlobalStatusId     = globalStatusId;
            InteractableId     = interactableId;
            InteractableName   = interactableName;
            TierId             = tierId;
            GlobalObjectTypeId = globalObjectTypeId;
            WorldObjectTypeId  = worldObjectTypeId;
            InteractableTypeId = interactableTypeId;
            InteractableHealth = interactableHealth;
            Immortal           = immortal;
            SkillGlobalObject           = skillGlobalObject;
        }
    }
}

