using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ScriptableWeaponModel : ScriptableEquipmentModel
    {
        [JsonProperty] public float MinDamage    { get; set; }
        [JsonProperty] public float AttackSpeed  { get; set; }
        [JsonProperty] public byte  WeaponSlotId { get; set; }
        [JsonProperty] public byte  WeaponTypeId { get; set; }
        [JsonProperty] public byte  DamageTypeId { get; set; }

        public ScriptableWeaponModel() : base()
        {
            
        }
        public ScriptableWeaponModel(ushort itemId, string globalObjectPath, string globalObjectId,  byte globalStatusId, string itemName, 
            string itemDescription, float weight, byte maxStack, uint goldValue, byte silverValue, byte copperValue, byte tierId, byte rarityId, byte maxRarityId,
            byte qualityId, byte maxQualityId, ushort maxDurability, ushort manaCapacity, string prefabFilePath, byte globalObjectTypeId,
            byte itemTypeId, int defense, ushort skillId, byte equipmentTypeId, string equipEffect, float minDamage, float attackSpeed,
            byte weaponSlotId, byte weaponTypeId, byte damageTypeId) : base(itemId, globalObjectPath, globalObjectId, globalStatusId, 
            itemName, itemDescription, weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability, 
            manaCapacity, prefabFilePath, globalObjectTypeId, itemTypeId, defense, skillId, equipmentTypeId, equipEffect)
        {
            MinDamage    = minDamage;
            AttackSpeed  = attackSpeed;
            WeaponSlotId = weaponSlotId;
            WeaponTypeId = weaponTypeId;
            DamageTypeId = damageTypeId;
        }
    }

}

