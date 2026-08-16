



CREATE PROCEDURE [dbo].[spEffectGroupsToObjectsMapping]
	
AS
	SELECT
	egt.effectGroupGlobalObject,
	glo.globalObjectName,
	egt.scriptableObjectLevel,
	sol2.scriptableObjectLevelName,
	sol2.levelId,
	egt.associatedScriptableObjectLevel,
	--associatedLevelId,
	sol.globalObject AS scriptableObjectGlobalObject,
	sol.scriptableObjectLevelName AS associatedScriptableObjectLevelName,
	sol.levelId AS associatedLevelId,
	egt.abilityGlobalObject,
	glo2.globalObjectName AS abilityGlobalObjectName
FROM [content].[effectGroupsToObjectsMapping] egt
JOIN [content].[scriptableObjectLevels] sol ON egt.associatedScriptableObjectLevel = sol.scriptableObjectLevel
JOIN [content].[scriptableObjectLevels] sol2 ON egt.scriptableObjectLevel = sol2.scriptableObjectLevel
JOIN [content].[globalObjects] glo ON egt.effectGroupGlobalObject = glo.globalObject 
JOIN [content].[globalObjects] glo2 ON sol.globalObject = glo2.globalObject

GO

