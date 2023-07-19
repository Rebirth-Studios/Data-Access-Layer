using System;
using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class MailModel
    {
        [JsonProperty] public Guid MailId            { get; set; }
        [JsonProperty] public string  SenderName        { get; set; }
        [JsonProperty] public int?    SenderCharacterId { get; set; }
        [JsonProperty] public string  MailSubject       { get; set; }
        [JsonProperty] public string  MailBody          { get; set; }
        [JsonProperty] public uint    Gold              { get; set; }
        [JsonProperty] public byte    Silver            { get; set; }
        [JsonProperty] public byte    Copper            { get; set; }
        [JsonProperty] public bool    CurrencyClaimed   { get; set; }
        [JsonProperty] public bool    ContentsClaimed   { get; set; }
        [JsonProperty] public bool    Unread            { get; set; }
        [JsonProperty] public long?   SentDateTime      { get; set; }
        [JsonProperty] public long?   AppearDateTime    { get; set; }
        [JsonProperty] public long?   ExpireDataTime    { get; set; }

        public MailModel()
        {
            
        }
        
        public MailModel(Guid mailId, string senderName, int senderCharacterId, string mailSubject, string mailBody, 
            uint              gold, byte silver, byte copper, bool currencyClaimed, bool contentsClaimed, bool unread, 
            DateTime?         sentDateTime, DateTime? appearDateTime, DateTime? expireDataTime)
        {
            MailId            = mailId;
            SenderName        = senderName;
            SenderCharacterId = senderCharacterId;
            MailSubject       = mailSubject;
            MailBody          = mailBody;
            Gold              = gold;
            Silver            = silver;
            Copper            = copper;
            CurrencyClaimed   = currencyClaimed;
            ContentsClaimed   = contentsClaimed;
            Unread            = unread;
            SentDateTime      = sentDateTime?.ToBinary();
            AppearDateTime    = appearDateTime?.ToBinary();
            ExpireDataTime    = expireDataTime?.ToBinary();
        }
    } 
}

