using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class SpawnedItemModel
    {
        [JsonProperty] public Guid InstancedItemId      { get; private set; }
        [JsonProperty] public string GlobalObject         { get; private set; }
        [JsonProperty] public byte   Quantity             { get; private set; }
        [JsonProperty] public byte   MaxStack             { get; private set; }
        [JsonProperty] public byte   RarityId             { get; private set; }
        [JsonProperty] public byte   QualityId            { get; private set; }
        [JsonProperty] public float  DurabilityPercentage { get; private set; }
        [JsonProperty] public bool   WasCrafted           { get; private set; }
        [JsonProperty] public string CrafterName          { get; private set; }
        [JsonProperty] public bool   WasLooted            { get; private set; }

        public SpawnedItemModel()
        {
            
        }
        public SpawnedItemModel(Guid instancedItemId, string globalObjectId, byte quantity, byte maxStack, byte rarityId, byte qualityId, 
            float                        durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted)
        {
            InstancedItemId      = instancedItemId;
            GlobalObject       = globalObjectId;
            Quantity             = quantity;
            MaxStack             = maxStack;
            RarityId             = rarityId;
            QualityId            = qualityId;
            DurabilityPercentage = durabilityPercentage;
            WasCrafted           = wasCrafted;
            CrafterName          = crafterName;
            WasLooted            = wasLooted;
        }
    } 
}

