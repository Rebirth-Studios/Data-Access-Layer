





CREATE VIEW [dbo].[itemTypesView] AS 
	
	
	--FOR NONE RECORDS
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		0 AS 'mainTypeId', 
		'None' AS 'mainType', 
		'None' AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		0 AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		0 AS 'minRarityId',
		0 AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		0 AS 'maxRarityId',
		0 AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		0 AS 'minImbuedRarityId',
		0 AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		0 AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	WHERE it.type = 'Ammunition'

	UNION

--FOR RECORDS WITH ONLY MAIN TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		COALESCE(bt.minRarityId, 0) AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		COALESCE(bt.maxRarityId, 0) AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		COALESCE(bt.minImbuedRarityId, 0) AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		COALESCE(bt.maxImbuedRarityId, 0) AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[ammunitionTypes] bt ON it.typeId = bt.parentTypeId
	WHERE it.type = 'Ammunition'

	UNION

	--FOR RECORDS WITH ONLY MAIN TYPE AND CLASSIFIED TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType',
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId END AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId END AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[ammunitionTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[ammunitionClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	WHERE it.type = 'Ammunition'

	UNION 

	--FOR RECORDS WITH MAIN TYPE AND CLASSIFIED TYPE AND SUB TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType', 
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(bst.typeId, 0) AS 'subTypeId', 
		COALESCE(bst.type, 'None') AS 'subType',
		COALESCE(bst.typeName, 'None') AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		COALESCE(bst.minRarityId, 0) AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId WHEN bst.minRarityId != 0 THEN bst.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		COALESCE(bst.maxRarityId, 0) AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId WHEN bst.maxRarityId != 0 THEN bst.maxRarityId END AS 'maxRarityId',

		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		COALESCE(bst.minImbuedRarityId, 0) AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId WHEN bst.minImbuedRarityId != 0 THEN bst.minImbuedRarityId END AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		COALESCE(bst.maxImbuedRarityId, 0) AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId WHEN bst.maxImbuedRarityId != 0 THEN bst.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[ammunitionTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[ammunitionClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	LEFT JOIN [content].[ammunitionSubTypes] bst ON bct.typeId = bst.parentTypeId
	WHERE it.type = 'Ammunition'

	UNION

	--FOR NONE RECORDS
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		0 AS 'mainTypeId', 
		'None' AS 'mainType', 
		'None' AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		0 AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		0 AS 'minRarityId',
		0 AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		0 AS 'maxRarityId',
		0 AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		0 AS 'minImbuedRarityId',
		0 AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		0 AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	WHERE it.type = 'Bag'

	UNION

	--FOR RECORDS WITH ONLY MAIN TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		COALESCE(bt.minRarityId, 0) AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		COALESCE(bt.maxRarityId, 0) AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		COALESCE(bt.minImbuedRarityId, 0) AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		COALESCE(bt.maxImbuedRarityId, 0) AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[bagTypes] bt ON it.typeId = bt.parentTypeId
	WHERE it.type = 'Bag'


	UNION

	--FOR RECORDS WITH ONLY MAIN TYPE AND CLASSIFIED TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType', 
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId END AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId END AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[bagTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[bagClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	WHERE it.type = 'Bag'

	UNION 

	--FOR RECORDS WITH MAIN TYPE AND CLASSIFIED TYPE AND SUB TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType', 
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(bst.typeId, 0) AS 'subTypeId', 
		COALESCE(bst.type, 'None') AS 'subType',
		COALESCE(bst.typeName, 'None') AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		COALESCE(bst.minRarityId, 0) AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId WHEN bst.minRarityId != 0 THEN bst.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		COALESCE(bst.maxRarityId, 0) AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId WHEN bst.maxRarityId != 0 THEN bst.maxRarityId END AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		COALESCE(bst.minImbuedRarityId, 0) AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId WHEN bst.minImbuedRarityId != 0 THEN bst.minImbuedRarityId END AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		COALESCE(bst.maxImbuedRarityId, 0) AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId WHEN bst.maxImbuedRarityId != 0 THEN bst.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[bagTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[bagClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	LEFT JOIN [content].[bagSubTypes] bst ON bct.typeId = bst.parentTypeId
	WHERE it.type = 'Bag'

	UNION

	--FOR NONE RECORDS
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		0 AS 'mainTypeId', 
		'None' AS 'mainType', 
		'None' AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		0 AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		0 AS 'minRarityId',
		0 AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		0 AS 'maxRarityId',
		0 AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		0 AS 'minImbuedRarityId',
		0 AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		0 AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	WHERE it.type = 'Consumable'

	UNION

--FOR RECORDS WITH ONLY MAIN TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		COALESCE(bt.minRarityId, 0) AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		COALESCE(bt.maxRarityId, 0) AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		COALESCE(bt.minImbuedRarityId, 0) AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		COALESCE(bt.maxImbuedRarityId, 0) AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[consumableTypes] bt ON it.typeId = bt.parentTypeId
	WHERE it.type = 'Consumable'

	UNION

	--FOR RECORDS WITH ONLY MAIN TYPE AND CLASSIFIED TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType', 
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId END AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId END AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[consumableTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[consumableClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	WHERE it.type = 'Consumable'

	UNION 

	--FOR RECORDS WITH MAIN TYPE AND CLASSIFIED TYPE AND SUB TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType', 
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(bst.typeId, 0) AS 'subTypeId', 
		COALESCE(bst.type, 'None') AS 'subType',
		COALESCE(bst.typeName, 'None') AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		COALESCE(bst.minRarityId, 0) AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId WHEN bst.minRarityId != 0 THEN bst.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		COALESCE(bst.maxRarityId, 0) AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId WHEN bst.maxRarityId != 0 THEN bst.maxRarityId END AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		COALESCE(bst.minImbuedRarityId, 0) AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId WHEN bst.minImbuedRarityId != 0 THEN bst.minImbuedRarityId END AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		COALESCE(bst.maxImbuedRarityId, 0) AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId WHEN bst.maxImbuedRarityId != 0 THEN bst.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[consumableTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[consumableClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	LEFT JOIN [content].[consumableSubTypes] bst ON bct.typeId = bst.parentTypeId
	WHERE it.type = 'Consumable'

	UNION

	--FOR NONE RECORDS
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		0 AS 'mainTypeId', 
		'None' AS 'mainType', 
		'None' AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		0 AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		0 AS 'minRarityId',
		0 AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		0 AS 'maxRarityId',
		0 AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		0 AS 'minImbuedRarityId',
		0 AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		0 AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	WHERE it.type = 'GeneralItem'

	UNION

--FOR RECORDS WITH ONLY MAIN TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		COALESCE(bt.minRarityId, 0) AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		COALESCE(bt.maxRarityId, 0) AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		COALESCE(bt.minImbuedRarityId, 0) AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		COALESCE(bt.maxImbuedRarityId, 0) AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[generalItemTypes] bt ON it.typeId = bt.parentTypeId
	WHERE it.type = 'GeneralItem'


	UNION

	--FOR RECORDS WITH ONLY MAIN TYPE AND CLASSIFIED TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType', 
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId END AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId END AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[generalItemTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[generalItemClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	WHERE it.type = 'GeneralItem'

	UNION 

	--FOR RECORDS WITH MAIN TYPE AND CLASSIFIED TYPE AND SUB TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType', 
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(bst.typeId, 0) AS 'subTypeId', 
		COALESCE(bst.type, 'None') AS 'subType',
		COALESCE(bst.typeName, 'None') AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		COALESCE(bst.minRarityId, 0) AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId WHEN bst.minRarityId != 0 THEN bst.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		COALESCE(bst.maxRarityId, 0) AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId WHEN bst.maxRarityId != 0 THEN bst.maxRarityId END AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		COALESCE(bst.minImbuedRarityId, 0) AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId WHEN bst.minImbuedRarityId != 0 THEN bst.minImbuedRarityId END AS 'minImbuedRarityId',

		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		COALESCE(bst.maxImbuedRarityId, 0) AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId WHEN bst.maxImbuedRarityId != 0 THEN bst.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[generalItemTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[generalItemClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	LEFT JOIN [content].[generalItemSubTypes] bst ON bct.typeId = bst.parentTypeId
	WHERE it.type = 'GeneralItem'

	UNION

	--FOR NONE RECORDS
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		0 AS 'mainTypeId', 
		'None' AS 'mainType', 
		'None' AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		0 AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		0 AS 'minRarityId',
		0 AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		0 AS 'maxRarityId',
		0 AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		0 AS 'minImbuedRarityId',
		0 AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		0 AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	WHERE it.type = 'Material'

	UNION

--FOR RECORDS WITH ONLY MAIN TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType',
		bt.typeName AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		COALESCE(bt.minRarityId, 0) AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		COALESCE(bt.maxRarityId, 0) AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		COALESCE(bt.minImbuedRarityId, 0) AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		COALESCE(bt.maxImbuedRarityId, 0) AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[materialTypes] bt ON it.typeId = bt.parentTypeId
	WHERE it.type = 'Material'

	UNION

	--FOR RECORDS WITH ONLY MAIN TYPE AND CLASSIFIED TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType', 
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId END AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId END AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[materialTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[materialClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	WHERE it.type = 'Material'

	UNION 

	--FOR RECORDS WITH MAIN TYPE AND CLASSIFIED TYPE AND SUB TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		COALESCE(bct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(bct.type, 'None') AS 'classificationType', 
		COALESCE(bct.typeName, 'None') AS 'classificationTypeName', 
		COALESCE(bst.typeId, 0) AS 'subTypeId', 
		COALESCE(bst.type, 'None') AS 'subType',
		COALESCE(bst.typeName, 'None') AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		COALESCE(bct.minRarityId, 0) AS 'classificationTypeMinRarityId',
		COALESCE(bst.minRarityId, 0) AS 'subTypeMinRarityId',
		CASE WHEN bt.minRarityId != 0 THEN bt.minRarityId WHEN bct.minRarityId != 0 THEN bct.minRarityId WHEN bst.minRarityId != 0 THEN bst.minRarityId END AS 'minRarityId',
		
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		COALESCE(bct.maxRarityId, 0) AS 'classificationTypeMaxRarityId',
		COALESCE(bst.maxRarityId, 0) AS 'subTypeMaxRarityId',
		CASE WHEN bt.maxRarityId != 0 THEN bt.maxRarityId WHEN bct.maxRarityId != 0 THEN bct.maxRarityId WHEN bst.maxRarityId != 0 THEN bst.maxRarityId END AS 'maxRarityId',
		
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		COALESCE(bct.minImbuedRarityId, 0) AS 'classificationTypeMinImbuedRarityId',
		COALESCE(bst.minImbuedRarityId, 0) AS 'subTypeMinImbuedRarityId',
		CASE WHEN bt.minImbuedRarityId != 0 THEN bt.minImbuedRarityId WHEN bct.minImbuedRarityId != 0 THEN bct.minImbuedRarityId WHEN bst.minImbuedRarityId != 0 THEN bst.minImbuedRarityId END AS 'minImbuedRarityId',
		
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		COALESCE(bct.maxImbuedRarityId, 0) AS 'classificationTypMaxImbuedRarityId',
		COALESCE(bst.maxImbuedRarityId, 0) AS 'subTypeMaxImbuedRarityId',
		CASE WHEN bt.maxImbuedRarityId != 0 THEN bt.maxImbuedRarityId WHEN bct.maxImbuedRarityId != 0 THEN bct.maxImbuedRarityId WHEN bst.maxImbuedRarityId != 0 THEN bst.maxImbuedRarityId END AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[materialTypes] bt ON it.typeId = bt.parentTypeId
	LEFT JOIN [content].[materialClassificationTypes] bct ON bt.typeId = bct.parentTypeId
	LEFT JOIN [content].[materialSubTypes] bst ON bct.typeId = bst.parentTypeId
	WHERE it.type = 'Material'

	UNION

	--FOR NONE RECORDS
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		0 AS 'mainTypeId', 
		'None' AS 'mainType', 
		'None' AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		0 AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		0 AS 'minRarityId',
		0 AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		0 AS 'maxRarityId',
		0 AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		0 AS 'minImbuedRarityId',
		0 AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		0 AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	WHERE it.type = 'Equipment'

	UNION

--FOR RECORDS WITH ONLY MAIN TYPE SET
	SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		bt.typeId AS 'mainTypeId', 
		bt.type AS 'mainType', 
		bt.typeName AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		COALESCE(bt.minRarityId, 0) AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		COALESCE(bt.minRarityId, 0) AS 'minRarityId',
		COALESCE(bt.maxRarityId, 0) AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		COALESCE(bt.maxRarityId, 0) AS 'maxRarityId',
		COALESCE(bt.minImbuedRarityId, 0) AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		COALESCE(bt.minImbuedRarityId, 0) AS 'minImbuedRarityId',
		COALESCE(bt.maxImbuedRarityId, 0) AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		COALESCE(bt.maxImbuedRarityId, 0) AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	LEFT JOIN [content].[equipmentTypes] bt ON it.typeId = bt.parentTypeId
	WHERE it.type = 'Equipment'

	UNION

		SELECT
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		0 AS 'mainTypeId', 
		'None' AS 'mainType', 
		'None' AS 'mainTypeName', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		'None' AS 'classificationTypeName', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		'None' AS 'subTypeName',
		0 AS 'mainTypeMinRarityId',
		0 AS 'classificationTypeMinRarityId',
		0 AS 'subTypeMinRarityId',
		0 AS 'minRarityId',
		0 AS 'mainTypeMaxRarityId',
		0 AS 'classificationTypeMaxRarityId',
		0 AS 'subTypeMaxRarityId',
		0 AS 'maxRarityId',
		0 AS 'mainTypeMinImbuedRarityId',
		0 AS 'classificationTypeMinImbuedRarityId',
		0 AS 'subTypeMinImbuedRarityId',
		0 AS 'minImbuedRarityId',
		0 AS 'mainTypeMaxImbuedRarityId',
		0 AS 'classificationTypMaxImbuedRarityId',
		0 AS 'subTypeMaxImbuedRarityId',
		0 AS 'maxImbuedRarityId'
	FROM [content].[itemTypes] it
	WHERE it.type = 'None'

GO

