namespace RebirthStudios.DataAccessLayer.Models
{
    public readonly struct BodyPartPathModel
    {
        public readonly string BodyPartPath;
        public readonly byte   BodyPartTypeId;
        
        public BodyPartPathModel(string bodyPartPath, byte bodyPartTypeId)
        {
            BodyPartPath   = bodyPartPath;
            BodyPartTypeId = bodyPartTypeId;
        }
    }
}

