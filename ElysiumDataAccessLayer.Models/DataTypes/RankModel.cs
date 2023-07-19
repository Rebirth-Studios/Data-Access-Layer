using System.Collections.Generic;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class RankModel
    {
        [JsonProperty] public string RankGlobalObjectName  { get; private set; }
        [JsonProperty] public byte   GlobalStatusId        { get; private set; }
        [JsonProperty] public byte   RankId                { get; private set; }
        [JsonProperty] public byte   VariationId                { get; private set; }
        [JsonProperty] public byte   AllowedRolls          { get; private set; }
        [JsonProperty] public string LootTableGlobalObject { get; private set; }
        [JsonProperty] public uint   MinCurrencyReward     { get; private set; }
        [JsonProperty] public uint   MaxCurrencyReward     { get; private set; }
        [JsonProperty] public int    AdditionalQuantity      { get; private set; }
        [JsonProperty] public int    AdditionalRarity      { get; private set; }
        [JsonProperty] public int    ExperienceRewardPlayer      { get; private set; }
        [JsonProperty] public int    ExperienceRewardSkill      { get; private set; }
        [JsonProperty] public int    SkillRequired      { get; private set; }
        [JsonProperty] public byte    DataAttribute      { get; private set; }
        [JsonProperty] public byte    ImbuedType      { get; private set; }
        [JsonProperty] public byte    EntityType      { get; private set; }

        [JsonProperty] public    List<string> PrefabPaths      { get; private set; }

        public RankModel()  
        {
            
        }

        public RankModel(
            string rankGlobalObjectName,
            byte globalStatusId, 
            byte rankId, 
            byte variationId, 
            byte allowedRolls, 
            string lootTablestring, 
            uint                minCurrencyReward,
            uint maxCurrencyReward,
            int experienceRewardPlayer,
            int experienceRewardSkill,
            int skillRequired,
            byte dataAttributeType,
            byte imbuedType,
            byte entityType,
            List<string> prefabPaths)
        {
            RankGlobalObjectName    = rankGlobalObjectName;
            GlobalStatusId    = globalStatusId;
            RankId                  = rankId;
            VariationId                  = variationId;
            AllowedRolls            = allowedRolls;
            LootTableGlobalObject = lootTablestring;
            MinCurrencyReward       = minCurrencyReward;
            MaxCurrencyReward       = maxCurrencyReward;
            ExperienceRewardPlayer        = experienceRewardPlayer;
            ExperienceRewardSkill        = experienceRewardSkill;
            SkillRequired        = skillRequired;
            DataAttribute        = dataAttributeType;
            ImbuedType        = imbuedType;
            EntityType        = entityType;
            PrefabPaths        = prefabPaths;
        }

        internal RankModel(string rankGlobalObjectName, byte rankId)
        {
            RankGlobalObjectName = rankGlobalObjectName;
            RankId               = rankId;
        }
    }
}

