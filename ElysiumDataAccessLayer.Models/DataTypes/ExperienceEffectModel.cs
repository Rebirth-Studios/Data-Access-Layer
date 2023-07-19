using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class ExperienceEffectModel
    {
        [JsonProperty] public byte ExperienceTypeId;
        [JsonProperty] public int ExperienceGain;

        public ExperienceEffectModel()
        {
            
        }
        
        public ExperienceEffectModel(byte experienceTypeId, int experienceGain)
        {
            ExperienceTypeId = experienceTypeId;
            ExperienceGain   = experienceGain;
        }
    }
}

