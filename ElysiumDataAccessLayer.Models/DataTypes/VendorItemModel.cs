using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class VendorItemModel
    {
        [JsonProperty] public ushort ItemId                { get; set; }
        [JsonProperty] public string GlobalObject        { get; set; }
        [JsonProperty] public byte   RarityTypeId          { get; set; }
        [JsonProperty] public uint   GoldValue             { get; set; }
        [JsonProperty] public byte   SilverValue           { get; set; }
        [JsonProperty] public byte   CopperValue           { get; set; }
        [JsonProperty] public ushort AdventuringTokenValue { get; set; }
        [JsonProperty] public ushort CraftingTokenValue    { get; set; }
        [JsonProperty] public ushort GatheringTokenValue   { get; set; }
        [JsonProperty] public byte   MaxStack              { get; set; }
        [JsonProperty] public float  SpawnChance           { get; set; }
        [JsonProperty] public short  MaxStock              { get; set; }
        [JsonProperty] public short  RestockAmount         { get; set; }

        public VendorItemModel()
        {
            
        }
        public VendorItemModel(ushort itemId, string globalObjectId, byte rarityTypeId, uint goldValue, byte silverValue, 
            byte copperValue, ushort adventuringTokenValue, ushort craftingTokenValue, ushort gatheringTokenValue, byte maxStack, float spawnChance, short maxStock, short restockAmount)
        {
            ItemId                = itemId;
            GlobalObject        = globalObjectId;
            RarityTypeId          = rarityTypeId;
            GoldValue             = goldValue;
            SilverValue           = silverValue;
            CopperValue           = copperValue;
            AdventuringTokenValue = adventuringTokenValue;
            CraftingTokenValue    = craftingTokenValue;
            GatheringTokenValue   = gatheringTokenValue;
            MaxStack              = maxStack;
            SpawnChance           = spawnChance;
            MaxStock              = maxStock;
            RestockAmount         = restockAmount;
        }
    }
}

