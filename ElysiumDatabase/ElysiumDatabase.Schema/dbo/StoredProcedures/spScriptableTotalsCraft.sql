




CREATE PROCEDURE [dbo].[spScriptableTotalsCraft]
	
AS
	--EVERYTHING EXCEPT FOR NONE AND EQUIPMENT
	SELECT
	stc.craftTypeId,
	stc.craftMainTypeId,
	stc.craftClassificationTypeId,
	stc.craftSubTypeId,
	stc.craftRarityId,
	stc.totalGlobalObject,
	stc.craftRequiredGlobalObject,
	stc.dataAttributeTypeId,
	glo.globalObjectName AS 'globalObjectName',
	glo2.globalObjectName AS 'craftRequiredObjectName',
	itv.mainType AS 'craftMainType',
	itv.classificationTypeName AS 'craftClassificationType',
	itv.subTypeName  AS 'craftSubType',
	dat.typeName AS 'dataAttributeType',
	stc.isImbued,
	it.typeName AS 'craftType',
	sr.typeName AS 'craftRarity',
	stc.craftTierId,
	gt.typeName AS 'craftTier'
	FROM [content].[scriptableTotalsCraft] stc
	JOIN [content].[globalObjects] glo ON stc.totalGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stc.craftRequiredGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON stc.craftTierId = gt.typeId
	JOIN [content].[dataAttributeTypes] dat ON stc.dataAttributeTypeId = dat.typeId
	JOIN [content].[itemTypes] it ON stc.craftTypeId = it.typeId
	JOIN [content].[scriptableRarities] sr ON stc.craftRarityId = sr.typeId
	LEFT JOIN itemTypesView itv ON stc.craftTypeId = itv.parentTypeId AND itv.mainTypeId = stc.craftMainTypeId AND itv.classificationTypeId = stc.craftClassificationTypeId AND itv.subTypeId = stc.craftSubTypeId
	WHERE craftTypeId NOT IN (0, 5)

	UNION

	--EQUIPMENT
	SELECT
	stc.craftTypeId,
	stc.craftMainTypeId,
	stc.craftClassificationTypeId,
	stc.craftSubTypeId,
	stc.craftRarityId,
	stc.totalGlobalObject,
	stc.craftRequiredGlobalObject,
	stc.dataAttributeTypeId,
	glo.globalObjectName AS 'globalObjectName',
	glo2.globalObjectName AS 'craftRequiredObjectName',
	itv.mainType AS 'craftMainType',
	itv.classificationTypeName AS 'craftClassificationType',
	itv.subTypeName  AS 'craftSubType',
	dat.typeName AS 'dataAttributeType',
	stc.isImbued,
	it.typeName AS 'craftType',
	sr.typeName AS 'craftRarity',
	stc.craftTierId,
	gt.typeName AS 'craftTier'
	FROM [content].[scriptableTotalsCraft] stc
	JOIN [content].[globalObjects] glo ON stc.totalGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stc.craftRequiredGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON stc.craftTierId = gt.typeId
	JOIN [content].[dataAttributeTypes] dat ON stc.dataAttributeTypeId = dat.typeId
	JOIN [content].[itemTypes] it ON stc.craftTypeId = it.typeId
	JOIN [content].[scriptableRarities] sr ON stc.craftRarityId = sr.typeId
	LEFT JOIN itemTypesView itv ON stc.craftTypeId = itv.parentTypeId AND itv.mainTypeId = stc.craftMainTypeId --AND itv.classificationTypeId = stc.craftClassificationTypeId AND itv.subTypeId = stc.craftSubTypeId
	WHERE craftTypeId = (5)

	UNION

	--NONE
	SELECT
	stc.craftTypeId,
	stc.craftMainTypeId,
	stc.craftClassificationTypeId,
	stc.craftSubTypeId,
	stc.craftRarityId,
	stc.totalGlobalObject,
	stc.craftRequiredGlobalObject,
	stc.dataAttributeTypeId,
	glo.globalObjectName AS 'globalObjectName',
	glo2.globalObjectName AS 'craftRequiredObjectName',
	'None' AS 'craftMainType',
	'None' AS 'craftClassificationType',
	'None'  AS 'craftSubType',
	dat.typeName AS 'dataAttributeType',
	stc.isImbued,
	it.typeName AS 'craftType',
	sr.typeName AS 'craftRarity',
	stc.craftTierId,
	gt.typeName AS 'craftTier'
	FROM [content].[scriptableTotalsCraft] stc
	JOIN [content].[globalObjects] glo ON stc.totalGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stc.craftRequiredGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON stc.craftTierId = gt.typeId
	JOIN [content].[dataAttributeTypes] dat ON stc.dataAttributeTypeId = dat.typeId
	JOIN [content].[itemTypes] it ON stc.craftTypeId = it.typeId
	JOIN [content].[scriptableRarities] sr ON stc.craftRarityId = sr.typeId
	LEFT JOIN itemTypesView itv ON stc.craftTypeId = itv.parentTypeId AND itv.mainTypeId = stc.craftMainTypeId --AND itv.classificationTypeId = stc.craftClassificationTypeId AND itv.subTypeId = stc.craftSubTypeId
	WHERE craftTypeId = (0)

GO

