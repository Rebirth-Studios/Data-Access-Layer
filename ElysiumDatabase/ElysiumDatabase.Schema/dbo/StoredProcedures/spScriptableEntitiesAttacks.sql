CREATE PROCEDURE [dbo].[spScriptableEntitiesAttacks]
	
AS
	
SELECT
	sea.globalObject,
	sea.attackGlobalObject,
	glo.globalObjectName,
	glo2.globalObjectName AS 'attackGlobalObjectName',
	sea.variationId,
	sea.abilityNumber
	FROM [content].[scriptableEntitiesAttacks] sea
	JOIN [content].[globalObjects] glo ON sea.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON sea.attackGlobalObject = glo2.globalObject

GO

