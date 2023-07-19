using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class CharacterStatusEffectData
    {
        public string EffectGroupGlobalObject { get; set; } 
        public float RemainingDuration { get; set; } 
        public byte Stacks { get; set; }

        public CharacterStatusEffectData(string effectGroupGlobalObject, float remainingDuration, byte stacks)
        {
            EffectGroupGlobalObject = effectGroupGlobalObject;
            RemainingDuration       = remainingDuration;
            Stacks                  = stacks;
        }
    }
    public class SpawnedEquipmentModel : SpawnedItemModel
    {
        [JsonProperty] public byte EquipmentType { get; set; }

        public SpawnedEquipmentModel() : base()
        {
            
        }
        public SpawnedEquipmentModel(Guid instancedItemId, string globalObjectId, byte quantity, byte maxStack, byte rarityId, byte qualityId, 
            float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, byte equipmentType):
            base(instancedItemId, globalObjectId, quantity, maxStack, rarityId, qualityId, durabilityPercentage, wasCrafted, crafterName, wasLooted)
        {
            EquipmentType = equipmentType;
        }
    }  
}

