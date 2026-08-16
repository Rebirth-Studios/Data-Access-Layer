CREATE PROCEDURE [dbo].[spScriptableLootTableRarities]
	
AS
	
SELECT
	sld.globalObject,
	glo.globalObjectName,
	sld.itemGlobalObject,
	glo2.globalObjectName AS 'scriptableItemName',
	sld.dropGlobalObject,
	glo2.globalObjectName AS 'dropScriptableItemName',
	sld.rarityChance,
	sld.rarityId,
	sr.typeName AS rarity
	FROM [content].[scriptableLootTableRarities] sld
	JOIN [content].[globalObjects] glo ON sld.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON sld.itemGlobalObject = glo2.globalObject
	JOIN [content].[globalObjects] glo3 ON sld.dropGlobalObject = glo3.globalObject
	JOIN [content].[scriptableRarities] sr ON sld.rarityId = sr.typeId

GO

