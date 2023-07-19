using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public sealed class SpawnedContainerModel : SpawnedInteractableModel
    {
        [JsonProperty] public byte ContainerTypeId { get; set; }

        public SpawnedContainerModel(Guid spawnedWorldObjectId, string globalObjectCode, float coordinateX, float coordinateY,
            float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, 
            float scaleZ, string prefabId, bool ignoreSpawnTable, uint locationId, byte rank, byte variationId, byte interactableTypeId, 
            byte containerTypeId) : base(spawnedWorldObjectId, globalObjectCode, coordinateX, coordinateY, 
            coordinateZ, chunk, rotationX, rotationY, rotationZ, scaleX, scaleY, scaleZ, prefabId, ignoreSpawnTable,
            locationId, rank, variationId, interactableTypeId)
        {
            ContainerTypeId = containerTypeId;
        }
    } 
}

