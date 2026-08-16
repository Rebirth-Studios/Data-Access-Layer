

CREATE PROCEDURE [dbo].[spScriptableGatherables]
	
AS
	SELECT
	sgs.globalObject,
	sgs.gatherTypeId,
	sgs.gatherableClassificationTypeId,
	sgs.gatherableSubTypeId,
	sgs.requiredWeaponTypeId,
	sgs.requiredPower,
	sgs.maxToolPower,
	sgs.craftingMaterialTypeId,
	sgs.associatedMaterialGlobalObject,
	sgs.associatedMaterialImbuedGlobalObject,
	glo.globalObjectName,
	glo2.globalObjectName AS 'associatedMaterialName',
	glo3.globalObjectName AS 'associatedMaterialNameImbued',
	cmt.typeName AS 'craftingMaterialTypeName',
	gt.typeName AS 'mainTypeName', 
	gct.typeName AS 'classificationTypeName', 
	gst.typeName AS 'subTypeName', 
	grt.typeName AS 'gatherTypeName', 
	wt.typeName AS 'requiredWeaponTypeName'
FROM [content].[scriptableGatherables] sgs
	JOIN [content].[globalObjects] glo ON sgs.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON sgs.associatedMaterialGlobalObject = glo2.globalObject
	JOIN [content].[globalObjects] glo3 ON sgs.associatedMaterialImbuedGlobalObject = glo3.globalObject
	JOIN [content].[craftingMaterialTypes] cmt ON sgs.craftingMaterialTypeId = cmt.typeId
	JOIN [content].[weaponTypes] wt ON sgs.requiredWeaponTypeId = wt.typeId
	JOIN [content].[gatherTypes] grt ON sgs.gatherTypeId = grt.typeId
	JOIN [content].[gatherableTypes] gt ON sgs.gatherableTypeId = gt.typeId
	JOIN [content].[gatherableClassificationTypes] gct ON sgs.gatherableClassificationTypeId = gct.typeId
	JOIN [content].[gatherableSubTypes] gst ON sgs.gatherableSubTypeId = gst.typeId

GO

