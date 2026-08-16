

CREATE PROCEDURE [dbo].[spScriptableBags]
	
AS
	

SELECT
	sc.globalObject,
	sc.bagMainTypeId,
	sc.bagClassificationTypeId,
	sc.bagSubTypeId,
	sc.description,
	sc.slots,
	glo.globalObjectName AS 'globalObjectName',
	ct.typeName AS 'mainTypeName',
	cct.typeName AS 'classificationTypeName',
	cst.typeName AS 'subTypeName',
	glo.globalTierId
	--sir.rarityId
	FROM [content].[scriptableBags] sc
	JOIN [content].[globalObjects] glo ON sc.globalObject = glo.globalObject
	--JOIN [content].[scriptableItemRarities] sir ON sc.globalObject = sir.globalObject
	JOIN [content].[bagTypes] ct ON sc.bagMainTypeId = ct.typeId
	JOIN [content].[bagClassificationTypes] cct ON sc.bagClassificationTypeId = cct.typeId
	JOIN [content].[bagSubTypes] cst ON sc.bagSubTypeId = cst.typeId

GO

