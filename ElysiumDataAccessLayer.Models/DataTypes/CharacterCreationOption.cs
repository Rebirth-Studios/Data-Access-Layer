using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace RebirthStudios.DataAccessLayer.Models
{
    public readonly struct CharacterCreationOption
    {
        public readonly string StyleName;
        public readonly string StylePath;

        public CharacterCreationOption(string styleName, string stylePath)
        {
            StyleName = styleName;
            StylePath = stylePath;
        }
    }
}
