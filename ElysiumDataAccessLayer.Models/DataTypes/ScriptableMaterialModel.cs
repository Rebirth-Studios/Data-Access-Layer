using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ScriptableMaterialModel : ScriptableItemModel
    {
        [JsonProperty] public byte   MaterialTypeId               { get; set; }
        [JsonProperty] public byte   MaterialClassificationTypeId { get; set; }
        [JsonProperty] public byte   MaterialSubTypeId            { get; set; }
        [JsonProperty] public string IngredientName               { get; set; }

        public ScriptableMaterialModel(ushort itemId, string globalObjectPath, string globalObjectId,  byte globalStatusId, 
            string itemName, string itemDescription, float weight, byte maxStack, uint goldValue, byte silverValue, byte copperValue, 
            byte tierId, byte rarityId, byte maxRarityId, byte qualityId, byte maxQualityId, ushort maxDurability, ushort manaCapacity, string prefabFilePath,
            byte globalObjectTypeId, byte itemTypeId, byte materialTypeId, byte materialClassificationTypeId, byte materialSubTypeId,
            string ingredientName) : base(itemId, globalObjectId, globalStatusId, itemName, globalObjectPath, 
            itemDescription, weight, maxStack, goldValue, silverValue, copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability,
            manaCapacity, prefabFilePath, globalObjectTypeId, itemTypeId)
        {
            MaterialTypeId               = materialTypeId;
            MaterialClassificationTypeId = materialClassificationTypeId;
            MaterialSubTypeId            = materialSubTypeId;
            IngredientName               = ingredientName;
        }
    }
}