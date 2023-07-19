using System;
using RebirthStudios.Enums.Items;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class CharacterEquipmentData
    {
        public Guid                                               CharacterId { get; set; }
        public (EquipmentTypes equipmentType, Guid instanceItemId)[] Equipment   { get; set; }
    }
}