using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class EntityAbilityRank
    {
        [JsonProperty] public byte   Index { get; set; }
        [JsonProperty] public string AbilityGlobalObject { get; set; }
        [JsonProperty] public byte   Rank { get; set; }

        public EntityAbilityRank()
        {
            
        }
        
        public EntityAbilityRank(byte index, string abilityGlobalObject, byte rank)
        {
            Index               = index;
            AbilityGlobalObject = abilityGlobalObject;
            Rank                = rank;
        }
    }   
}

