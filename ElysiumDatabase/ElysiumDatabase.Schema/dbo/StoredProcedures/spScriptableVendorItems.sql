

CREATE PROCEDURE [dbo].[spScriptableVendorItems]
	
AS
	SELECT 
	svi.scriptableVendorItemId,
	svi.npcGlobalObject,
	svi.itemGlobalObject,
	svi.rarityId,
	svi.price_money_gold,
	svi.price_money_silver,
	svi.price_money_copper,
	svi.price_token_adventuring,
	svi.price_token_crafting,
	svi.price_token_gathering,
	svi.tierAvailableId,
	svi.maxStock,
	svi.restockAmt,
	svi.spawnChance,
	glo.globalObjectName, 
	glo2.globalObjectName AS 'itemGlobalObjectName',
	gt.typeName AS 'tierAvailable',
	sr.typeName AS 'rarity'
	FROM [content].[scriptableVendorItems] svi
	JOIN [content].[globalObjects] glo ON svi.npcGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON svi.itemGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON svi.tierAvailableId = gt.typeId
	JOIN [content].[scriptableRarities] sr ON svi.rarityId = sr.typeId

GO

