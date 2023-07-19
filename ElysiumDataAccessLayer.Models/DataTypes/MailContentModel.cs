using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class MailContentModel
    {
        [JsonProperty] public byte SlotIndex {get; set; }
        [JsonProperty] public byte[] InstancedItemId {get; set; }
        [JsonProperty] public bool Claimed {get; set; }
        [JsonProperty] public byte ItemTypeId {get; set; }

        public MailContentModel()
        {
            
        }
        public MailContentModel(byte slotIndex, Guid instancedItemId, bool claimed, byte itemTypeId)
        {
            SlotIndex       = slotIndex;
            InstancedItemId = instancedItemId.ToByteArray();
            Claimed         = claimed;
            ItemTypeId      = itemTypeId;
        }
    }
}

