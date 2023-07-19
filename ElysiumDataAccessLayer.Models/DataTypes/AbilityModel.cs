using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class AbilityModel
    {
        [JsonProperty] public ushort AbilityId;
        [JsonProperty] public string GlobalObject;
        [JsonProperty] public byte GlobalStatusId;
        [JsonProperty] public string AbilityName;
        [JsonProperty] public string GlobalObjectPath;
        [JsonProperty] public string AbilityDescription;
        [JsonProperty] public byte   AbilityTier;
        [JsonProperty] public byte   AbilityActivationId;
        [JsonProperty] public byte   GlobalObjectTypeId;

        public AbilityModel(ushort abilityId, string globalObjectId, byte globalStatusId, string globalObjectPath, string abilityName,
            string abilityDescription, byte abilityTier, byte abilityActivationId, byte globalObjectTypeId)
        {
            AbilityId           = abilityId;
            GlobalObject      = globalObjectId;
            GlobalStatusId      = globalStatusId;
            GlobalObjectPath    = globalObjectPath;
            AbilityName         = abilityName;
            AbilityDescription  = abilityDescription;
            AbilityTier         = abilityTier;
            AbilityActivationId = abilityActivationId;
            GlobalObjectTypeId  = globalObjectTypeId;
        }
    }
}

