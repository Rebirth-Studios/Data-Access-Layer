using System;

namespace RebirthStudios.DataAccessLayer.Models
{
    [Serializable]
    public class LocationModel: IEquatable<LocationModel>
    {
        public uint                        locationId;
        public (float x, float y, float z) position;
        public (float x, float y, float z) eulerAngles;
        public (float x, float y, float z) scale;
        public int                         chunk = 0;
        public string                      prefabId;
        public bool                        ignoreSpawnTable;
        public byte                        rankId;
        public byte                      variationId;

        public string baseGlobalObject;
        public LocationModel(
            uint                        locationId,  
            string                      baseGlobalObject,
            (float x, float y, float z) position, 
            (float x, float y, float z) eulerAngles,
            (float x, float y, float z) scale,
            int                         chunk, 
            string                      prefabId,
            bool                        ignoreSpawnTable,
            byte                        rankId,
            byte                        variationId)
        {
            this.locationId       = locationId;
            this.baseGlobalObject = baseGlobalObject;
            this.position         = position;
            this.eulerAngles      = eulerAngles;
            this.scale            = scale;
            this.chunk            = chunk;
            this.prefabId      = prefabId;
            this.ignoreSpawnTable = ignoreSpawnTable;
            this.rankId           = rankId;
            this.variationId           = variationId;
        }
        public bool Equals(LocationModel other)
        {
            if (other == null) return false;
            
            var positionEquals = Math.Abs(position.x - other.position.x) < 0.1 && Math.Abs(position.y - other.position.y) < 0.1 && Math.Abs(position.z - other.position.z) < 0.1;
            var rotationEquals = Math.Abs(eulerAngles.x - other.eulerAngles.x) < 0.1 && Math.Abs(eulerAngles.y - other.eulerAngles.y) < 0.1 && Math.Abs(eulerAngles.z - other.eulerAngles.z) < 0.1;
            return chunk == other.chunk && positionEquals && rotationEquals && variationId == other.variationId &&
                   ignoreSpawnTable == other.ignoreSpawnTable;
        }

        public override string ToString()
        {
            return $"Position: {position}, EulerAngles: {eulerAngles}, Chunk: {chunk}, VariationId: {variationId}, IgnoreSpawnTable: {ignoreSpawnTable}";
        }
    }
}