namespace RebirthStudios.DataAccessLayer.Models
{
    public class QuestBoardModel : InteractableModel
    {
        public QuestBoardModel()
        {
            
        }
        public QuestBoardModel(ushort interactableId, string globalObjectId,
            byte globalStatusId, string interactableName, string globalObjectPath, byte tierId, byte globalObjectTypeId, byte worldObjectTypeId, byte interactableTypeId,
            ushort interactableHealth, bool immortal, string skillGlobalObject) : base(interactableId, globalObjectId, 
            globalStatusId, interactableName, globalObjectPath, tierId, globalObjectTypeId, worldObjectTypeId, interactableTypeId, 
            interactableHealth, immortal, skillGlobalObject)
        {
        }
    } 
}

