using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class MissionRankModel
    { 
        [JsonProperty] public byte MissionRankType { get; set; }
        [JsonProperty] public byte MissionTierType { get; set; }
        [JsonProperty] public int  MinDifficultyPoints { get; set; }
        [JsonProperty] public int  MaxDifficultyPoints { get; set; }

        public MissionRankModel()
        {
            
        }

        internal MissionRankModel(byte missionRankType, byte missionTierType, int minDifficultyPoints, int maxDifficultyPoints)
        {
            MissionRankType     = missionRankType;
            MissionTierType     = missionTierType;
            MinDifficultyPoints = minDifficultyPoints;
            MaxDifficultyPoints = maxDifficultyPoints;
        }
    }
}

