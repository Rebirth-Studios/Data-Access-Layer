using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace RebirthStudios.DataAccessLayer.Models
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public struct HexColorModel
    {
        public const int SIZE = sizeof(byte) * 3;
        [FieldOffset(0)]
        public byte R;
    
        [FieldOffset(1)]
        public byte G;
    
        [FieldOffset(2)]
        public byte B;

        public HexColorModel(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
        public unsafe HexColorModel(byte* rgb)
        {
            R = rgb[0];
            G = rgb[1];
            B = rgb[2];
        }
    
        public HexColorModel(string hexColor)
        {
            if (hexColor.IndexOf('#') != -1) hexColor = hexColor.Replace("#", "");
        
            R = byte.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            G = byte.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            B = byte.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
        }
    

        public override string ToString()
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);
        }

        public static HexColorModel FromString(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 6)
                throw new ArgumentException("Hex color must be 6 characters long");

            return new HexColorModel(
                byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber),
                byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber),
                byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber)
            );
        }

        
        public static (byte r, byte g, byte b) ToValueTuple(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 6)
                throw new ArgumentException("Hex color must be 6 characters long");

            return new HexColorModel(
                byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber),
                byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber),
                byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber)
            );
        }
        
        public static implicit operator HexColorModel(string colorHex)
        {
            return new HexColorModel(colorHex);
        }  
        public static implicit operator string(HexColorModel colorHex)
        {
            return colorHex.ToString();
        }
        //
        // public static implicit operator HexColor(Color32 colorHex)
        // {
        //     return new HexColor(colorHex.r, colorHex.g, colorHex.b);
        // }
    
        public static unsafe implicit operator HexColorModel(byte* colorHex) => new HexColorModel(colorHex);

        public static unsafe implicit operator byte*(HexColorModel colorHex)
        {
            var hexColor = stackalloc byte [3] {colorHex.R, colorHex.G, colorHex.B};
            return hexColor;
        }
        
        public static implicit operator (byte r, byte g, byte b) (HexColorModel colorHex)
        {
            var hexColor = (colorHex.R, colorHex.G, colorHex.B);
            return hexColor;
        }
    }
}