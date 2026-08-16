





CREATE PROCEDURE [dbo].[spSpawnablesToPrefabs]
	
AS
	
	SELECT
	stp.globalObject,
	glo.globalObjectName,
	stp.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName,
	stp.levelId,
	stp.variationId,
	stp.prefabPath,
	sr.prefabName
	FROM [content].[spawnablesToPrefabs] stp
	JOIN [content].[globalObjects] glo ON stp.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectSpawnables] sos ON stp.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[scriptablePrefabs] sr ON stp.prefabPath = sr.prefabPath

GO

