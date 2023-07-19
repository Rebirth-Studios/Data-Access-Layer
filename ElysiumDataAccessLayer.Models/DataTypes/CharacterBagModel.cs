using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class CharacterBagModel
    {
        [JsonProperty] public Guid InstancedItemId { get; set; }
        [JsonProperty] public int  CharacterBagId  { get; set; }

        public CharacterBagModel()
        {
            
        }
        public CharacterBagModel(Guid instancedItemId, int characterBagId)
        {
            InstancedItemId = instancedItemId;
            CharacterBagId  = characterBagId;
        }
    }    
}
