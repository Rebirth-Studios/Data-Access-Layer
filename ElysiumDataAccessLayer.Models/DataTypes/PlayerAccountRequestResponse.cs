namespace ElysiumDataAccessLayer.Models.DataTypes
{
    public class PlayerAccountRequestResponse
    {
        public bool    success;
        public string errorMessage;
        public bool?   admin;
        public int?    accountId;
    }
}