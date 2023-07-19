using Newtonsoft.Json;

// ReSharper disable once CheckNamespace
namespace RebirthStudios.DataAccessLayer.Models
{
    public class ScriptableJeweleryModel : ScriptableEquipmentModel
    {
        [JsonProperty] public byte JewelerySlotTypeId { get; set;}
        [JsonProperty] public byte JeweleryTypeId { get; set;}

        public ScriptableJeweleryModel(ushort itemId, string globalObjectPath, string globalObjectId, byte globalStatusId, 
            string itemName, string itemDescription, float weight, byte maxStack, uint goldValue, byte silverValue, 
            byte copperValue, byte tierId, byte rarityId, byte maxRarityId, byte qualityId, byte maxQualityId, ushort maxDurability, ushort manaCapacity, string prefabFilePath, 
            byte globalObjectTypeId, byte itemTypeId, int defense, ushort skillId, byte equipmentTypeId, 
            string equipEffect, byte jewelerySlotTypeId, byte jeweleryTypeId) : base(itemId, globalObjectPath, globalObjectId, 
            globalStatusId, itemName, itemDescription, weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId,
            qualityId, maxQualityId, maxDurability, manaCapacity, prefabFilePath, globalObjectTypeId, itemTypeId, defense,
            skillId, equipmentTypeId, equipEffect)
        {
            JewelerySlotTypeId = jewelerySlotTypeId;
            JeweleryTypeId     = jeweleryTypeId;
        }
    }

}

