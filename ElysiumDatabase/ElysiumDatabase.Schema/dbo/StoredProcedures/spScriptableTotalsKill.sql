


CREATE PROCEDURE [dbo].[spScriptableTotalsKill]
	
AS
	
	
	SELECT 
	stk.scriptableTotalsKillId,
	stk.killTypeId,
	stk.killMainTypeId,
	stk.killClassificationTypeId,
	stk.killSubTypeId,
	stk.totalGlobalObject, 
	stk.killRequiredGlobalObject,
	stk.dataAttributeTypeId,
	stk.imbuedTypeId,
	stk.difficultyTypeId,
	glo.globalObjectName, 
	dat.typeName AS 'dataAttributeType',
	glo2.globalObjectName AS 'killRequiredObjectName',
	gqt.typeName AS 'difficultyType',
	ats.typeName AS 'killMainType',
	act.typeName AS 'killClassificationType',
	ast.typeName AS 'killSubType',
	et.typeName AS 'killType',
	eit.typeName AS 'imbuedType',
	gt.typeName AS 'killEntityTier',
	glo.globalTierId,
	stk.killTierId,
	gt2.typeName AS 'killTier'
	FROM [content].[scriptableTotalsKill] stk
	JOIN [content].[globalObjects] glo ON stk.totalGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stk.killRequiredGlobalObject = glo2.globalObject
	JOIN [content].[dataAttributeTypes] dat ON stk.dataAttributeTypeId = dat.typeId
	JOIN [content].[entityTypes] et ON stk.killTypeId = et.typeId
	JOIN [content].[animalTypes] ats ON stk.killMainTypeId = ats.typeId
	JOIN [content].[animalClassificationTypes] act ON stk.killClassificationTypeId = act.typeId
	JOIN [content].[animalSubTypes] ast ON stk.killSubTypeId = ast.typeId
	JOIN [content].[entityImbuedTypes] eit ON stk.imbuedTypeId = eit.typeId
	JOIN [content].[entityDifficultyTypes] gqt ON stk.difficultyTypeId = gqt.typeId
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[globalTiers] gt2 ON stk.killTierId = gt2.typeId
	WHERE et.typeName = 'Animal'

	UNION ALL

	SELECT 
	stk.scriptableTotalsKillId,
	stk.killTypeId,
	stk.killMainTypeId,
	stk.killClassificationTypeId,
	stk.killSubTypeId,
	stk.totalGlobalObject, 
	stk.killRequiredGlobalObject,
	stk.dataAttributeTypeId,
	stk.imbuedTypeId,
	stk.difficultyTypeId,
	glo.globalObjectName, 
	dat.typeName AS 'dataAttributeType',
	glo2.globalObjectName AS 'killRequiredObjectName',
	gqt.typeName AS 'difficultyType',
	ats.typeName AS 'killMainType',
	act.typeName AS 'killClassificationType',
	ast.typeName AS 'killSubType',
	et.typeName AS 'killType',
	eit.typeName AS 'imbuedType',
	gt.typeName AS 'killEntityTier',
	glo.globalTierId,
	stk.killTierId,
	gt2.typeName AS 'killTier'
	FROM [content].[scriptableTotalsKill] stk
	JOIN [content].[globalObjects] glo ON stk.totalGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stk.killRequiredGlobalObject = glo2.globalObject
	JOIN [content].[dataAttributeTypes] dat ON stk.dataAttributeTypeId = dat.typeId
	JOIN [content].[entityTypes] et ON stk.killTypeId = et.typeId
	JOIN [content].[enemyHumanoidTypes] ats ON stk.killMainTypeId = ats.typeId
	JOIN [content].[enemyHumanoidClassificationTypes] act ON stk.killClassificationTypeId = act.typeId
	JOIN [content].[enemyHumanoidSubTypes] ast ON stk.killSubTypeId = ast.typeId
	JOIN [content].[entityImbuedTypes] eit ON stk.imbuedTypeId = eit.typeId
	JOIN [content].[entityDifficultyTypes] gqt ON stk.difficultyTypeId = gqt.typeId
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[globalTiers] gt2 ON stk.killTierId = gt2.typeId
	WHERE et.typeName = 'Enemy Humanoid'

	UNION ALL

	SELECT 
	stk.scriptableTotalsKillId,
	stk.killTypeId,
	stk.killMainTypeId,
	stk.killClassificationTypeId,
	stk.killSubTypeId,
	stk.totalGlobalObject, 
	stk.killRequiredGlobalObject,
	stk.dataAttributeTypeId,
	stk.imbuedTypeId,
	stk.difficultyTypeId,
	glo.globalObjectName, 
	dat.typeName AS 'dataAttributeType',
	glo2.globalObjectName AS 'killRequiredObjectName',
	gqt.typeName AS 'difficultyType',
	ats.typeName AS 'killMainType',
	act.typeName AS 'killClassificationType',
	ast.typeName AS 'killSubType',
	et.typeName AS 'killType',
	eit.typeName AS 'imbuedType',
	gt.typeName AS 'killEntityTier',
	glo.globalTierId,
	stk.killTierId,
	gt2.typeName AS 'killTier'
	FROM [content].[scriptableTotalsKill] stk
	JOIN [content].[globalObjects] glo ON stk.totalGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stk.killRequiredGlobalObject = glo2.globalObject
	JOIN [content].[dataAttributeTypes] dat ON stk.dataAttributeTypeId = dat.typeId
	JOIN [content].[entityTypes] et ON stk.killTypeId = et.typeId
	JOIN [content].[monsterTypes] ats ON stk.killMainTypeId = ats.typeId
	JOIN [content].[monsterClassificationTypes] act ON stk.killClassificationTypeId = act.typeId
	JOIN [content].[monsterSubTypes] ast ON stk.killSubTypeId = ast.typeId
	JOIN [content].[entityImbuedTypes] eit ON stk.imbuedTypeId = eit.typeId
	JOIN [content].[entityDifficultyTypes] gqt ON stk.difficultyTypeId = gqt.typeId
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[globalTiers] gt2 ON stk.killTierId = gt2.typeId
	WHERE et.typeName = 'Monster'

	UNION ALL

	SELECT 
	stk.scriptableTotalsKillId,
	stk.killTypeId,
	stk.killMainTypeId,
	stk.killClassificationTypeId,
	stk.killSubTypeId,
	stk.totalGlobalObject, 
	stk.killRequiredGlobalObject,
	stk.dataAttributeTypeId,
	stk.imbuedTypeId,
	stk.difficultyTypeId,
	glo.globalObjectName, 
	dat.typeName AS 'dataAttributeType',
	glo2.globalObjectName AS 'killRequiredObjectName',
	gqt.typeName AS 'difficultyType',
	ats.typeName AS 'killMainType',
	act.typeName AS 'killClassificationType',
	ast.typeName AS 'killSubType',
	et.typeName AS 'killType',
	eit.typeName AS 'imbuedType',
	gt.typeName AS 'killEntityTier',
	glo.globalTierId,
	stk.killTierId,
	gt2.typeName AS 'killTier'
	FROM [content].[scriptableTotalsKill] stk
	JOIN [content].[globalObjects] glo ON stk.totalGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stk.killRequiredGlobalObject = glo2.globalObject
	JOIN [content].[dataAttributeTypes] dat ON stk.dataAttributeTypeId = dat.typeId
	JOIN [content].[entityTypes] et ON stk.killTypeId = et.typeId
	JOIN [content].[npcTypes] ats ON stk.killMainTypeId = ats.typeId
	JOIN [content].[npcClassificationTypes] act ON stk.killClassificationTypeId = act.typeId
	JOIN [content].[npcSubTypes] ast ON stk.killSubTypeId = ast.typeId
	JOIN [content].[entityImbuedTypes] eit ON stk.imbuedTypeId = eit.typeId
	JOIN [content].[entityDifficultyTypes] gqt ON stk.difficultyTypeId = gqt.typeId
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[globalTiers] gt2 ON stk.killTierId = gt2.typeId
	WHERE et.typeName = 'NPC'

	UNION ALL

	SELECT 
	stk.scriptableTotalsKillId,
	stk.killTypeId,
	stk.killMainTypeId,
	stk.killClassificationTypeId,
	stk.killSubTypeId,
	stk.totalGlobalObject, 
	stk.killRequiredGlobalObject,
	stk.dataAttributeTypeId,
	stk.imbuedTypeId,
	stk.difficultyTypeId,
	glo.globalObjectName, 
	dat.typeName AS 'dataAttributeType',
	glo2.globalObjectName AS 'killRequiredObjectName',
	gqt.typeName AS 'difficultyType',
	'None',
	'None',
	'None',
	et.typeName AS 'killType',
	eit.typeName AS 'imbuedType',
	gt.typeName AS 'killEntityTier',
	glo.globalTierId,
	stk.killTierId,
	gt2.typeName AS 'killTier'
	FROM [content].[scriptableTotalsKill] stk
	JOIN [content].[globalObjects] glo ON stk.totalGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stk.killRequiredGlobalObject = glo2.globalObject
	JOIN [content].[dataAttributeTypes] dat ON stk.dataAttributeTypeId = dat.typeId
	JOIN [content].[entityTypes] et ON stk.killTypeId = et.typeId
	--JOIN [content].[npcTypes] ats ON stk.killMainTypeId = ats.typeId
	--JOIN [content].[npcTypes] act ON stk.killClassificationTypeId = act.typeId
	--JOIN [content].[npcSubTypes] ast ON stk.killSubTypeId = ast.typeId
	JOIN [content].[entityImbuedTypes] eit ON stk.imbuedTypeId = eit.typeId
	JOIN [content].[entityDifficultyTypes] gqt ON stk.difficultyTypeId = gqt.typeId
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[globalTiers] gt2 ON stk.killTierId = gt2.typeId
	WHERE et.typeName = 'None'

GO

