using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class AbilityRankModel
    {
        [JsonProperty] public byte   RankIndex;
        [JsonProperty] public string RankName;
        [JsonProperty] public byte   ActivationTypeId;
        [JsonProperty] public bool   ActivateWhileMoving;
        [JsonProperty] public bool   DamageCancels;
        [JsonProperty] public float  CastTime;
        [JsonProperty] public byte   EffectCostTypeId;
        [JsonProperty] public byte   EffectCostStatId;
        [JsonProperty] public byte   EffectCostStatTypeId;
        [JsonProperty] public int    Duration;
        [JsonProperty] public int    Cost;
        [JsonProperty] public int    Cooldown;

        [JsonProperty] public ushort StatusEffectId;
        [JsonProperty]   public string AbilityRankGlobalObjectName;

        public AbilityRankModel(
            byte   rankIndex,
            string rankName,
            byte   activationTypeId, 
            bool   activateWhileMoving,
            bool   damageCancels,
            float  castTime,
            byte   effectCostTypeId,
            byte   effectCostStatId,
            byte   effectCostStatTypeId,
            int    duration,
            int    cost,
            int    cooldown,
            ushort statusEffectId,
            string abilityRankGlobalObjectName)
        {
            RankIndex                   = rankIndex;
            RankName                    = rankName;
            ActivationTypeId            = activationTypeId;
            ActivateWhileMoving         = activateWhileMoving;
            DamageCancels               = damageCancels;
            CastTime                    = castTime;
            EffectCostTypeId            = effectCostTypeId;
            EffectCostStatId            = effectCostStatId;
            EffectCostStatTypeId        = effectCostStatTypeId;
            Duration                    = duration;
            Cost                        = cost;
            Cooldown                    = cooldown;
            StatusEffectId              = statusEffectId;
            AbilityRankGlobalObjectName = abilityRankGlobalObjectName;
        }
    }
}
