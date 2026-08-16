CREATE PROCEDURE [dbo].[spBodyPartMultipliers]
	
AS
	

SELECT
	bpm.bodyPartTypeId,
	bpm.multiplierValue,
	bpm.globalObject,
	glo.globalObjectName AS 'globalObjectName',
	bpt.typeName AS 'bodyPartType'
	FROM [content].[bodyPartMultipliers] bpm
	JOIN [content].[globalObjects] glo ON bpm.globalObject = glo.globalObject
	JOIN [content].[bodyPartTypes] bpt ON bpm.bodyPartTypeId = bpt.typeId

GO

