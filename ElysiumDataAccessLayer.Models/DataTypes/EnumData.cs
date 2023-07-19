namespace RebirthStudios.DataAccessLayer.Enums
{
    public class EnumData
    {
        public string  Type            { get; } 
        public string? TypeName        { get; } 
        public string? TypeDescription { get; } 
        public EnumData(string type, string? typeName, string? typeDescription)
        {
            Type            = type;
            TypeName        = typeName;
            TypeDescription = typeDescription;
        }
    }

    public class SubEnumData: EnumData
    {
        public short SubTypeId { get; }
        public SubEnumData(string type, string typeName, string typeDescription, short subTypeId) : base(type, typeName, typeDescription)
        {         
            SubTypeId       = subTypeId;
        }
    }

}

