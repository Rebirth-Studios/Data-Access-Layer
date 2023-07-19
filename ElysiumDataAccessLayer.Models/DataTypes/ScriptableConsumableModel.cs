using Newtonsoft.Json;
using RebirthStudios.DataAccessLayer.Models;

public class ScriptableConsumableModel : ScriptableItemModel
{
    [JsonProperty] public byte   ConsumableMainTypeId { get; set; }
    [JsonProperty] public byte   ConsumableClassificationTypeId { get; set; }
    [JsonProperty] public byte   ConsumableSubTypeId { get; set; }
    [JsonProperty] public string UseEffect { get; set; }
    
    public ScriptableConsumableModel(ushort itemId, string globalObjectPath, string globalObjectId,  byte globalStatusId, string itemName, 
        string itemDescription, float weight, byte maxStack, uint goldValue, byte silverValue, byte copperValue, byte tierId, byte rarityId, byte maxRarityId,
        byte qualityId, byte maxQualityId, ushort maxDurability, ushort manaCapacity, string prefabFilePath, byte globalObjectTypeId, 
        byte itemTypeId, byte consumableMainTypeId, byte consumableClassificationTypeId, byte consumableSubTypeId, string useEffect) : 
        base(itemId, globalObjectId, globalStatusId, itemName, globalObjectPath, itemDescription, weight, maxStack, goldValue, silverValue,
            copperValue, tierId, rarityId, maxRarityId, qualityId, maxQualityId, maxDurability, manaCapacity, prefabFilePath, globalObjectTypeId, itemTypeId)
    {
        ConsumableMainTypeId           = consumableMainTypeId;
        ConsumableClassificationTypeId = consumableClassificationTypeId;
        ConsumableSubTypeId            = consumableSubTypeId;
        UseEffect                      = useEffect;
    }
}