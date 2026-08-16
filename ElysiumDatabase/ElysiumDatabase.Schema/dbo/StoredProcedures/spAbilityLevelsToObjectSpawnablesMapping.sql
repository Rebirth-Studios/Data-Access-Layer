




CREATE PROCEDURE [dbo].[spAbilityLevelsToObjectSpawnablesMapping]
	
AS

	SELECT 
	al.abilityGlobalObject,
	sol.scriptableObjectLevel AS 'abilityScriptableObjectLevel',
	sol.scriptableObjectLevelName AS 'abilityScriptableObjectLevelName',
	abilityNumber,
	al.globalObject,
	al.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName,
	sos.variationId,
	glo.globalObjectName AS 'abilityGlobalObjectName',
	glo2.globalObjectName,
	sol2.levelId AS 'objectLevelId',
	sol.levelId AS 'abilityLevelId'
	FROM [content].[abilityLevelsToObjectSpawnablesMapping] al 
	LEFT JOIN [content].[scriptableObjectLevels] sol ON al.abilityScriptableObjectLevel = sol.scriptableObjectLevel
	LEFT JOIN [content].[scriptableObjectSpawnables] sos ON al.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	LEFT JOIN [content].[globalObjects] glo ON sol.globalObject = glo.globalObject
	LEFT JOIN [content].[globalObjects] glo2 ON sos.globalObject = glo2.globalObject
	LEFT JOIN [content].[scriptableObjectLevels] sol2 ON sos.scriptableObjectLevel = sol2.scriptableObjectLevel

GO

