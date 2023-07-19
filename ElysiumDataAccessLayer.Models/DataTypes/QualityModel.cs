namespace RebirthStudios.DataAccessLayer.Models
{
    public class QualityModel
    {
        public byte   QualityId { get; set; }
        public string QualityName { get; set; }
        public float  ValueMultiplier { get; set; }
        public string Description { get; set; }

        public QualityModel()
        {
            
        }
        public QualityModel(byte qualityId, string qualityName, float valueMultiplier, string description)
        {
            QualityId       = qualityId;
            QualityName     = qualityName;
            ValueMultiplier = valueMultiplier;
            Description     = description;
        }
    }
}

