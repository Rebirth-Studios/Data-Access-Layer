using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class SpawnedEntityModel : SpawnedObjectModel
    {
        [JsonProperty] public byte   EntityTypeId { get; set; }


        public SpawnedEntityModel() : base()
        {
            
        }
        public SpawnedEntityModel(
            Guid spawnedWorldObjectId,
            string globalObjectCode,
            float coordinateX, 
            float coordinateY,
            float coordinateZ,
            int chunk,
            float rotationX,
            float rotationY,
            float rotationZ, 
            float scaleX,
            float scaleY,
            float scaleZ, 
            string prefabId,
            bool ignoreSpawnTable,
           uint locationId,
            byte rank,
            byte variationId,
            byte entityTypeId) : 
            base(spawnedWorldObjectId, globalObjectCode, coordinateX, coordinateY, coordinateZ, chunk, rotationX,
                rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, locationId, rank, variationId)
        {
            EntityTypeId         = entityTypeId;
        }
    }
}

