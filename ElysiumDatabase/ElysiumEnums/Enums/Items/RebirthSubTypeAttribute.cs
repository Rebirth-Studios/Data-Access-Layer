using System;

namespace RebirthStudios.Enums
{
    [AttributeUsage(System.AttributeTargets.Field,AllowMultiple = true)]
    public sealed class RebirthSubTypeAttribute : Attribute
    {
        private byte subTypeId;
        public RebirthSubTypeAttribute() : this(0)
        {
        }

        public RebirthSubTypeAttribute(byte subTypeId) => this.subTypeId = subTypeId;

        public byte SubTypeId => this.subTypeId;
    }
    [AttributeUsage(AttributeTargets.Field,AllowMultiple = true)]
    public sealed class RebirthNameAttribute : Attribute
    {
        private string name;
        public RebirthNameAttribute() : this(string.Empty)
        {
        }

        public RebirthNameAttribute(string name) => this.name = name;

        public string Name => this.name;
    }
    [AttributeUsage(System.AttributeTargets.Field,AllowMultiple = true)]
    public sealed class RebirthColumnAttribute : Attribute
    {
        private string column;
        public RebirthColumnAttribute() : this(string.Empty)
        {
        }

        public RebirthColumnAttribute(string column) => this.column = column;

        public string Column => this.column;
    }
    [AttributeUsage(System.AttributeTargets.Field,AllowMultiple = true)]
    public sealed class RebirthDescriptionAttribute : Attribute
    {
        private string description;
        public RebirthDescriptionAttribute() : this(string.Empty)
        {
        }

        public RebirthDescriptionAttribute(string description) => this.description = description;

        public string Description => this.description;
    }
    [AttributeUsage(System.AttributeTargets.Field,AllowMultiple = true)]
    public sealed class RebirthAbbreviationAttribute : Attribute
    {
        private string description;
        public RebirthAbbreviationAttribute() : this(string.Empty)
        {
        }

        public RebirthAbbreviationAttribute(string description) => this.description = description;

        public string Description => this.description;
    }
    [AttributeUsage(System.AttributeTargets.Enum,AllowMultiple = false)]
    public sealed class RebirthChildEnumAttribute : Attribute
    {
        private Type type;
        public RebirthChildEnumAttribute() : this(default)
        {
        }

        public RebirthChildEnumAttribute(Type type) => this.type = type;

        public Type Type => this.type;
    }
}