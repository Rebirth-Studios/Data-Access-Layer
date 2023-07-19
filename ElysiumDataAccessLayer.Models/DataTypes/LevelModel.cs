using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    
    public class LevelModel
    {
        [JsonProperty] public int ExperienceRequired;
        [JsonProperty] public int MaxExperience;

        public LevelModel()
        {
            
        }
        public LevelModel(int experienceRequired, int maxExperience)
        {
            ExperienceRequired = experienceRequired;
            MaxExperience      = maxExperience;
        }
    }
}
