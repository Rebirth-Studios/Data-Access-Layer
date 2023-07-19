using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ScriptableItemModel
    {
        [JsonProperty] public ushort ItemId             { get; set; }
        [JsonProperty] public string GlobalObject       { get; set; }
        [JsonProperty] public byte   GlobalStatusId     { get; set; }
        [JsonProperty] public string ItemName           { get; set; }
        [JsonProperty] public string GlobalObjectPath   { get; set; }
        [JsonProperty] public string ItemDescription    { get; set; }
        [JsonProperty] public float  Weight             { get; set; }
        [JsonProperty] public byte   Quantity           { get; set; }
        [JsonProperty] public byte   MaxStack           { get; set; }
        [JsonProperty] public uint   GoldValue          { get; set; }
        [JsonProperty] public byte   SilverValue        { get; set; }
        [JsonProperty] public byte   CopperValue        { get; set; }
        [JsonProperty] public byte   TierId           { get; set; }
        [JsonProperty] public byte   RarityId           { get; set; }
        [JsonProperty] public byte   MaxRarityId           { get; set; }
        [JsonProperty] public byte   QualityId          { get; set; }
        [JsonProperty] public byte   MaxQualityId          { get; set; }
        [JsonProperty] public ushort MaxDurability      { get; set; }
        [JsonProperty] public ushort ManaCapacity       { get; set; }
        [JsonProperty] public string PrefabFilePath     { get; set; }
        [JsonProperty] public byte   GlobalObjectTypeId { get; set; }
        [JsonProperty] public byte   ItemTypeId         { get; set; }

        public ScriptableItemModel() 
        {
            
        }
        internal ScriptableItemModel(ushort itemId, string globalObject, byte globalStatusId, string itemName, string globalObjectPath,  
            string itemDescription, float weight, byte maxStack, uint goldValue, byte silverValue, byte copperValue, 
            byte tierId, byte rarityId, byte maxRarityId, byte qualityId, byte maxQualityId, ushort maxDurability, ushort manaCapacity, string prefabFilePath,
            byte globalObjectTypeId, byte itemTypeId)
        {
            ItemId             = itemId;
            GlobalObjectPath   = globalObjectPath;
            GlobalObject     = globalObject;
            GlobalStatusId     = globalStatusId;
            ItemName           = itemName;
            ItemDescription    = itemDescription;
            Weight             = weight;
            Quantity           = 1;
            MaxStack           = maxStack;
            GoldValue          = goldValue;
            SilverValue        = silverValue;
            CopperValue        = copperValue;
            TierId           = tierId;
            RarityId           = rarityId;
            MaxRarityId           = maxRarityId;
            QualityId          = qualityId;
            MaxQualityId          = maxQualityId;
            MaxDurability      = maxDurability;
            ManaCapacity       = manaCapacity;
            PrefabFilePath     = prefabFilePath;
            GlobalObjectTypeId = globalObjectTypeId;
            ItemTypeId         = itemTypeId;
        }
    }
}

