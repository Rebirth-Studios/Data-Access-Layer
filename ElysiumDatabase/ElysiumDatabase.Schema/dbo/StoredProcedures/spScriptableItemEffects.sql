

CREATE PROCEDURE [dbo].[spScriptableItemEffects]
	
AS
	

SELECT
	sir.globalObject,
	sir.effectGlobalObject,
	egl.scriptableObjectLevel,
	sir.rarityId,
	sir.description,
	glo.globalObjectName AS 'globalObjectName',
	glo2.globalObjectName AS 'effectGlobalObjectName',
	sol.scriptableObjectLevelName,
	sir.levelId,
	sr.typeName AS 'rarity'
	FROM [content].[scriptableItemEffects] sir
	JOIN [content].[scriptableRarities] sr ON sir.rarityId = sr.typeId
	JOIN [content].[globalObjects] glo ON sir.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON sir.effectGlobalObject = glo2.globalObject
	JOIN [content].[effectGroupsToItemsMapping] ei ON sir.levelId = ei.levelId AND sir.globalObject = ei.itemGlobalObject
	LEFT JOIN [content].[effectGroupsLevels] egl ON ei.levelId = egl.levelId AND ei.effectGroupGlobalObject = egl.effectGroupGlobalObject
	LEFT JOIN [content].[scriptableObjectLevels] sol ON egl.scriptableObjectLevel = sol.scriptableObjectLevel

GO

