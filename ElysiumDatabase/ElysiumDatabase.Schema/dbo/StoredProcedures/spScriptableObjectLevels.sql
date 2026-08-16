CREATE PROCEDURE [dbo].[spScriptableObjectLevels]
	
AS
	
SELECT
	sol.globalObject,
	sol.levelId,
	sol.scriptableObjectLevel,
	sol.scriptableObjectLevelName,
	glo.globalObjectName,
	sot.typeName AS 'scriptableObjectType'
	FROM [content].[scriptableObjectLevels] sol
	JOIN [content].[globalObjects] glo ON sol.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectTypes] sot ON glo.scriptableObjectTypeId = sot.typeId

GO

