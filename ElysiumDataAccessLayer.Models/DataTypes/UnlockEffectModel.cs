using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
  
    public class UnlockEffectModel
    {
        [JsonProperty] public string UnlockGlobalObject { get; private set; }
        [JsonProperty] public byte   GlobalStatusId     { get; private set; }
        [JsonProperty] public byte   UnlockEffectTypeId { get; private set; }
        [JsonProperty] public byte   UnlockRank         { get; private set; }
        [JsonProperty] public byte   UnlockLevel        { get; private set; }
    
        public UnlockEffectModel(string unlockGlobalObject, byte globalStatusId, byte unlockEffectTypeId, byte unlockRank, byte unlockLevel)
        {
            UnlockGlobalObject = unlockGlobalObject;
            GlobalStatusId     = globalStatusId;
            UnlockEffectTypeId = unlockEffectTypeId;
            UnlockRank         = unlockRank;
            UnlockLevel        = unlockLevel;
        }
    }  
}
