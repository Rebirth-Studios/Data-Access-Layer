using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public abstract class SpawnedObjectModel
    {
        [JsonProperty] public Guid                      SpawnedWorldObjectId { get; set; }
        [JsonProperty] public string                      GlobalObject     { get; set; }
        [JsonProperty] public (float x, float y, float z) Position             { get; set; }
        [JsonProperty] public int                         Chunk                { get; set; }
        [JsonProperty] public (float x, float y, float z) Rotation             { get; set; }
        [JsonProperty] public (float x, float y, float z) Scale             { get; set; }
        [JsonProperty] public string                      PrefabId          { get; set; }
        [JsonProperty] public bool                        IgnoreSpawnTable     { get; set; }
        [JsonProperty] public uint                        LocationId           { get; set; }
        [JsonProperty] public byte                        Rank                 { get; set; }
        [JsonProperty] public byte                      VariationId          { get; set; }

        public SpawnedObjectModel()
        {
            
        }
        public SpawnedObjectModel(Guid spawnedWorldObjectId, string globalObjectCode, float coordinateX, 
            float coordinateY, float coordinateZ, int chunk, float rotationX, float rotationY, float rotationZ, 
            float scaleX, float scaleY, float scaleZ, 
            string prefabId, bool ignoreSpawnTable, uint locationId, byte rank, byte variationId)
        {
            SpawnedWorldObjectId = spawnedWorldObjectId;
            GlobalObject     = globalObjectCode;
            Position             = (coordinateX, coordinateY, coordinateZ);
            Chunk                = chunk;
            Rotation            = (rotationX, rotationY, rotationZ);
            Scale            = (scaleX, scaleY, scaleZ);
            PrefabId = prefabId;
            IgnoreSpawnTable     = ignoreSpawnTable;
            LocationId           = locationId;
            Rank                 = rank;
            VariationId          = variationId;
        }
    }
}