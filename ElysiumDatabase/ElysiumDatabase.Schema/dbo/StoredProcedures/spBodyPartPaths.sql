CREATE PROCEDURE [dbo].[spBodyPartPaths]
	
AS
	

SELECT
	bpp.bodyPartTypeId,
	bpp.bodyPartPath,
	bpp.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	bpt.typeName AS 'bodyPartType'
	FROM [content].[bodyPartPaths] bpp
	JOIN [content].[globalObjects] glo ON bpp.globalObject = glo.globalObject
	JOIN [content].[bodyPartTypes] bpt ON bpp.bodyPartTypeId = bpt.typeId

GO

