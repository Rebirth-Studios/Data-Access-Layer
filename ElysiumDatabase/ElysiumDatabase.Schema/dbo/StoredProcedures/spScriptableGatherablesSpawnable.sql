

CREATE PROCEDURE [dbo].[spScriptableGatherablesSpawnable]
	
AS
	SELECT
	sgs.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	sgs.scriptableObjectLevel,
	sol.scriptableObjectLevelName AS 'scriptableObjectLevelName',
	sgs.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	sol.levelId,
	sgs.variationId,
	sgs.requiredPower,
	sgs.maxToolPower,
	sgs.gatherableTypeId,
	gt.typeName AS 'gatherableTypeName',
	sol.levelId AS 'levelId',
	sos.variationId AS 'variationId',
	sct.experienceBasePlayer AS 'experiencePlayerBase',
	(sct.experienceBasePlayer * gtv.experienceMultiplierPlayer * ((gqt.experienceMultiplierPlayer - 1) + (git.experienceMultiplierPlayer - 1) + (glt.experienceMultiplierPlayer - 1) + 1)) AS 'experiencePlayerTotal',
	gtv.experienceMultiplierPlayer AS 'experiencePlayerMultiplierGatherableType',
	sct.experienceBaseSkill AS 'experienceSkillBase',
	(sct.experienceBaseSkill * gtv.experienceMultiplierSkill * ((gqt.experienceMultiplierSkill - 1) + (git.experienceMultiplierSkill - 1) + (glt.experienceMultiplierSkill - 1) + 1)) AS 'experienceSkillTotal',
	gtv.experienceMultiplierSkill AS 'experienceSkillMultiplierGatherableType',
	(gqt.offsetRelativeLevelId) + (git.offsetRelativeLevelId) + (glt.offsetRelativeLevelId) AS 'offsetRelativeLevelIdTotal',
	(glt.additionalRarity + git.additionalRarity) AS 'additionalRarityTotal',
	gqt.additionalQuantity AS 'additionalQuantityTotal',
	(gqt.experienceMultiplierPlayer - 1) + (git.experienceMultiplierPlayer - 1) + (glt.experienceMultiplierPlayer - 1) + 1 AS 'experiencePlayerMultiplierVariation',
	(gqt.experienceMultiplierSkill - 1) + (git.experienceMultiplierSkill - 1) + (glt.experienceMultiplierSkill - 1) + 1 AS 'experienceSkillMultiplierVariation',
	 glo2.globalObjectName AS 'lootTableName',
	 git.typeName AS 'gatherableImbuedTypeName',
	 gqt.typeName AS 'gatherableQuantityTypeName',
	 glt.typeName AS 'gatherableLocationTypeName',
	 sgs.displayName,
	 sr.minLevel   AS 'skilledRequiredBase',
	 (glt.additionalSkillRequired + git.additionalSkillRequired + gqt.additionalSkillRequired) AS 'additionalSkillRequired',
	 (glt.additionalSkillRequired + git.additionalSkillRequired + gqt.additionalSkillRequired + sr.minLevel) AS 'skilledRequiredTotal'
FROM [content].[scriptableGatherablesSpawnable] sgs
	JOIN [content].[globalObjects] glo ON sgs.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectSpawnables] sos ON sgs.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[scriptableWorldObjects] swo ON sgs.globalObject = swo.globalObject
	JOIN [content].[scriptableInteractables] si ON sgs.globalObject = si.globalObject
	JOIN [content].[scriptableSkills] ss ON si.interactableRequiredSkillGlobalObject = ss.globalObject
	JOIN [content].[skillCategoryTypes] sct ON ss.skillCategoryTypeId = sct.typeId
	JOIN [content].[scriptableGatherables] sg ON sgs.globalObject = sg.globalObject
	JOIN [content].[gatherableTypes] gt ON sg.gatherableTypeId = gt.typeId
	JOIN [content].[scriptableGatherablesVariations] sgv ON sos.variationId = sgv.variationId AND sg.gatherableTypeId = sgv.gatherableTypeId
	JOIN [content].[gatherableImbuedTypes] git ON sgv.gatherableImbuedTypeId = git.typeId
	JOIN [content].[gatherableLocationTypes] glt ON sgv.gatherableLocationTypeId = glt.typeId
	JOIN [content].[gatherableQuantityTypes] gqt ON sgv.gatherableQuantityTypeId = gqt.typeId
	JOIN gatherableTypesView gtv ON sg.gatherableTypeId = gtv.mainTypeId AND sg.gatherableClassificationTypeId = gtv.classificationTypeId AND sg.gatherableSubTypeId = gtv.subTypeId
	JOIN [content].[spawnablesToLootTables] stl ON sgs.scriptableObjectSpawnable = stl.scriptableObjectSpawnable
	JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	JOIN [content].[skillRanks] sr ON si.interactableRequiredSkillRankId = sr.typeId

GO

