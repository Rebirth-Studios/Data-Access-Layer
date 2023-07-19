using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ScriptableEquipmentModel: ScriptableItemModel
    {
        [JsonProperty] public int    Defense         { get; set; }
        [JsonProperty] public ushort SkillId         { get; set; }
        [JsonProperty] public byte   EquipmentTypeId { get; set; }
        [JsonProperty] public string EquipEffect     { get; set; }

        public ScriptableEquipmentModel() : base()
        {
            
        }
        
        internal ScriptableEquipmentModel(ushort itemId, string globalObjectPath, string globalObjectId,  byte globalStatusId, string itemName, 
            string itemDescription, float weight, byte maxStack, uint goldValue, byte silverValue, byte copperValue, byte tierId, byte rarityId, byte maxRarityId,
            byte qualityId, byte maxQualityId, ushort maxDurability, ushort manaCapacity, string prefabFilePath, byte globalObjectTypeId, 
            byte itemTypeId, int defense, ushort skillId, byte equipmentTypeId, string equipEffect) : base(itemId, 
            globalObjectId, globalStatusId, itemName, globalObjectPath,itemDescription, weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId,
            maxDurability, manaCapacity, prefabFilePath, globalObjectTypeId, itemTypeId)
        {
            Defense         = defense;
            SkillId         = skillId;
            EquipmentTypeId = equipmentTypeId;
            EquipEffect     = equipEffect;
        }
    }
}

