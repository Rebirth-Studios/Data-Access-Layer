




CREATE PROCEDURE [dbo].[spSpawnablesToLootTables]
	
AS
	SELECT
	stl.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	stl.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	stl.allowedRolls,
	stl.minCurrencyReward,
	stl.maxCurrencyReward,
	stl.lootTableGlobalObject,
	glo2.globalObjectName AS 'lootTableGlobalObjectName',
	stl.additionalQuantityInherited,
	stl.additionalRarityInherited,
	sol.levelId AS 'levelId',
	sos.variationId AS 'variationId',
	0 AS 'experienceTotalSkill',
	(gtv.experienceMultiplierPlayer * gt.experienceInitialValue * eit.experienceMultiplierPlayer * edt.experienceMultiplierPlayer * el.experienceMultiplierPlayer) AS 'experienceTotalPlayer',
	(edt.additionalRarity + eit.additionalRarity) AS 'additionalRarity',
	wot.typeName AS 'worldObjectTypeName',
	edt.additionalQuantity AS 'additionalQuantity',
	0 AS 'skillRequired'
	FROM [content].[spawnablesToLootTables] stl
	JOIN [content].[globalObjects] glo ON stl.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[scriptableObjectSpawnables] sos ON stl.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[experienceLevels] el ON sol.levelId = el.levelId
	JOIN [content].[scriptableWorldObjects] swo ON stl.globalObject = swo.globalObject
	JOIN [content].[worldObjectTypes] wot ON swo.worldObjectTypeId = wot.typeId
	JOIN [content].[scriptableEntities] se ON stl.globalObject = se.globalObject
	JOIN [content].[scriptableAnimals] sa ON stl.globalObject = sa.globalObject
	JOIN [content].[scriptableEntitiesVariations] sev ON sos.variationId = sev.variationId AND se.entityTypeId = sev.entityTypeId
	JOIN [content].[entityDifficultyTypes] edt ON sev.entityDifficultyTypeId = edt.typeId
	JOIN [content].[entityImbuedTypes] eit ON sev.entityImbuedTypeId = eit.typeId
	JOIN scriptableEntitiesView gtv ON sa.globalObject = gtv.globalObject

	UNION

	--ENTITY: ENEMY HUMANOID
	SELECT
	stl.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	stl.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	stl.allowedRolls,
	stl.minCurrencyReward,
	stl.maxCurrencyReward,
	stl.lootTableGlobalObject,
	glo2.globalObjectName AS 'lootTableGlobalObjectName',
	stl.additionalQuantityInherited,
	stl.additionalRarityInherited,
	sol.levelId AS 'levelId',
	sos.variationId AS 'variationId',
	0 AS 'experienceTotalSkill',
	(gtv.experienceMultiplierPlayer * gt.experienceInitialValue * eit.experienceMultiplierPlayer * edt.experienceMultiplierPlayer * el.experienceMultiplierPlayer) AS 'experienceTotalPlayer',
	(edt.additionalRarity + eit.additionalRarity) AS 'additionalRarity',
	wot.typeName AS 'worldObjectTypeName',
	edt.additionalQuantity AS 'additionalQuantity',
	0 AS 'skillRequired'
	FROM [content].[spawnablesToLootTables] stl
	JOIN [content].[globalObjects] glo ON stl.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[scriptableObjectSpawnables] sos ON stl.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[experienceLevels] el ON sol.levelId = el.levelId
	JOIN [content].[scriptableWorldObjects] swo ON stl.globalObject = swo.globalObject
	JOIN [content].[worldObjectTypes] wot ON swo.worldObjectTypeId = wot.typeId
	JOIN [content].[scriptableEntities] se ON stl.globalObject = se.globalObject
	JOIN [content].[scriptableEnemyHumanoids] sa ON stl.globalObject = sa.globalObject
	JOIN [content].[scriptableEntitiesVariations] sev ON sos.variationId = sev.variationId AND se.entityTypeId = sev.entityTypeId
	JOIN [content].[entityDifficultyTypes] edt ON sev.entityDifficultyTypeId = edt.typeId
	JOIN [content].[entityImbuedTypes] eit ON sev.entityImbuedTypeId = eit.typeId
	JOIN scriptableEntitiesView gtv ON sa.globalObject = gtv.globalObject

	UNION

	--ENTITY: MONSTER
	SELECT
	stl.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	stl.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	stl.allowedRolls,
	stl.minCurrencyReward,
	stl.maxCurrencyReward,
	stl.lootTableGlobalObject,
	glo2.globalObjectName AS 'lootTableGlobalObjectName',
	stl.additionalQuantityInherited,
	stl.additionalRarityInherited,
	sol.levelId AS 'levelId',
	sos.variationId AS 'variationId',
	0 AS 'experienceTotalSkill',
	(gtv.experienceMultiplierPlayer * gt.experienceInitialValue * eit.experienceMultiplierPlayer * edt.experienceMultiplierPlayer * el.experienceMultiplierPlayer) AS 'experienceTotalPlayer',
	(edt.additionalRarity + eit.additionalRarity) AS 'additionalRarity',
	wot.typeName AS 'worldObjectTypeName',
	edt.additionalQuantity AS 'additionalQuantity',
	0 AS 'skillRequired'
	FROM [content].[spawnablesToLootTables] stl
	JOIN [content].[globalObjects] glo ON stl.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[scriptableObjectSpawnables] sos ON stl.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[experienceLevels] el ON sol.levelId = el.levelId
	JOIN [content].[scriptableWorldObjects] swo ON stl.globalObject = swo.globalObject
	JOIN [content].[worldObjectTypes] wot ON swo.worldObjectTypeId = wot.typeId
	JOIN [content].[scriptableEntities] se ON stl.globalObject = se.globalObject
	JOIN [content].[scriptableMonsters] sa ON stl.globalObject = sa.globalObject
	JOIN [content].[scriptableEntitiesVariations] sev ON sos.variationId = sev.variationId AND se.entityTypeId = sev.entityTypeId
	JOIN [content].[entityDifficultyTypes] edt ON sev.entityDifficultyTypeId = edt.typeId
	JOIN [content].[entityImbuedTypes] eit ON sev.entityImbuedTypeId = eit.typeId
	JOIN scriptableEntitiesView gtv ON sa.globalObject = gtv.globalObject
	UNION

	--ENTITY: NPC
	SELECT
	stl.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	stl.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	stl.allowedRolls,
	stl.minCurrencyReward,
	stl.maxCurrencyReward,
	stl.lootTableGlobalObject,
	glo2.globalObjectName AS 'lootTableGlobalObjectName',
	stl.additionalQuantityInherited,
	stl.additionalRarityInherited,
	sol.levelId AS 'levelId',
	sos.variationId AS 'variationId',
	0 AS 'experienceTotalSkill',
	(gtv.experienceMultiplierPlayer * gt.experienceInitialValue * eit.experienceMultiplierPlayer * edt.experienceMultiplierPlayer * el.experienceMultiplierPlayer) AS 'experienceTotalPlayer',
	(edt.additionalRarity + eit.additionalRarity) AS 'additionalRarity',
	wot.typeName AS 'worldObjectTypeName',
	edt.additionalQuantity AS 'additionalQuantity',
	0 AS 'skillRequired'
	FROM [content].[spawnablesToLootTables] stl
	JOIN [content].[globalObjects] glo ON stl.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[scriptableObjectSpawnables] sos ON stl.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[experienceLevels] el ON sol.levelId = el.levelId
	JOIN [content].[scriptableWorldObjects] swo ON stl.globalObject = swo.globalObject
	JOIN [content].[worldObjectTypes] wot ON swo.worldObjectTypeId = wot.typeId
	JOIN [content].[scriptableEntities] se ON stl.globalObject = se.globalObject
	JOIN [content].[scriptableNPCS] sa ON stl.globalObject = sa.globalObject
	LEFT JOIN [content].[npcTypes] mt ON sa.npcMainTypeId = mt.typeId
	LEFT JOIN [content].[npcClassificationTypes] mct ON sa.npcClassificationTypeId = mct.typeId
	LEFT JOIN [content].[npcSubTypes] mst ON sa.npcSubTypeId = mst.typeId
	JOIN [content].[scriptableEntitiesVariations] sev ON sos.variationId = sev.variationId AND se.entityTypeId = sev.entityTypeId
	JOIN [content].[entityDifficultyTypes] edt ON sev.entityDifficultyTypeId = edt.typeId
	JOIN [content].[entityImbuedTypes] eit ON sev.entityImbuedTypeId = eit.typeId
	JOIN scriptableEntitiesView gtv ON sa.globalObject = gtv.globalObject

	UNION

	--CONTAINERS
	SELECT
	stl.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	stl.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	stl.allowedRolls,
	stl.minCurrencyReward,
	stl.maxCurrencyReward,
	stl.lootTableGlobalObject,
	glo2.globalObjectName AS 'lootTableGlobalObjectName',
	stl.additionalQuantityInherited,
	stl.additionalRarityInherited,
	sol.levelId AS 'levelId',
	sos.variationId AS 'variationId',
	(sct.experienceBaseSkill * gtv.experienceMultiplierSkill * ((cqt.experienceMultiplierSkill - 1) + (cit.experienceMultiplierSkill - 1) + (crt.experienceMultiplierSkill - 1) + 1)) AS 'experienceTotalSkill',
	(sct.experienceBasePlayer * gtv.experienceMultiplierPlayer * ((cqt.experienceMultiplierPlayer - 1) + (cit.experienceMultiplierPlayer - 1) + (crt.experienceMultiplierPlayer - 1) + 1)) AS 'experienceTotalPlayer',
	(crt.additionalRarity + cit.additionalRarity) AS 'additionalRarity',
	wot.typeName AS 'worldObjectTypeName',
	cqt.additionalQuantity AS 'additionalQuantity',
	(crt.additionalSkillRequired + cit.additionalSkillRequired + cqt.additionalSkillRequired) AS 'skillRequired'
	FROM [content].[spawnablesToLootTables] stl
	JOIN [content].[globalObjects] glo ON stl.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[scriptableObjectSpawnables] sos ON stl.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[experienceLevels] el ON sol.levelId = el.levelId
	JOIN [content].[scriptableWorldObjects] swo ON stl.globalObject = swo.globalObject
	JOIN [content].[worldObjectTypes] wot ON swo.worldObjectTypeId = wot.typeId
	JOIN [content].[scriptableInteractables] si ON stl.globalObject = si.globalObject
	JOIN [content].[scriptableSkills] ss ON si.interactableRequiredSkillGlobalObject = ss.globalObject
	JOIN [content].[skillCategoryTypes] sct ON ss.skillCategoryTypeId = sct.typeId
	JOIN [content].[scriptableContainers] sc ON stl.globalObject = sc.globalObject
	JOIN [content].[scriptableContainersVariations] scv ON sos.variationId = scv.variationId AND sc.containerMainTypeId = scv.containerTypeId
	JOIN [content].[containerImbuedTypes] cit ON scv.containerImbuedTypeId = cit.typeId
	JOIN [content].[containerRarityTypes] crt ON scv.containerRarityTypeId = crt.typeId
	JOIN [content].[containerQuantityTypes] cqt ON scv.containerQuantityTypeId = cqt.typeId
	JOIN containerTypesView gtv ON sc.containerMainTypeId  = gtv.mainTypeId AND sc.containerClassificationTypeId = gtv.classificationTypeId AND sc.containerSubTypeId = gtv.subTypeId

	UNION

	--INTERACTABLE: GATHERABLE
	SELECT
	stl.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	stl.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	stl.allowedRolls,
	stl.minCurrencyReward,
	stl.maxCurrencyReward,
	stl.lootTableGlobalObject,
	glo2.globalObjectName AS 'lootTableGlobalObjectName',
	stl.additionalQuantityInherited,
	stl.additionalRarityInherited,
	sol.levelId AS 'levelId',
	sos.variationId AS 'variationId',
	(sct.experienceBaseSkill * gtv.experienceMultiplierSkill * ((gqt.experienceMultiplierSkill - 1) + (git.experienceMultiplierSkill - 1) + (glt.experienceMultiplierSkill - 1) + 1)) AS 'experienceTotalSkill',
	(sct.experienceBasePlayer * gtv.experienceMultiplierPlayer * ((gqt.experienceMultiplierPlayer - 1) + (git.experienceMultiplierPlayer - 1) + (glt.experienceMultiplierPlayer - 1) + 1)) AS 'experienceTotalPlayer',
	(glt.additionalRarity + git.additionalRarity) AS 'additionalRarity',
	wot.typeName AS 'worldObjectTypeName',
	gqt.additionalQuantity AS 'additionalQuantity',
	(glt.additionalSkillRequired + git.additionalSkillRequired + gqt.additionalSkillRequired) AS 'skillRequired'
	FROM [content].[spawnablesToLootTables] stl
	JOIN [content].[globalObjects] glo ON stl.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[scriptableObjectSpawnables] sos ON stl.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[experienceLevels] el ON sol.levelId = el.levelId
	JOIN [content].[scriptableWorldObjects] swo ON stl.globalObject = swo.globalObject
	JOIN [content].[worldObjectTypes] wot ON swo.worldObjectTypeId = wot.typeId
	JOIN [content].[scriptableInteractables] si ON stl.globalObject = si.globalObject
	JOIN [content].[scriptableSkills] ss ON si.interactableRequiredSkillGlobalObject = ss.globalObject
	JOIN [content].[skillCategoryTypes] sct ON ss.skillCategoryTypeId = sct.typeId
	JOIN [content].[scriptableGatherables] sg ON stl.globalObject = sg.globalObject
	JOIN [content].[scriptableGatherablesVariations] sgv ON sos.variationId = sgv.variationId AND sg.gatherableTypeId = sgv.gatherableTypeId
	JOIN [content].[gatherableImbuedTypes] git ON sgv.gatherableImbuedTypeId = git.typeId
	JOIN [content].[gatherableLocationTypes] glt ON sgv.gatherableLocationTypeId = glt.typeId
	JOIN [content].[gatherableQuantityTypes] gqt ON sgv.gatherableQuantityTypeId = gqt.typeId
	JOIN gatherableTypesView gtv ON sg.gatherableTypeId = gtv.mainTypeId AND sg.gatherableClassificationTypeId = gtv.classificationTypeId AND sg.gatherableSubTypeId = gtv.subTypeId
	
	UNION

	--REMAINING
	SELECT
	stl.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	stl.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	stl.allowedRolls,
	stl.minCurrencyReward,
	stl.maxCurrencyReward,
	stl.lootTableGlobalObject,
	glo2.globalObjectName AS 'lootTableGlobalObjectName',
	stl.additionalQuantityInherited,
	stl.additionalRarityInherited,
	sol.levelId AS 'levelId',
	sos.variationId AS 'variationId',
	0 AS 'experienceTotalSkill',
	0 AS 'experienceTotalPlayer',
	0 AS 'additionalRarity',
	wot.typeName AS 'worldObjectTypeName',
	0 AS 'additionalQuantity',
	0 AS 'skillRequired'
	FROM [content].[spawnablesToLootTables] stl
	JOIN [content].[globalObjects] glo ON stl.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[scriptableObjectSpawnables] sos ON stl.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[experienceLevels] el ON sol.levelId = el.levelId
	JOIN [content].[scriptableWorldObjects] swo ON stl.globalObject = swo.globalObject
	JOIN [content].[worldObjectTypes] wot ON swo.worldObjectTypeId = wot.typeId
	JOIN [content].[scriptableInteractables] si ON stl.globalObject = si.globalObject
	JOIN [content].[interactableTypes] it ON si.interactableTypeId = it.typeId
	WHERE it.type NOT IN ('Gatherable', 'Container')

GO

