CREATE PROCEDURE [dbo].[RestoreGameObjectTypes]
   @gameObjectTypesDtl dbo.tmpRestoregameObjectTypes READONLY
AS 
BEGIN
   SET NOCOUNT ON 

   INSERT INTO [content].[gameObjectTypes](description, parentEnum, parentTypeId, childEnum, globalObjectNamingType, unitTestScenarioMethod)
   SELECT description, parentEnum, parentTypeId, childEnum, globalObjectNamingType, unitTestScenarioMethod FROM @gameObjectTypesDtl
END

GO

