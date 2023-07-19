using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    
    public class VendorInventoryData
    {
        public Guid                     VendorSpawnedWorldObjectId { get; set; }
        public List<VendorInventoryModel> Inventory                  { get; set; }
    }
    public class VendorInventoryModel
    {
        [JsonProperty] public ushort ItemId { get; set; }
        [JsonProperty] public byte   RarityId { get; set; }
        [JsonProperty] public byte   CurrentStock { get; set; }

        public VendorInventoryModel()
        {
            
        }
        public VendorInventoryModel(ushort itemId, byte rarityId, byte currentStock)
        {
            this.ItemId       = itemId;
            this.RarityId     = rarityId;
            this.CurrentStock = currentStock;
        }
    }
}
