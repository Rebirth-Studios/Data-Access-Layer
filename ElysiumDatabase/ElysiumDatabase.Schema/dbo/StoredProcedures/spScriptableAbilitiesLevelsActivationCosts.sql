

CREATE PROCEDURE [dbo].[spScriptableAbilitiesLevelsActivationCosts]
	
AS
	SELECT 
	sa.globalObject,
	sa.cost,
	sa.costTypeId,
	sa.statTypeId,
	sa.statId,
	sa.costTimes,
	sa.timeBetweenCosts,
	sa.scriptableObjectLevel,
	sa.currentStatTypeId,
	sa.levelId,
	sol.scriptableObjectLevelName,
	glo.globalObjectName,
	cst.typeName AS 'currentStatTypeName',
	st.typeName AS 'statTypeName',
	ct.typeName AS 'costTypeName',
	sn.typeName AS 'statName'
	FROM [content].[scriptableAbilitiesLevelsActivationCosts] sa
	JOIN [content].[scriptableObjectLevels] sol ON sa.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[globalObjects] glo ON sol.globalObject = glo.globalObject
	JOIN [content].[currentStatTypes] cst ON sa.currentStatTypeId = cst.typeId
	JOIN [content].[statTypes] st ON sa.statTypeId = st.typeId
	JOIN [content].[costTypes] ct ON sa.costTypeId = ct.typeId
	LEFT JOIN [content].[stats] sts ON sa.statId = sts.statId AND sa.statTypeId = sts.statTypeId
	LEFT JOIN [content].[statNames] sn ON sts.stat = sn.type

GO

