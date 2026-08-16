CREATE PROCEDURE [dbo].[spScriptableAmmunition]
	
AS
	

SELECT
	sc.globalObject,
	sc.ammunitionMainTypeId,
	sc.ammunitionClassificationTypeId,
	sc.ammunitionSubTypeId,
	sc.description,
	glo.globalObjectName AS 'globalObjectName',
	ct.typeName AS 'mainTypeName',
	cct.typeName AS 'classificationTypeName',
	cst.typeName AS 'subTypeName'
	FROM [content].[scriptableAmmunition] sc
	JOIN [content].[globalObjects] glo ON sc.globalObject = glo.globalObject
	JOIN [content].[ammunitionTypes] ct ON sc.ammunitionMainTypeId = ct.typeId
	JOIN [content].[ammunitionClassificationTypes] cct ON sc.ammunitionClassificationTypeId = cct.typeId
	JOIN [content].[ammunitionSubTypes] cst ON sc.ammunitionSubTypeId = cst.typeId

GO

