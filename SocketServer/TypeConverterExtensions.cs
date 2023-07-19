using System.Text;
using RebirthStudios.DataAccessLayer.Models;

internal static class TypeConverterExtensions
{
    public static byte ToByte(this byte[] bytes)
    {
        return bytes[0];
    }
    public static bool ToBool(this byte[] bytes)
    {
        return BitConverter.ToBoolean(bytes);
    }
    public static short ToInt16(this byte[] bytes)
    {
        return BitConverter.ToInt16(bytes);
    }
    public static int ToInt32(this byte[] bytes)
    {
        return BitConverter.ToInt32(bytes);
    }
    public static long ToInt64(this byte[] bytes)
    {
        return BitConverter.ToInt64(bytes);
    }

    public static string ToStr(this byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }
    
    public static byte[] ToBytes(this byte[] value)
    {
        return value;
    }
}