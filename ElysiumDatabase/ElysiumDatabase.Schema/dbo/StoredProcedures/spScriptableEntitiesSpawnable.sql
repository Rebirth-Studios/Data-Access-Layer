

CREATE PROCEDURE [dbo].[spScriptableEntitiesSpawnable]
	
AS
	

SELECT
	ses.globalObject,
	ses.scriptableObjectLevel,
	ses.scriptableObjectSpawnable,
	ses.variationId,
	ses.entityIsStunnable,
	ses.entityCombatTypeId,
	ses.entityTypeId,
	sol.scriptableObjectLevelName,
	ect.typeName AS [entityCombatTypeName],
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	glo.globalObjectName AS 'globalObjectName',
	ses.displayName,
	sol.levelId,
	edt.offsetRelativeLevelId + eit.offsetRelativeLevelId AS 'offsetRelativeLevelIdTotal',
	(edt.additionalRarity + eit.additionalRarity) AS 'additionalRarityTotal',
	edt.additionalQuantity AS 'additionalQuantityTotal',
	et.typeName AS 'entityTypeName',
	COALESCE(glo2.globalObjectName, 'None') AS 'lootTableName',
	eit.typeName AS 'entityImbuedTypeName',
	edt.typeName AS 'entityDifficultyTypeName'
	FROM [content].[scriptableEntitiesSpawnable] ses
	JOIN [content].[globalObjects] glo ON ses.globalObject = glo.globalObject
	LEFT JOIN [content].[spawnablesToLootTables] stl ON ses.scriptableObjectSpawnable = stl.scriptableObjectSpawnable
	LEFT JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	LEFT JOIN [content].[scriptableObjectSpawnables] sos ON ses.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	LEFT JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	LEFT JOIN [content].[scriptableEntities] se ON ses.globalObject = se.globalObject
	LEFT JOIN [content].[scriptableEntitiesVariations] sev ON sos.variationId = sev.variationId AND se.entityTypeId = sev.entityTypeId
	JOIN [content].[entityDifficultyTypes] edt ON sev.entityDifficultyTypeId = edt.typeId
	JOIN [content].[entityImbuedTypes] eit ON sev.entityImbuedTypeId = eit.typeId
	JOIN [content].[entityCombatTypes] ect ON ses.entityCombatTypeId = ect.typeId
	JOIN [content].[entityTypes] et ON ses.entityTypeId = et.typeId

GO

