

CREATE PROCEDURE [dbo].[spScriptableMaterials]
	
AS
	

SELECT
	sc.globalObject,
	sc.materialMainTypeId,
	sc.materialClassificationTypeId,
	sc.materialSubTypeId,
	sc.description,
	sc.materialDifficultyPoints,
	sc.ingredientName,
	glo.globalObjectName AS 'globalObjectName',
	ct.typeName AS 'mainTypeName',
	cct.typeName AS 'classificationTypeName',
	cst.typeName AS 'subTypeName',
	glo.globalTierId
	FROM [content].[scriptableMaterials] sc
	JOIN [content].[globalObjects] glo ON sc.globalObject = glo.globalObject
	JOIN [content].[materialTypes] ct ON sc.materialMainTypeId = ct.typeId
	JOIN [content].[materialClassificationTypes] cct ON sc.materialClassificationTypeId = cct.typeId
	JOIN [content].[materialSubTypes] cst ON sc.materialSubTypeId = cst.typeId

GO

