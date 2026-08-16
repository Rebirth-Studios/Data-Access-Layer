



CREATE PROCEDURE [dbo].[spExperienceEffects]
	
AS
	SELECT 
	ee.experienceEffectId,
	ee.globalObject,
	ee.experienceEffectTypeId,
	ee.experienceGain,
	ee.minTierId,
	ee.maxTierId,
	ee.experienceEffectGlobalObject,
	ee.effectAmountTypeId,
	glo.globalObjectName,
	glo2.globalObjectName AS 'experienceEffectGlobalObjectName',
	gt1.typeName AS 'minTierName',
	gt2.typeName AS 'maxTierName',
	eet.typeName AS 'experienceEffectType',
	eat.typeName AS 'effectAmountType',
	glo.globalTierId
	FROM [content].[experienceEffects] ee
	JOIN [content].[globalObjects] glo ON ee.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON ee.experienceEffectGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt1 ON ee.minTierId = gt1.typeId
	JOIN [content].[globalTiers] gt2 ON ee.maxTierId = gt2.typeId
	JOIN [content].[experienceEffectTypes] eet ON ee.experienceEffectTypeId = eet.typeId
	JOIN [content].[effectAmountTypes] eat ON ee.effectAmountTypeId = eat.typeId

GO

