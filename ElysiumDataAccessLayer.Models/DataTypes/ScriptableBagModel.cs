
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public sealed class ScriptableBagModel: ScriptableItemModel
    {
        [JsonProperty] public byte   BaseSize { get; set; }
        [JsonProperty] public byte   BagTypeId { get; set; }
        [JsonProperty] public string EquipText { get; set; }
    
        public ScriptableBagModel(ushort itemId, string globalObjectPath, string globalObjectId, byte globalStatusId, string itemName, 
            string itemDescription, float weight, byte maxStack, uint goldValue, byte silverValue, byte copperValue, 
            byte tierId, byte rarityId, byte maxRarityId, byte qualityId, byte maxQualityId, ushort maxDurability, ushort manaCapacity, string prefabFilePath, 
            byte globalObjectTypeId, byte itemTypeId, byte baseSize, byte bagTypeId, string equipText) : 
            base(itemId, globalObjectId, globalStatusId, itemName, globalObjectPath, itemDescription, weight, maxStack, goldValue, silverValue, 
                copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability, manaCapacity, prefabFilePath, globalObjectTypeId, 
                itemTypeId)
        {
            BaseSize  = baseSize;
            BagTypeId = bagTypeId;
            EquipText = equipText;
        }
    }
}

