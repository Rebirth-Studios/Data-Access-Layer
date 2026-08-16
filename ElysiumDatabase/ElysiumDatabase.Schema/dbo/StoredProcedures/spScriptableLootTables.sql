

CREATE PROCEDURE [dbo].[spScriptableLootTables]
	
AS

	SELECT 
	slt.globalObject, 
	slt.lootTableTypeId,
	slt.lootTableClassificationTypeId,
	glo.globalObjectName, 
	gt.typeName AS 'globalTier', 
	lt.typeName AS 'mainTypeName', 
	ltc.typeName AS 'classificationTypeName'
	FROM [content].[scriptableLootTables] slt
	JOIN [content].[globalObjects] glo ON slt.globalObject = glo.globalObject
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[lootTableTypes] lt ON slt.lootTableTypeId = lt.typeId
	JOIN [content].[lootTableClassificationTypes] ltc ON slt.lootTableClassificationTypeId = ltc.typeId

GO

