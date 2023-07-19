using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
   
    public sealed class VendorModel: EntityModel
    {
        [JsonProperty] public int RestockInterval { get; private set; }

        public VendorModel() : base()
        {
            
        }
        
        public VendorModel(
            ushort entityId,
            string globalObject,
            byte globalStatusId,
            string globalObjectPath,
            string entityName,
            byte   tierId,
            byte   globalObjectTypeId,
            byte   worldObjectTypeId,
            byte   entityTypeId, 
            int    restockInterval) : base(entityId, globalObject, globalStatusId, entityName, globalObjectPath, tierId,
            globalObjectTypeId, worldObjectTypeId, entityTypeId)
        {
            RestockInterval = restockInterval;
        }
    } 
}
