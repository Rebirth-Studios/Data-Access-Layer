



CREATE PROCEDURE [dbo].[spEffectGroups]
	
AS
	SELECT 
	eg.effectGroupGlobalObject,
	eg.damageCancels,
	eg.duration,
	eg.applicationTypeId,
	eg.numTimesApplied,
	eg.timeBetweenApplications,
	eg.removeWhenEffectEnds,
	eg.maxStacks,
	eg.[description],
	glo.globalObjectName,
	ap.typeName AS 'applicationType',
	glo.globalObjectName AS 'effectGroupName',
	eg.effectGroupTypeId,
	egt.typeName AS 'effectGroupTypeName', 
	eg.effectGroupClassificationTypeId,
	egct.typeName AS 'effectGroupClassificationTypeName',
	glo.globalTierId
	FROM [content].[effectGroups] eg
	JOIN [content].[globalObjects] glo ON eg.effectGroupGlobalObject = glo.globalObject
	JOIN [content].[applicationTypes] ap ON eg.applicationTypeId = ap.typeId
	JOIN [content].[effectGroupTypes] egt ON eg.effectGroupTypeId = egt.typeId
	JOIN [content].[effectGroupClassificationTypes] egct ON eg.effectGroupClassificationTypeId = egct.typeId

GO

