using System;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class CharacterBagsData
    {
        public Guid                 CharacterId   { get; set; }
        public CharacterBagModel?[] CharacterBags { get; set; }
    }
}