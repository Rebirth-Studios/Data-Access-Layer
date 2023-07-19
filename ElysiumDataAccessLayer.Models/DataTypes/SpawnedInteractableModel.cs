using System;
using System.Numerics;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class SpawnedInteractableModel : SpawnedObjectModel
    {
        [JsonProperty] public byte                        InteractableTypeId   { get; set; }

        public SpawnedInteractableModel(
            Guid spawnedWorldObjectId,
            string globalObjectCode,
            float positionX,
            float positionY,
            float positionZ,
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
            byte interactableTypeId) : 
            base(spawnedWorldObjectId, globalObjectCode, positionX, positionY, positionZ, 
                chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable, locationId, rank, variationId)
        {
            InteractableTypeId   = interactableTypeId;
        }
    }
}

