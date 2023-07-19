using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class AwardEffectModel
    {
        [JsonProperty] public string AwardGlobalObject { get; private set; }
        [JsonProperty] public byte   GlobalStatusId    { get; private set; }
        [JsonProperty] public byte   AwardEffectTypeId { get; private set; }

        public AwardEffectModel()
        {
            
        }
        public AwardEffectModel(string awardGlobalObject, byte globalStatusId, byte awardEffectTypeId)
        {
            AwardGlobalObject = awardGlobalObject;
            GlobalStatusId    = globalStatusId;
            AwardEffectTypeId = awardEffectTypeId;
        }
    }    
}
