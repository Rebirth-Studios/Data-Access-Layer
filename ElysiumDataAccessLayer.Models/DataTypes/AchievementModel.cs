using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class AchievementModel
    {
        [JsonProperty] public ushort AchievementId          { get; set; }
        [JsonProperty] public string GlobalObject         { get; set; }
        [JsonProperty] public string AchievementName        { get; set; }
        [JsonProperty] public string AchievementDescription { get; set; }
        [JsonProperty] public bool   IsUnique               { get; set; }
        [JsonProperty] public string ScriptableObjectPath   { get; set; }

        public AchievementModel(
            ushort achievementId,
            string globalObject,
            string achievementName,
            string achievementDescription,
            bool   isUnique,
            string scriptableObjectPath)
        {
            AchievementId               = achievementId;
            GlobalObject         = globalObject;
            AchievementName        = achievementName;
            AchievementDescription = achievementDescription;
            IsUnique               = isUnique;
            ScriptableObjectPath   = scriptableObjectPath;
        }
    }

}

