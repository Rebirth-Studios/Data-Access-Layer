CREATE PROCEDURE [dbo].[spScriptableLootTablesToLootTable]
	
AS
	
SELECT
	sld.globalObject,
	glo.globalObjectName,
	sld.inheritedLootTableGlobalObject,
	glo2.globalObjectName AS 'inheritedLootTable'
	FROM [content].[scriptableLootTablesToLootTable] sld
	JOIN [content].[globalObjects] glo ON sld.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON sld.inheritedLootTableGlobalObject = glo2.globalObject

GO

