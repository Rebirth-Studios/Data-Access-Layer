



CREATE PROCEDURE [dbo].[spUnlockEffects]
	
AS
	SELECT 
	ue.globalObject,
	ue.unlockGlobalObject,
	ue.unlockEffectTypeId,
	ue.unlockRankId,
	ue.unlockLevelId,
	ue.experienceGain,
	glo.globalObjectName,
	glo2.globalObjectName AS 'unlockGlobalObjectName',
	uet.typeName AS 'unlockEffectTypeName',
	glo.globalTierId
	FROM [content].[unlockEffects] ue
	JOIN [content].[globalObjects] glo ON ue.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON ue.unlockGlobalObject = glo2.globalObject
	JOIN [content].[unlockEffectTypes] uet ON ue.unlockEffectTypeId = uet.typeId

GO

