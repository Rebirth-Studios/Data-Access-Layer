

CREATE PROCEDURE [dbo].[spEffectGroupsLevels]
	
AS
	SELECT
	effectGroupGlobalObject,
	glo.globalObjectName,
	egl.scriptableObjectLevel,
	sol.scriptableObjectLevelName,
	sol.levelId
FROM [content].[effectGroupsLevels] egl
JOIN [content].[scriptableObjectLevels] sol ON egl.scriptableObjectLevel = sol.scriptableObjectLevel
JOIN [content].[globalObjects] glo ON egl.effectGroupGlobalObject = glo.globalObject

GO

