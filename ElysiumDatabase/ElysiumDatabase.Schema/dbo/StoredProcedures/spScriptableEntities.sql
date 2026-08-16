CREATE PROCEDURE [dbo].[spScriptableEntities]
	
AS
	
SELECT
	se.globalObject,
	glo.globalObjectName,
	se.entityTypeId,
	et.typeName AS 'entityTypeName'
	FROM [content].[scriptableEntities] se
	JOIN [content].[globalObjects] glo ON se.globalObject = glo.globalObject
	JOIN [content].[entityTypes] et ON se.entityTypeId = et.typeId

GO

