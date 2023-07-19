using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ScriptableArmorModel : ScriptableEquipmentModel
    {
        [JsonProperty] public byte   ArmorSlotTypeId { get; set; }
        [JsonProperty] public byte   ArmorTypeId     { get; set; }
        [JsonProperty] public string ArmorPrefabPath { get; set; }

        public ScriptableArmorModel(ushort itemId, string globalObjectPath, string globalObjectId,  byte globalStatusId, string itemName, 
            string itemDescription, float weight, byte maxStack, uint goldValue, byte silverValue, byte copperValue, byte tierId, byte rarityId, byte maxRarityId,
            byte qualityId, byte maxQualityId, ushort maxDurability, ushort manaCapacity, string prefabFilePath, byte globalObjectTypeId,
            byte itemTypeId, int defense, ushort skillId, byte equipmentTypeId, string equipEffect, byte armorSlotTypeId, 
            byte armorTypeId, string armorPrefabPath) :
            base(itemId, globalObjectPath, globalObjectId, globalStatusId, itemName, itemDescription, weight, maxStack, goldValue, silverValue, 
                copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability, manaCapacity, prefabFilePath, globalObjectTypeId, 
                itemTypeId, defense, skillId, equipmentTypeId, equipEffect)
        {
            ArmorSlotTypeId = armorSlotTypeId;
            ArmorTypeId     = armorTypeId;
            ArmorPrefabPath = armorPrefabPath;
        }
    }
}