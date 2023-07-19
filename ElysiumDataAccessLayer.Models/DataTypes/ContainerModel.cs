using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ContainerModel : InteractableModel
    {
        [JsonProperty] public string SkillGlobalObjectCode { get; set; }
        [JsonProperty] public byte   RequiredWeaponTypeId  { get; set; } 
        [JsonProperty] public byte   Width                 { get; set; }
        [JsonProperty] public byte   Height                { get; set; }
        [JsonProperty] public byte   ContainerTypeId       { get; set; }

        public ContainerModel() : base()
        {
            
        }
        
        public ContainerModel(
            ushort interactableId,
            string globalObject,
            byte globalStatusId,
            string interactableName,
            string globalObjectPath, 
            byte   tierId,
            byte   globalObjectTypeId,
            byte   worldObjectTypeId,
            byte   interactableTypeId,
            ushort interactableHealth,
            bool   immortal,
            string skillGlobalObject,
            string skillGlobalObjectCode,
            byte   requiredWeaponTypeId,
            byte   width,
            byte   height,
            byte   containerTypeId):
            base(interactableId, globalObject, globalStatusId, interactableName, globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId,
                interactableTypeId, interactableHealth, immortal, skillGlobalObject)
        {
            SkillGlobalObjectCode = skillGlobalObjectCode;
            RequiredWeaponTypeId  = requiredWeaponTypeId;
            Width                 = width;
            Height                = height;
            ContainerTypeId       = containerTypeId;
        }
    }
}

