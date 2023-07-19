using System.Numerics;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class WeaponPositionModel
    {
        [JsonProperty] public byte                        EquipmentSlotTypeId { get; set; }
        [JsonProperty] public (float x, float y, float z) Position            { get; set; }
        [JsonProperty] public (float x, float y, float z) Rotation            { get; set; }

        public WeaponPositionModel(byte equipmentSlotTypeId, float positionX, float positionY, float positionZ, 
            float                         rotationX,           float rotationY, float rotationZ)
        {
            EquipmentSlotTypeId = equipmentSlotTypeId;
            Position            = (positionX, positionY, positionZ);
            Rotation            = (rotationX, rotationY, rotationZ);
        }
    }  
}

