using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public sealed class TitleModel
    {
        [JsonProperty] public ushort TitleId { get; set; }
        [JsonProperty] public string GlobalObject { get; set; }
        [JsonProperty] public string TitleName { get; set; }
        [JsonProperty] public string TitleDescription { get; set; }
        [JsonProperty] public bool   IsUpgradable { get; set; }
        [JsonProperty] public bool   IsUnique { get; set; }

        public TitleModel()
        {
            
        }
        
        public TitleModel(ushort titleId,
            string                 globalObjectId,
            string                 titleName,
            string                 titleDescription,
            bool                   isUpgradable,
            bool                   isUnique)
        {
            TitleId          = titleId;
            GlobalObject   = globalObjectId;
            TitleName        = titleName;
            TitleDescription = titleDescription;
            IsUpgradable     = isUpgradable;
            IsUnique         = isUnique;
        }
    }
}

