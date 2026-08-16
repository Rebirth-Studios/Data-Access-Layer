


CREATE VIEW [dbo].[scriptableItemsView] AS 
	
	--AMMO
	SELECT
		sit.globalObject,
		it.typeId AS 'itemTypeId', 
		it.type AS 'itemTypeName', 
		COALESCE(sa.ammunitionMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		COALESCE(sa.ammunitionClassificationTypeId, 0) AS 'classificationTypeId', 
		COALESCE(mct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(sa.ammunitionSubTypeId, 0) AS 'subTypeId', 
		COALESCE(mst.typeName, 'None') AS 'subTypeName'
	FROM [content].[scriptableItems] sit
	JOIN [content].[itemTypes] it ON sit.itemTypeId = it.typeId
	JOIN [content].[scriptableAmmunition] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[ammunitionTypes] mt ON sa.ammunitionMainTypeId = mt.typeId
	LEFT JOIN [content].[ammunitionClassificationTypes] mct ON sa.ammunitionClassificationTypeId = mct.typeId
	LEFT JOIN [content].[ammunitionSubTypes] mst ON sa.ammunitionSubTypeId = mst.typeId

	UNION ALL

	--BAGS
	SELECT
		sit.globalObject,
		it.typeId AS 'itemTypeId', 
		it.type AS 'itemTypeName', 
		COALESCE(sa.bagMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		COALESCE(sa.bagClassificationTypeId, 0) AS 'classificationTypeId', 
		COALESCE(mct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(sa.bagSubTypeId, 0) AS 'subTypeId', 
		COALESCE(mst.typeName, 'None') AS 'subTypeName'
	FROM [content].[scriptableItems] sit
	JOIN [content].[itemTypes] it ON sit.itemTypeId = it.typeId
	JOIN [content].[scriptableBags] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[bagTypes] mt ON sa.bagMainTypeId = mt.typeId
	LEFT JOIN [content].[bagClassificationTypes] mct ON sa.bagClassificationTypeId = mct.typeId
	LEFT JOIN [content].[bagSubTypes] mst ON sa.bagSubTypeId = mst.typeId

	UNION ALL

	--CONSUMABLES
	SELECT
		sit.globalObject,
		it.typeId AS 'itemTypeId', 
		it.type AS 'itemTypeName',
		COALESCE(sa.consumableMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		COALESCE(sa.consumableClassificationTypeId, 0) AS 'classificationTypeId', 
		COALESCE(mct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(sa.consumableSubTypeId, 0) AS 'subTypeId', 
		COALESCE(mst.typeName, 'None') AS 'subTypeName'
	FROM [content].[scriptableItems] sit
	JOIN [content].[itemTypes] it ON sit.itemTypeId = it.typeId
	JOIN [content].[scriptableConsumables] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[consumableTypes] mt ON sa.consumableMainTypeId = mt.typeId
	LEFT JOIN [content].[consumableClassificationTypes] mct ON sa.consumableClassificationTypeId = mct.typeId
	LEFT JOIN [content].[consumableSubTypes] mst ON sa.consumableSubTypeId = mst.typeId

	UNION ALL

	--EQUIPMENT
	SELECT
		sit.globalObject,
		it.typeId AS 'itemTypeId', 
		it.type AS 'itemTypeName',
		COALESCE(sa.equipmentMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subTypeName'
	FROM [content].[scriptableItems] sit
	JOIN [content].[itemTypes] it ON sit.itemTypeId = it.typeId
	JOIN [content].[scriptableEquipment] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[equipmentTypes] mt ON sa.equipmentMainTypeId = mt.typeId
	
	UNION ALL

	--GENERAL ITEMS
	SELECT
		sit.globalObject,
		it.typeId AS 'itemTypeId', 
		it.type AS 'itemTypeName',
		COALESCE(sa.generalItemMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		COALESCE(sa.generalItemClassificationTypeId, 0) AS 'classificationTypeId', 
		COALESCE(mct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(sa.generalItemSubTypeId, 0) AS 'subTypeId', 
		COALESCE(mst.typeName, 'None') AS 'subTypeName'
	FROM [content].[scriptableItems] sit
	JOIN [content].[itemTypes] it ON sit.itemTypeId = it.typeId
	JOIN [content].[scriptableGeneralItems] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[generalItemTypes] mt ON sa.generalItemMainTypeId = mt.typeId
	LEFT JOIN [content].[generalItemClassificationTypes] mct ON sa.generalItemClassificationTypeId = mct.typeId
	LEFT JOIN [content].[generalItemSubTypes] mst ON sa.generalItemSubTypeId = mst.typeId

	UNION ALL

	--MATERIAL
	SELECT
		sit.globalObject,
		it.typeId AS 'itemTypeId', 
		it.type AS 'itemTypeName',
		COALESCE(sa.materialMainTypeId, 0) AS 'mainTypeId', 
		COALESCE(mt.typeName, 'None') AS 'mainTypeName', 
		COALESCE(sa.materialClassificationTypeId, 0) AS 'classificationTypeId', 
		COALESCE(mct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(sa.materialSubTypeId, 0) AS 'subTypeId', 
		COALESCE(mst.typeName, 'None') AS 'subTypeName'
	FROM [content].[scriptableItems] sit
	JOIN [content].[itemTypes] it ON sit.itemTypeId = it.typeId
	JOIN [content].[scriptableMaterials] sa ON sit.globalObject = sa.globalObject
	LEFT JOIN [content].[materialTypes] mt ON sa.materialMainTypeId = mt.typeId
	LEFT JOIN [content].[materialClassificationTypes] mct ON sa.materialClassificationTypeId = mct.typeId
	LEFT JOIN [content].[materialSubTypes] mst ON sa.materialSubTypeId = mst.typeId

	UNION

	--UNHANDLED ITEM TYPES
	SELECT
		sit.globalObject,
		it.typeId AS 'itemTypeId', 
		it.type AS 'itemTypeName', 
		0 AS 'mainTypeId', 
		'None' AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subTypeName'
	FROM [content].[scriptableItems] sit
	JOIN [content].[itemTypes] it ON sit.itemTypeId = it.typeId
	WHERE sit.itemTypeId NOT IN (1, 2, 3, 5, 6, 7)

GO

