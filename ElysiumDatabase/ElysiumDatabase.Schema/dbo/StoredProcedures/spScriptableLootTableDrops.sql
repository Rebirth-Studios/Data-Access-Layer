CREATE PROCEDURE [dbo].[spScriptableLootTableDrops]
	
AS
	
SELECT
	sld.globalObject,
	glo.globalObjectName,
	sld.itemGlobalObject,
	glo2.globalObjectName AS 'scriptableItemName',
	sld.recipeGlobalObject,
	glo3.globalObjectName AS 'recipeName',
	sld.dropChance,
	sld.qualityId,
	sq.typeName AS 'quality'
	--lt.typeName
	--ltc.typeName AS ''
	FROM [content].[scriptableLootTableDrops] sld
	JOIN [content].[globalObjects] glo ON sld.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON sld.itemGlobalObject = glo2.globalObject
	JOIN [content].[globalObjects] glo3 ON sld.recipeGlobalObject = glo3.globalObject
	JOIN [content].[scriptableQualities] sq ON sld.qualityId = sq.typeId

GO

