using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class GatherableModel : InteractableModel
    {
        [JsonProperty] public byte   RequiredTier                  { get; set; }
        [JsonProperty] public byte   RequiredLevel                  { get; set; }
        [JsonProperty] public byte   GatherTypeId                   { get; set; }
        [JsonProperty] public byte   GatherableTypeId               { get; set; }
        [JsonProperty] public byte   GatherableMainTypeId { get; set; }
        [JsonProperty] public byte   GatherableClassificationTypeId { get; set; }
        [JsonProperty] public byte   GatherableSubTypeId            { get; set; }
        [JsonProperty] public byte   RequiredWeaponTypeId           { get; set; }
        [JsonProperty] public int    RequiredToolPower              { get; set; }
        [JsonProperty] public int    MaxToolPowerBonus              { get; set; }

        public GatherableModel() : base()
        {
            
        }
        
        public GatherableModel(
            ushort interactableId,
            string globalObjectId,
            byte   globalStatusId,
            string interactableName,
            string globalObjectPath,
            byte   tierId,
            byte   globalObjectTypeId, 
            byte   worldObjectTypeId,
            byte   interactableTypeId,
            ushort interactableHealth, 
            bool   immortal,
            string skillGlobalObject,
            byte   requiredTier,
            byte   requiredLevel,
            byte   gatherTypeId,
            byte   gatherableTypeId,
            byte   gatherableClassificationTypeId,
            byte   gatherableSubTypeId,
            byte   requiredWeaponTypeId, 
            int    requiredToolPower, 
            int    maxToolPowerBonus) : 
            base(interactableId, globalObjectId, globalStatusId, interactableName, globalObjectPath, tierId, 
                globalObjectTypeId, worldObjectTypeId, interactableTypeId, interactableHealth, immortal, skillGlobalObject)
        {
            RequiredTier                  = requiredTier;
            RequiredLevel                  = requiredLevel;
            GatherTypeId                   = gatherTypeId;
            GatherableTypeId               = gatherableTypeId;
            GatherableClassificationTypeId = gatherableClassificationTypeId;
            GatherableSubTypeId            = gatherableSubTypeId;
            RequiredWeaponTypeId           = requiredWeaponTypeId;
            RequiredToolPower              = requiredToolPower;
            MaxToolPowerBonus              = maxToolPowerBonus;
        }
    }
}

