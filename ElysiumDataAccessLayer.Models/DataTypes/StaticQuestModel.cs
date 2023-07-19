using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class StaticQuestModel
{
    [JsonProperty] public ushort QuestId                           { get; set; }
    [JsonProperty] public string GlobalObject                    { get; set; }
    [JsonProperty] public string QuestName                         { get; set; }
    [JsonProperty] public string QuestScriptableObjectPath         { get; set; }
    [JsonProperty] public string QuestLineGlobalObject           { get; set; }
    [JsonProperty] public byte   QuestCategoryTypeId               { get; set; }
    [JsonProperty] public byte   QuestTypeId                       { get; set; }
    [JsonProperty] public byte   QuestSubTierId                    { get; set; }
    [JsonProperty] public byte   TierAvailable                     { get; set; }
    [JsonProperty] public string GuaranteedLootTableGlobalObject { get; set; }
    [JsonProperty] public byte   GuaranteedItems                   { get; set; }
    [JsonProperty] public string OptionalLootTableGlobalObject   { get; set; }
    [JsonProperty] public byte   Options                           { get; set; }
    [JsonProperty] public uint   GoldReward                        { get; set; }
    [JsonProperty] public byte   SilverReward                      { get; set; }
    [JsonProperty] public byte   CopperReward                      { get; set; }
    [JsonProperty] public int   ExperienceReward                  { get; set; }
    [JsonProperty] public string QuestDescription                  { get; set; }
    [JsonProperty] public string QuestObjectiveDescription         { get; set; }
    [JsonProperty] public string QuestCompletionDescription        { get; set; }
    [JsonProperty] public bool   Shareable                         { get; set; }
    [JsonProperty] public string QuestGiverName                    { get; set; }

    public StaticQuestModel()
    {
        
    }
    
    public StaticQuestModel(ushort questId, string globalObjectId, string questName, 
        string questScriptableObjectPath, string questLineGlobalObjectId, byte questCategoryTypeId,
        byte questTypeId, byte questSubTierId, byte tierAvailable, string guaranteedLootTableGlobalObjectId, 
        byte guaranteedItems, string optionalLootTableGlobalObjectId, byte options, uint goldReward, 
        byte silverReward, byte copperReward, int experienceReward, string questDescription, 
        string questObjectiveDescription, string questCompletionDescription, bool shareable, string questGiverName)
    {
        QuestId                           = questId;
        GlobalObject                    = globalObjectId;
        QuestName                         = questName;
        QuestScriptableObjectPath         = questScriptableObjectPath;
        QuestLineGlobalObject           = questLineGlobalObjectId;
        QuestCategoryTypeId               = questCategoryTypeId;
        QuestTypeId                       = questTypeId;
        QuestSubTierId                    = questSubTierId;
        TierAvailable                     = tierAvailable;
        GuaranteedLootTableGlobalObject = guaranteedLootTableGlobalObjectId;
        GuaranteedItems                   = guaranteedItems;
        OptionalLootTableGlobalObject   = optionalLootTableGlobalObjectId;
        Options                           = options;
        GoldReward                        = goldReward;
        SilverReward                      = silverReward;
        CopperReward                      = copperReward;
        ExperienceReward                  = experienceReward;
        QuestDescription                  = questDescription;
        QuestObjectiveDescription         = questObjectiveDescription;
        QuestCompletionDescription        = questCompletionDescription;
        Shareable                         = shareable;
        QuestGiverName                    = questGiverName;
    }
}

}



