using Newtonsoft.Json;

namespace RebirthStudios.DataAccessLayer.Models
{
    public class SkillModel
    {
        [JsonProperty] public ushort SkillId             { get; private set; }
        [JsonProperty] public string GlobalObject        { get; private set; }
        [JsonProperty] public byte   GlobalStatusId      { get; private set; }
        [JsonProperty] public string GlobalObjectPath    { get; private set; }
        [JsonProperty] public string SkillName           { get; private set; }
        [JsonProperty] public string SkillDescription    { get; private set; }
        [JsonProperty] public byte   SkillCategoryTypeId { get; private set; }
        [JsonProperty] public byte   SkillTierId         { get; private set; }
        [JsonProperty] public byte   SkillTypeId         { get; private set; }
        [JsonProperty] public string BaseSkillPath       { get; private set; }
        [JsonProperty] public byte   GlobalObjectTypeId  { get; private set; }

        public SkillModel()
        {
            
        }
        
        public SkillModel(
            ushort skillId,        
            string globalObject,
            byte globalStatusId,
            string globalObjectPath,
            string skillName, 
            string skillDescription,
            byte   skillCategoryTypeId,
            byte   skillTierId,      
            byte   skillTypeId,
            string baseSkillPath,
            byte   globalObjectTypeId)
        {
            SkillId             = skillId;
            GlobalObject      = globalObject;
            GlobalStatusId      = globalStatusId;
            GlobalObjectPath    = globalObjectPath;
            SkillName           = skillName;
            SkillDescription    = skillDescription;
            SkillCategoryTypeId = skillCategoryTypeId;
            SkillTierId         = skillTierId;
            SkillTypeId         = skillTypeId;
            BaseSkillPath       = baseSkillPath;
            GlobalObjectTypeId  = globalObjectTypeId;
        }
    }
}
