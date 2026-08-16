




CREATE PROCEDURE [dbo].[spStatEffects]
	
AS
	SELECT 
	ue.statEffectGlobalObject,
	ue.statId,
	ue.statTypeId,
	ue.statEffectAmount,
	ue.statEffectAmountTypeId,
	eat.typeName AS 'statEffectAmountType',
	st.typeName AS 'statTypeName',
	sts.statName AS 'statName',
	glo.globalObjectName,
	dbo.getStatEffectName(ue.statEffectAmount, ue.statEffectAmountTypeId, ue.statId, ue.statTypeId) AS statEffectDescription,
	glo.globalTierId,
	sn.typeId AS 'statNameTypeId'
	FROM [content].[statEffects] ue
	LEFT JOIN [content].[globalObjects] glo ON ue.statEffectGlobalObject = glo.globalObject
	LEFT JOIN [content].[statTypes] st ON ue.statTypeId = st.typeId
	LEFT JOIN [content].[effectAmountTypes] eat ON ue.statEffectAmountTypeId = eat.typeId
	LEFT JOIN [content].[stats] sts ON ue.statId = sts.statId AND ue.statTypeId = sts.statTypeId
	LEFT JOIN [content].[statNames] sn ON sts.stat = sn.type

GO

