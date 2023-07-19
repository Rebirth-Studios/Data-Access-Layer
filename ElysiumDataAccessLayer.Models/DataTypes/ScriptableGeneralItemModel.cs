using Newtonsoft.Json;
using RebirthStudios.DataAccessLayer.Models;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ScriptableGeneralItemModel : ScriptableItemModel
    {
        [JsonProperty] public byte GeneralItemTypeId               { get; set; }
        [JsonProperty] public byte GeneralItemClassificationTypeId { get; set; }
        [JsonProperty] public byte GeneralItemSubTypeId            { get; set; }
    
        public ScriptableGeneralItemModel(ushort itemId, string globalObjectId, byte globalStatusId, string itemName,
            string globalObjectPath, string itemDescription, float weight, byte maxStack, uint goldValue, byte silverValue, 
            byte copperValue, byte tierId, byte rarityId, byte maxRarityId, byte qualityId, byte maxQualityId, ushort maxDurability, ushort manaCapacity, 
            string prefabFilePath, byte globalObjectTypeId, byte itemTypeId, byte generalItemTypeId, byte generalItemClassificationTypeId, 
            byte generalItemSubTypeId) : base(itemId, 
            globalObjectId, globalStatusId, itemName, globalObjectPath, itemDescription, weight, maxStack, goldValue,
            silverValue, copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability, 
            manaCapacity, prefabFilePath, globalObjectTypeId, itemTypeId)
        {
            GeneralItemTypeId               = generalItemTypeId;
            GeneralItemClassificationTypeId = generalItemClassificationTypeId;
            GeneralItemSubTypeId            = generalItemSubTypeId;
        }
    }
}