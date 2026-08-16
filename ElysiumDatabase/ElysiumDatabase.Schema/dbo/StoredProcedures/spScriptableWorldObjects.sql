CREATE PROCEDURE [dbo].[spScriptableWorldObjects]
	
AS
	

SELECT
	swo.globalObject,
	swo.worldObjectTypeId,
	swo.isImmortal,
	glo.globalObjectName AS 'globalObjectName',
	sot.typeName AS 'scriptableObjectTypeName',
	wot.typeName AS 'worldObjectTypeName'
	FROM [content].[scriptableWorldObjects] swo
	JOIN [content].[globalObjects] glo ON swo.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectTypes] sot ON glo.scriptableObjectTypeId = sot.typeId
	JOIN [content].[worldObjectTypes] wot on swo.worldObjectTypeId = wot.typeId

GO

