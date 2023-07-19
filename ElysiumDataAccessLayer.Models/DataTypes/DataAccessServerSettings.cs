namespace RebirthStudios.DataAccessLayer.Models
{
    public class DataAccessServerSettings
    {
        public string ipAddress         = "127.0.0.1";
        public int    port              = 9090;
        public byte   copperValue       = 1;
        public byte   silverValue       = 10;
        public int    goldValue         = 100;
        public byte   maxBags           = 5;
        public byte   maxPlayerBuybacks = 14;
        public byte   maxCharacters = 5;
        public bool   socketProfiling   = true;
        public bool   sqlProfiling      = true;
    }
}