CREATE PROCEDURE [dbo].[spScriptableGeneralItems]
	
AS
	

SELECT
	sc.globalObject,
	sc.generalItemMainTypeId,
	sc.generalItemClassificationTypeId,
	sc.generalItemSubTypeId,
	sc.generalItemDescription,
	glo.globalObjectName AS 'globalObjectName',
	ct.typeName AS 'mainTypeName',
	cct.typeName AS 'classificationTypeName',
	cst.typeName AS 'subTypeName'
	FROM [content].[scriptableGeneralItems] sc
	JOIN [content].[globalObjects] glo ON sc.globalObject = glo.globalObject
	JOIN [content].[generalItemTypes] ct ON sc.generalItemMainTypeId = ct.typeId
	JOIN [content].[generalItemClassificationTypes] cct ON sc.generalItemClassificationTypeId = cct.typeId
	JOIN [content].[generalItemSubTypes] cst ON sc.generalItemSubTypeId = cst.typeId

GO

