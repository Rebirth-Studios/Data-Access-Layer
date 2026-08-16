

CREATE PROCEDURE [dbo].[spScriptableTotalsGather]
	
AS

	SELECT 
	stg.gatherMainTypeId,
	stg.gatherClassificationTypeId,
	stg.gatherSubTypeId,
	stg.totalGlobalObject, 
	stg.gatherRequiredGlobalObject,
	stg.imbuedTypeId,
	stg.dataAttributeTypeId,
	stg.gatherTypeId,
	stg.locationTypeId,
	stg.quantityTypeId,
	glo.globalObjectName, 
	dat.typeName AS 'dataAttributeType',
	glo2.globalObjectName AS 'gatherRequiredObjectName',
	gts.typeName AS 'mainTypeName',
	gcs.typeName AS 'classificationTypeName',
	gss.typeName AS 'subTypeName',
	git.typeName AS 'imbuedType',
	glt.typeName AS 'locationType',
	it.typeName AS 'gatherTypeName',
	gqt.typeName AS 'quantityType',
	gt.typeName AS 'gatherTier',
	stg.gatherTierId
	FROM [content].[scriptableTotalsGather] stg
	JOIN [content].[globalObjects] glo ON stg.totalGlobalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON stg.gatherRequiredGlobalObject = glo2.globalObject
	JOIN [content].[dataAttributeTypes] dat ON stg.dataAttributeTypeId = dat.typeId
	JOIN [content].[gatherableTypes] gts ON stg.gatherMainTypeId = gts.typeId
	JOIN [content].[gatherableClassificationTypes] gcs ON stg.gatherClassificationTypeId = gcs.typeId
	JOIN [content].[gatherableSubTypes] gss ON stg.gatherSubTypeId = gss.typeId
	JOIN [content].[gatherableImbuedTypes] git ON stg.imbuedTypeId = git.typeId
	JOIN [content].[gatherableLocationTypes] glt ON stg.locationTypeId = glt.typeId
	JOIN [content].[interactableTypes] it ON stg.gatherTypeId = it.typeId
	JOIN [content].[gatherableQuantityTypes] gqt ON stg.imbuedTypeId = gqt.typeId
	JOIN [content].[globalTiers] gt ON stg.gatherTierId = gt.typeId

GO

