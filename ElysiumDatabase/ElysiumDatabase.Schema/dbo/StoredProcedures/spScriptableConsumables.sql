CREATE PROCEDURE [dbo].[spScriptableConsumables]
	
AS
	

SELECT
	sc.globalObject,
	sc.consumableMainTypeId,
	sc.consumableClassificationTypeId,
	sc.consumableSubTypeId,
	sc.description,
	glo.globalObjectName AS 'globalObjectName',
	ct.typeName AS 'mainTypeName',
	cct.typeName AS 'classificationTypeName',
	cst.typeName AS 'subTypeName'
	FROM [content].[scriptableConsumables] sc
	JOIN [content].[globalObjects] glo ON sc.globalObject = glo.globalObject
	JOIN [content].[consumableTypes] ct ON sc.consumableMainTypeId = ct.typeId
	JOIN [content].[consumableClassificationTypes] cct ON sc.consumableClassificationTypeId = cct.typeId
	JOIN [content].[consumableSubTypes] cst ON sc.consumableSubTypeId = cst.typeId

GO

