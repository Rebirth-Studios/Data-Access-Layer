using System;
using System.Numerics;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class SpawnedVendorModel : SpawnedEntityModel
    {
        public DateTime? LastRestockTime { get; }

        public SpawnedVendorModel() : base()
        {
            
        }
        
        public SpawnedVendorModel(Guid spawnedWorldObjectId, string globalObject, float positionX, float positionY, float positionZ,
            int chunk, float rotationX, float rotationY, float scaleX, float scaleY, float scaleZ, float rotationZ,
            string prefabId, bool ignoreSpawnTable,
            uint locationId, byte rank, byte variationId, byte entityTypeId, DateTime? lastRestockTime) : 
            base(spawnedWorldObjectId, globalObject, positionX, positionY, positionZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, locationId, rank, variationId, entityTypeId)
        {
            LastRestockTime      = lastRestockTime;
        }
    }

}



