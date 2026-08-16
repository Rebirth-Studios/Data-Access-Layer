CREATE PROCEDURE [dbo].[SaveGameObjectTypes]
   @gameObjectTypesDtl dbo.tmpgameObjectTypes READONLY
AS 
BEGIN
   SET NOCOUNT ON 

   INSERT INTO [content].[gameObjectTypes](description, parentEnum, parentTypeId, childEnum, globalObjectNamingType, unitTestScenarioMethod)
   SELECT description, parentEnum, parentTypeId, childEnum, globalObjectNamingType, unitTestScenarioMethod FROM @gameObjectTypesDtl
ORDER BY description
END

GO

