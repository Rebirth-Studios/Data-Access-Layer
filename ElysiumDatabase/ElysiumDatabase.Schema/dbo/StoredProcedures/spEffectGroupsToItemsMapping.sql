


CREATE PROCEDURE [dbo].[spEffectGroupsToItemsMapping]
	
AS
	SELECT
	egt.effectGroupGlobalObject,
	egt.itemGlobalObject,
	glo.globalObjectName AS itemGlobalObjectName,
	egt.rarityId,
	glo2.globalObjectName AS effectGroupGlobalObjectName,
	sr.typeName AS rarity,
	egl.scriptableObjectLevel,
	sol.scriptableObjectLevelName,
	egt.levelId
FROM [content].[effectGroupsToItemsMapping] egt
JOIN [content].[globalObjects] glo ON egt.itemGlobalObject = glo.globalObject 
JOIN [content].[globalObjects] glo2 ON egt.effectGroupGlobalObject = glo2.globalObject 
JOIN [content].[scriptableRarities] sr ON egt.rarityId = sr.typeId
LEFT JOIN [content].[effectGroupsLevels] egl ON egt.levelId = egl.levelId AND egt.effectGroupGlobalObject = egl.effectGroupGlobalObject
LEFT JOIN [content].[scriptableObjectLevels] sol ON egl.scriptableObjectLevel = sol.scriptableObjectLevel

GO

