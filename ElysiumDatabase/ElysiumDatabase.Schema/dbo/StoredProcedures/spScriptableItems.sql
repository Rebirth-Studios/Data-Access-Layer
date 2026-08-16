CREATE PROCEDURE [dbo].[spScriptableItems]
	
AS
	

SELECT
	si.scriptableItemId,
	si.globalObject,
	si.itemTypeId,
	si.itemWeight,
	si.itemValueGold,
	si.itemValueSilver,
	si.itemValueCopper,
	si.itemStackMax,
	si.itemDurabilityMax,
	si.itemManaCapacity,
	si.itemQualityBaseId,
	si.itemQualityMaxId,
	si.isImbued,
	si.isSoulBound,
	si.itemDescription,
	si.craftingMaterialTypeId,
	glo.globalObjectName AS 'globalObjectName',
	COALESCE(sr1.type, 'None') AS 'itemRarityBase',
	COALESCE(sr2.type, 'None') AS 'itemRarityMax',
	st.typeName AS 'scriptableObjectTypeName',
	sq1.typeName AS 'itemQualityBase',
	sq2.typeName AS 'itemQualityMax',
	it.typeName AS 'itemTypeName',
	cmt.typeName AS 'craftingMaterialTypeName',
	--CASE WHEN si.isImbued = 0 THEN COALESCE(itv.minRarityId, 0) ELSE COALESCE(itv.minImbuedRarityId, 0) END AS itemRarityBaseId,
	CASE WHEN si.isImbued = 0 THEN COALESCE(itv.minRarityId, 0) ELSE COALESCE(itv.minImbuedRarityId, 0) END AS itemRarityBaseId,
	--CASE WHEN si.isImbued = 0 THEN COALESCE(itv.maxRarityId, 0) ELSE COALESCE(itv.maxImbuedRarityId, 0) END AS itemRarityMaxId,
	CASE WHEN si.isImbued = 0 THEN COALESCE(itv.maxRarityId, 0) ELSE COALESCE(itv.maxImbuedRarityId, 0) END AS itemRarityMaxId,
	COALESCE(sr.equipmentMainTypeId, 0) AS 'itemSubTypeId'
	FROM [content].[scriptableItems] si
	JOIN [content].[itemTypes] it ON si.itemTypeId = it.typeId
	JOIN [content].[craftingMaterialTypes] cmt ON si.craftingMaterialTypeId = cmt.typeId
	JOIN [content].[globalObjects] glo ON si.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectTypes] st ON glo.scriptableObjectTypeId = st.typeId
	JOIN [content].[scriptableQualities] sq1 ON si.itemQualityBaseId = sq1.typeId
	JOIN [content].[scriptableQualities] sq2 ON si.itemQualityMaxId = sq2.typeId
	JOIN scriptableItemsView sc ON si.globalObject = sc.globalObject
	LEFT JOIN itemTypesView itv ON si.itemTypeId = itv.parentTypeId AND itv.mainTypeId = sc.mainTypeId AND itv.classificationTypeId = sc.classificationTypeId AND itv.subTypeId = sc.subTypeId
	LEFT JOIN [content].[scriptableRarities] sr1 ON sr1.typeId = CASE 
                    WHEN si.isImbued = 0 THEN itv.minRarityId
                    ELSE itv.minImbuedRarityId
                END
	LEFT JOIN [content].[scriptableRarities] sr2 ON sr2.typeId = CASE 
                    WHEN si.isImbued = 0 THEN itv.maxRarityId
                    ELSE itv.maxImbuedRarityId
                END
	LEFT JOIN [content].[scriptableEquipment] sr ON si.globalObject = sr.globalObject

GO

