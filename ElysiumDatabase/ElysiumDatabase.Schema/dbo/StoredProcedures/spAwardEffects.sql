




CREATE PROCEDURE [dbo].[spAwardEffects]
	
AS

	SELECT 
	ae.globalObject,
	awardGlobalObject,
	awardEffectTypeId,
	glo.globalObjectName,
	glo2.globalObjectName AS 'awardGlobalObjectName',
	aet.type AS 'awardEffectType',
	glo.globalTierId
	FROM [content].[awardEffects] ae
	JOIN [content].[globalObjects] glo ON ae.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON ae.awardGlobalObject = glo2.globalObject
	JOIN [content].[awardEffectTypes] aet ON ae.awardEffectTypeId = aet.typeId

GO

