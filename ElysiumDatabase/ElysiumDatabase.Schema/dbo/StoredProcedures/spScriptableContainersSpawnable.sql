






CREATE PROCEDURE [dbo].[spScriptableContainersSpawnable]
	
AS
	SELECT
	scs.globalObject,
	scs.containerTypeId,
	glo.globalObjectName AS 'globalObjectName',
	scs.scriptableObjectLevel,
	sol.scriptableObjectLevelName AS 'scriptableObjectLevelName',
	scs.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName AS 'scriptableObjectSpawnableName',
	sol.levelId,
	scs.variationId,
	scs.requiredPower,
	scs.maxToolPower,
	scs.width,
	scs.height,
	(sct.experienceBasePlayer * ctv.experienceMultiplierPlayer * ((cqt.experienceMultiplierPlayer - 1) + (cit.experienceMultiplierPlayer - 1) + (crt.experienceMultiplierPlayer - 1) + 1)) AS 'experiencePlayerTotal',
	(sct.experienceBaseSkill * ctv.experienceMultiplierSkill * ((cqt.experienceMultiplierSkill - 1) + (cit.experienceMultiplierSkill - 1) + (crt.experienceMultiplierSkill - 1) + 1)) AS 'experienceSkillTotal',
	scs.displayName,
	 sct.experienceBasePlayer AS 'experiencePlayerBase',
	 (cqt.experienceMultiplierPlayer - 1) + (cit.experienceMultiplierPlayer - 1) + (crt.experienceMultiplierPlayer - 1) AS 'experiencePlayerMultiplierVariation',
	 ctv.experienceMultiplierPlayer AS 'experiencePlayerMultiplierContainerType',
	 sct.experienceBaseSkill AS 'experienceSkillBase',
	 (cqt.experienceMultiplierSkill - 1) + (cit.experienceMultiplierSkill - 1) + (crt.experienceMultiplierSkill - 1) AS 'experienceSkillMultiplierVariation',
	 ctv.experienceMultiplierSkill AS 'experienceSkillMultiplierContainerType',
	 (cqt.offsetRelativeLevelId) + (cit.offsetRelativeLevelId) + (crt.offsetRelativeLevelId) AS 'offsetRelativeLevelIdTotal',
	(crt.additionalRarity + cit.additionalRarity) AS 'additionalRarityTotal',
	cqt.additionalQuantity AS 'additionalQuantityTotal',
	 glo2.globalObjectName AS 'lootTableName',
	 cit.typeName AS 'containerImbuedTypeName',
	 cqt.typeName AS 'containerQuantityTypeName',
	 crt.typeName AS 'containerRarityTypeName',
	 ct.typeName AS 'containerTypeName',
	 sr.minLevel   AS 'skilledRequiredBase',
	 (crt.additionalSkillRequired + cit.additionalSkillRequired + cqt.additionalSkillRequired) AS 'additionalSkillRequired',
	 (crt.additionalSkillRequired + cit.additionalSkillRequired + cqt.additionalSkillRequired + sr.minLevel) AS 'skilledRequiredTotal'
	FROM [content].[scriptableContainersSpawnable] scs
	JOIN [content].[globalObjects] glo ON scs.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectSpawnables] sos ON scs.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[spawnablesToLootTables] stl ON scs.scriptableObjectSpawnable = stl.scriptableObjectSpawnable
	JOIN [content].[globalObjects] glo2 ON stl.lootTableGlobalObject = glo2.globalObject
	JOIN [content].[scriptableObjectLevels] sol ON scs.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[scriptableInteractables] si ON scs.globalObject = si.globalObject
	JOIN [content].[scriptableSkills] ss ON si.interactableRequiredSkillGlobalObject = ss.globalObject
	JOIN [content].[skillCategoryTypes] sct ON ss.skillCategoryTypeId = sct.typeId
	JOIN [content].[scriptableContainers] sc ON scs.globalObject = sc.globalObject
	JOIN [content].[containerTypes] ct ON sc.containerMainTypeId = ct.typeId
	JOIN [content].[scriptableContainersVariations] scv ON sos.variationId = scv.variationId AND sc.containerMainTypeId = scv.containerTypeId
	JOIN [content].[containerImbuedTypes] cit ON scv.containerImbuedTypeId = cit.typeId
	JOIN [content].[containerRarityTypes] crt ON scv.containerRarityTypeId = crt.typeId
	JOIN [content].[containerQuantityTypes] cqt ON scv.containerQuantityTypeId = cqt.typeId
	JOIN containerTypesView ctv ON sc.containerMainTypeId  = ctv.mainTypeId AND sc.containerClassificationTypeId = ctv.classificationTypeId AND sc.containerSubTypeId = ctv.subTypeId
	JOIN [content].[skillRanks] sr ON si.interactableRequiredSkillRankId = sr.typeId

GO

