CREATE PROCEDURE [dbo].[spScriptableSpawnTableOptions]
	
AS
	

SELECT
	ssto.globalObject,
	sos.globalObject AS 'worldObjectGlobalObject',
	ssto.scriptableObjectSpawnable,
	ssto.minRange,
	ssto.maxRange,
	ssto.prefabSizeMin,
	ssto.prefabSizeMax,
	ssto.variationId,
	ssto.prefabName,
	pr.prefabPath AS 'prefabFilePath',
	ssto.levelId AS 'levelId',
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	glo.globalObjectName AS 'globalObjectName',
	glo2.globalObjectName AS 'worldObjectGlobalObjectName'
	FROM [content].[scriptableSpawnTableOptions] ssto
	JOIN [content].[globalObjects] glo ON ssto.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectSpawnables] sos ON ssto.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[globalObjects] glo2 ON sos.globalObject = glo2.globalObject
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[scriptablePrefabs] pr ON ssto.prefabName = pr.prefabName

GO

