


CREATE PROCEDURE [dbo].[spEntityStats]
	
AS
	SELECT
	es.globalObject, 
	es.scriptableObjectSpawnable,
	es.statId,
	es.statTypeId,
	es.statInitialValue,
	es.isCustom,
	sbt.statInitialValue AS statBase, 
	sme.multiplier AS statMultiplierType,
	smi.multiplier AS statMultiplierImbued,
	smd.multiplier AS statMultiplierDifficulty,
	(sbt.statInitialValue * sme.multiplier * smi.multiplier * smd.multiplier * sbl.multiplier) AS 'statTotal',
	sos.variationId, 
	sbl.multiplier AS statMultiplierLevel,
	sos.scriptableObjectSpawnableName,  
	glo.globalObjectName, 
	es.levelId, 
	sts.stat, 
	sts.statName, 
	st.typeName AS 'statTypeName'
	FROM [content].[entityStats] es 
	JOIN [content].[globalObjects] glo ON es.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectSpawnables] sos ON es.scriptableObjectSpawnable = sos.scriptableObjectSpawnable
	JOIN [content].[statsBaseTiers] sbt ON glo.globalTierId = sbt.globalTierId AND sbt.statId = es.statId AND sbt.statTypeId = es.statTypeId
	JOIN [content].[statTypes] st ON es.statTypeId = st.typeId
	JOIN [content].[stats] sts ON sts.statId = es.statId AND sts.statTypeId = es.statTypeId
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[statsBaseLevels] sbl ON sol.levelId = sbl.levelId AND sbl.statId = es.statId AND sbl.statTypeId = es.statTypeId
	JOIN [content].[scriptableEntities] se ON se.globalObject = es.globalObject
	JOIN scriptableEntitiesView sa ON es.globalObject = sa.globalObject
	JOIN [content].[entityTypes] et ON se.entityTypeId = et.typeId
	JOIN [content].[scriptableEntitiesVariations] sev ON sos.variationId = sev.variationId AND se.entityTypeId = sev.entityTypeId
	JOIN [content].[statsMultiplierDifficultyType] smd ON es.statId = smd.statId AND es.statTypeId = smd.statTypeId AND sev.entityDifficultyTypeId = smd.entityDifficultyTypeId
	JOIN [content].[statsMultiplierImbuedType] smi ON es.statId = smi.statId AND es.statTypeId = smi.statTypeId AND sev.entityImbuedTypeId = smi.entityImbuedTypeId
	JOIN [content].[statsMultiplierEntities] sme ON se.entityTypeId = sme.entityTypeId AND es.statId = sme.statId AND es.statTypeId = sme.statTypeId AND sa.mainTypeId = sme.mainTypeId AND sa.classificationTypeId = sme.classificationTypeId AND sa.subTypeId = sme.subTypeId
	ORDER BY globalObject, levelId, variationId, statTypeId, statId

GO

