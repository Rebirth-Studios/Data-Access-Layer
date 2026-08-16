



CREATE PROCEDURE [dbo].[spAssociatedGlobalObjects]
	
AS

	SELECT 
	mainGameObjectTypeId,
	ago.globalObject, 
	associatedGameObjectTypeId, 
	associatedGlobalObject,
	keyNumber,
	glo.globalObjectName,
	glo2.globalObjectName AS 'associatedGlobalObjectName',
	gt.type AS 'associatedGameObjectType',
	gt2.type AS 'mainGameObjectType'
	FROM [content].[associatedGlobalObjects] ago
	JOIN [content].[globalObjects] glo ON ago.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON ago.associatedGlobalObject = glo2.globalObject
	JOIN [content].[gameObjectTypes] gt ON ago.associatedGameObjectTypeId = gt.typeId
	JOIN [content].[gameObjectTypes] gt2 ON ago.mainGameObjectTypeId = gt2.typeId

GO

