CREATE PROCEDURE [dbo].[spScriptableLootTableQuantities]
	
AS
	
SELECT
	sld.globalObject,
	glo.globalObjectName,
	sld.itemGlobalObject,
	glo2.globalObjectName AS 'scriptableItemName',
	sld.quantity,
	sld.quantityChance
	FROM [content].[scriptableLootTableQuantities] sld
	JOIN [content].[globalObjects] glo ON sld.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON sld.itemGlobalObject = glo2.globalObject

GO

