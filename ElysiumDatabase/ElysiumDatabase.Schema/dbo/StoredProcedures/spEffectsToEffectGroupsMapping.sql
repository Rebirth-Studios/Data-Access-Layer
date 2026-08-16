

CREATE PROCEDURE [dbo].[spEffectsToEffectGroupsMapping]
	
AS
	SELECT
	effectGlobalObject,
	glo.globalObjectName AS effectName,
	effectGroupGlobalObject,
	glo2.globalObjectName AS effectGroupName,
	et.typeName AS effectType,
	ete.scriptableObjectLevel,
	sol.scriptableObjectLevelName,
	sol.levelId
FROM [content].[effectsToEffectGroupsMapping] ete
JOIN [content].[globalObjects] glo ON ete.effectGlobalObject = glo.globalObject 
JOIN [content].[globalObjects] glo2 ON ete.effectGroupGlobalObject = glo2.globalObject 
JOIN [content].[effects] ef ON ete.effectGlobalObject = ef.globalObject
JOIN [content].[effectTypes] et ON ef.effectTypeId = et.typeId
JOIN [content].[scriptableObjectLevels] sol ON ete.scriptableObjectLevel = sol.scriptableObjectLevel

GO

