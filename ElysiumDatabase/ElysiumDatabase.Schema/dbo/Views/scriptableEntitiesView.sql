




CREATE VIEW [dbo].[scriptableEntitiesView] AS 
	
	--ANIMAL
	SELECT
		sit.globalObject,
		it.typeId AS 'entityTypeId', 
		it.type AS 'entityTypeName', 
		COALESCE(sa.animalMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		COALESCE(sa.animalClassificationTypeId, 0) AS 'classificationTypeId', 
		COALESCE(mct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(sa.animalSubTypeId, 0) AS 'subTypeId', 
		COALESCE(mst.typeName, 'None') AS 'subTypeName',
		CASE 
			WHEN subTypeName != 'None' THEN mst.experienceMultiplierPlayer
			WHEN classificationTypeName != 'None' THEN mct.experienceMultiplierPlayer
			WHEN mainTypeName != 'None' THEN mt.experienceMultiplierPlayer
			ELSE 1.00
		END AS 'experienceMultiplierPlayer'
	FROM [content].[scriptableEntities] sit
	JOIN [content].[entityTypes] it ON sit.entityTypeId = it.typeId
	JOIN [content].[scriptableAnimals] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[animalTypes] mt ON sa.animalMainTypeId = mt.typeId
	LEFT JOIN [content].[animalClassificationTypes] mct ON sa.animalClassificationTypeId = mct.typeId
	LEFT JOIN [content].[animalSubTypes] mst ON sa.animalSubTypeId = mst.typeId

	UNION ALL

	--EnemyHumanoid
	SELECT
		sit.globalObject,
		it.typeId AS 'entityTypeId', 
		it.type AS 'entityTypeName',
		COALESCE(sa.enemyHumanoidMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		COALESCE(sa.enemyHumanoidClassificationTypeId, 0) AS 'classificationTypeId', 
		COALESCE(mct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(sa.enemyHumanoidSubTypeId, 0) AS 'subTypeId', 
		COALESCE(mst.typeName, 'None') AS 'subTypeName',
		CASE 
			WHEN subTypeName != 'None' THEN mst.experienceMultiplierPlayer
			WHEN classificationTypeName != 'None' THEN mct.experienceMultiplierPlayer
			WHEN mainTypeName != 'None' THEN mt.experienceMultiplierPlayer
			ELSE 1.00
		END AS 'experienceMultiplierPlayer'
	FROM [content].[scriptableEntities] sit
	JOIN [content].[entityTypes] it ON sit.entityTypeId = it.typeId
	JOIN [content].[scriptableEnemyHumanoids] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[enemyHumanoidTypes] mt ON sa.enemyHumanoidMainTypeId = mt.typeId
	LEFT JOIN [content].[enemyHumanoidClassificationTypes] mct ON sa.enemyHumanoidClassificationTypeId = mct.typeId
	LEFT JOIN [content].[enemyHumanoidSubTypes] mst ON sa.enemyHumanoidSubTypeId = mst.typeId

	UNION ALL

	--Monster
	SELECT
		sit.globalObject,
		it.typeId AS 'entityTypeId', 
		it.type AS 'entityTypeName',
		COALESCE(sa.monsterMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		COALESCE(sa.monsterClassificationTypeId, 0) AS 'classificationTypeId', 
		COALESCE(mct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(sa.monsterSubTypeId, 0) AS 'subTypeId', 
		COALESCE(mst.typeName, 'None') AS 'subTypeName',
		CASE 
			WHEN subTypeName != 'None' THEN mst.experienceMultiplierPlayer
			WHEN classificationTypeName != 'None' THEN mct.experienceMultiplierPlayer
			WHEN mainTypeName != 'None' THEN mt.experienceMultiplierPlayer
			ELSE 1.00
		END AS 'experienceMultiplierPlayer'
	FROM [content].[scriptableEntities] sit
	JOIN [content].[entityTypes] it ON sit.entityTypeId = it.typeId
	JOIN [content].[scriptableMonsters] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[monsterTypes] mt ON sa.monsterMainTypeId = mt.typeId
	LEFT JOIN [content].[monsterClassificationTypes] mct ON sa.monsterClassificationTypeId = mct.typeId
	LEFT JOIN [content].[monsterSubTypes] mst ON sa.monsterSubTypeId = mst.typeId

	UNION ALL

	--NPC
	SELECT
		sit.globalObject,
		it.typeId AS 'entityTypeId', 
		it.type AS 'entityTypeName',
		COALESCE(sa.npcMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		COALESCE(sa.npcClassificationTypeId, 0) AS 'classificationTypeId', 
		COALESCE(mct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(sa.npcSubTypeId, 0) AS 'subTypeId', 
		COALESCE(mst.typeName, 'None') AS 'subTypeName',
		CASE 
			WHEN subTypeName != 'None' THEN mst.experienceMultiplierPlayer
			WHEN classificationTypeName != 'None' THEN mct.experienceMultiplierPlayer
			WHEN mainTypeName != 'None' THEN mt.experienceMultiplierPlayer
			ELSE 1.00
		END AS 'experienceMultiplierPlayer'
	FROM [content].[scriptableEntities] sit
	JOIN [content].[entityTypes] it ON sit.entityTypeId = it.typeId
	JOIN [content].[scriptableNPCS] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[npcTypes] mt ON sa.npcMainTypeId = mt.typeId
	LEFT JOIN [content].[npcClassificationTypes] mct ON sa.npcClassificationTypeId = mct.typeId
	LEFT JOIN [content].[npcSubTypes] mst ON sa.npcSubTypeId = mst.typeId
	
	UNION

	--UNHANDLED ENTITY TYPES
	SELECT
		sit.globalObject,
		it.typeId AS 'entityTypeId', 
		it.type AS 'entityTypeName',
		0 AS 'mainTypeId', 
		'None' AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subTypeName',
		'1.00' AS 'experienceMultiplierPlayer'
	FROM [content].[scriptableEntities] sit
	JOIN [content].[entityTypes] it ON sit.entityTypeId = it.typeId
	WHERE sit.entityTypeId NOT IN (1, 2, 3, 4)

GO

