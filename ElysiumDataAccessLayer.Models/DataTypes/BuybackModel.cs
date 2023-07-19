using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class BuybackModel
    {
        [JsonProperty] public byte[]?     InstancedItemId { get; set;}
        [JsonProperty] public long? SoldDate { get; set;}
        [JsonProperty] public byte      ItemTypeId { get; set;}

        public BuybackModel()
        {
            
        }
        public BuybackModel(Guid? instancedItemId, DateTime? soldDate, byte itemTypeId)
        {
            InstancedItemId = instancedItemId?.ToByteArray();
            SoldDate        = soldDate?.ToBinary();
            ItemTypeId      = itemTypeId;
        }
    }    
}
