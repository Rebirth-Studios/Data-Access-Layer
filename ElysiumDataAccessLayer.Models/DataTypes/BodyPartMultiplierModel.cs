namespace RebirthStudios.DataAccessLayer.Models
{
    public readonly struct BodyPartMultiplierModel
    {
        public readonly float Multiplier;
        public readonly byte  BodyPartTypeId;
        
        public BodyPartMultiplierModel(float multiplier, byte bodyPartTypeId)
        {
            Multiplier     = multiplier;
            BodyPartTypeId = bodyPartTypeId;
        }
    }
}

