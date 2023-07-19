using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class SpawnedBagModel: SpawnedItemModel
    {
        [JsonProperty] public byte   BagSize         { get; set; }

        public SpawnedBagModel() : base()
        {
            
        }
        public SpawnedBagModel(Guid instancedItemId, string globalObjectId, byte quantity, byte maxStack, byte rarityId, 
            byte qualityId, float durabilityPercentage, bool wasCrafted, string crafterName, bool wasLooted, byte bagSize):
            base(instancedItemId, globalObjectId, quantity, maxStack, rarityId, qualityId, durabilityPercentage, wasCrafted, 
                crafterName, wasLooted)
        {
            BagSize = bagSize;
        }
    }   


}

