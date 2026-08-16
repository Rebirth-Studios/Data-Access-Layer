

CREATE PROCEDURE [dbo].[spEffectGroupsToGearSetsMapping]
	
AS
	SELECT
	gearSetGlobalObject,
	pieces,
	effectGroupGlobalObject,
	glo.globalObjectName,
	glo2.globalObjectName AS effectGroupGlobalObjectName,
	toolTipText,
	egt.scriptableObjectLevel,
	sol.scriptableObjectLevelName,
	sol.levelId
FROM [content].[effectGroupsToGearSetsMapping] egt
JOIN [content].[globalObjects] glo ON egt.gearSetGlobalObject = glo.globalObject 
JOIN [content].[globalObjects] glo2 ON egt.effectGroupGlobalObject = glo2.globalObject 
JOIN [content].[scriptableObjectLevels] sol ON egt.scriptableObjectLevel = sol.scriptableObjectLevel

GO

