using Newtonsoft.Json;
using RebirthStudios.Enums.Items;

namespace RebirthStudios.DataAccessLayer.Models
{
    public sealed class StatusEffectModel
    {
        [JsonProperty] public ushort           StatusEffectId              { get; private set; }
        [JsonProperty] public string           GlobalObject                { get; private set; }
        [JsonProperty] public byte             GlobalStatusId              { get; private set; }
        [JsonProperty] public string           GlobalObjectPath            { get; private set; }
        [JsonProperty] public string           StatusEffectName            { get; private set; } 
        [JsonProperty] public string           StatusEffectDescription     { get; private set; }
        [JsonProperty] public int              Duration                    { get; private set; }
        [JsonProperty] public short            MaxStacks                   { get; private set; }
        [JsonProperty] public byte             GlobalObjectTypeId          { get; private set; }
        [JsonProperty] public bool             CanceledByDamage            { get; private set; }
        [JsonProperty] public ApplicationTypes ApplicationType             { get; private set; }
        [JsonProperty] public short            NumberOfApplications        { get; private set; }
        [JsonProperty] public float            CooldownBetweenApplications { get; private set; }
        [JsonProperty] public bool             RemoveWhenEffectEnds        { get; private set; }

        public StatusEffectModel()
        {
            
        }
        public StatusEffectModel(ushort statusEffectId, string globalObject, byte globalStatusId, string globalObjectPath, string statusEffectName, 
            string statusEffectDescription, int duration, short maxStacks, byte globalObjectTypeId, bool canceledByDamage, 
            ApplicationTypes applicationType, short numberOfApplications, float cooldownBetweenApplications, bool removeWhenEffectEnds)
        {
            StatusEffectId          = statusEffectId;
            GlobalObjectPath        = globalObjectPath;
            GlobalObject          = globalObject;
            GlobalStatusId          = globalStatusId;
            StatusEffectName        = statusEffectName;
            StatusEffectDescription = statusEffectDescription;
            Duration                = duration;
            MaxStacks               = maxStacks;
            GlobalObjectTypeId      = globalObjectTypeId;

            CanceledByDamage            = canceledByDamage;
            ApplicationType             = applicationType;
            NumberOfApplications        = numberOfApplications;
            CooldownBetweenApplications = cooldownBetweenApplications;
            RemoveWhenEffectEnds        = removeWhenEffectEnds;
        }
    }
}

