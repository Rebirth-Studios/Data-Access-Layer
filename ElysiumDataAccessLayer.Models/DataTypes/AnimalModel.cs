namespace RebirthStudios.DataAccessLayer.Models
{
    public class AnimalModel : EntityModel
    {
        public byte AnimalTypeId               { get; set; }
        public byte AnimalClassificationTypeId { get; set; }
        public byte AnimalSubTypeId            { get; set; }

        public AnimalModel() : base()
        {
            
        }
        
        public AnimalModel(ushort entityId,     string globalObjectId, byte globalStatusId, string entityName,string globalObjectPath,  
            byte                  tierId,       byte   globalObjectTypeId, byte worldObjectTypeId, byte entityTypeId, 
            byte                  animalTypeId, byte   animalClassificationTypeId, byte animalSubTypeId) : 
            base(entityId, globalObjectId, globalStatusId, entityName, globalObjectPath, tierId,
                globalObjectTypeId, worldObjectTypeId, entityTypeId)
        {
            AnimalTypeId               = animalTypeId;
            AnimalClassificationTypeId = animalClassificationTypeId;
            AnimalSubTypeId            = animalSubTypeId;
        }
    }
    
}

