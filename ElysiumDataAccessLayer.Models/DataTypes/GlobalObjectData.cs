using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class GlobalObjectData : IEquatable<GlobalObjectData>
    {
        [JsonProperty] public string GlobalObject   { get; set; }
        [JsonProperty] public byte   GlobalStatusId { get; set; }

        public GlobalObjectData()
        {
            
        }
        public GlobalObjectData(string globalObject, byte globalStatusId)
        {
            GlobalObject   = globalObject;
            GlobalStatusId = globalStatusId;
        }
        
        public bool Equals(GlobalObjectData? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GlobalObject == other.GlobalObject && GlobalStatusId == other.GlobalStatusId;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GlobalObjectData)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GlobalObject, GlobalStatusId);
        }
    }
}