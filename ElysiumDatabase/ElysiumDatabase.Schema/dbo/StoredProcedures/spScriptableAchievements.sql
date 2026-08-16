




CREATE PROCEDURE [dbo].[spScriptableAchievements]
	
AS

	SELECT 
	sa.globalObject,
	sa.achievementFactionId,
	sa.achievementIsUnique,
	sa.achievementDescription,
	sa.achievementTypeId,
	glo.globalObjectName,
	gf.typeName AS 'achievementFaction',
	aty.typeName AS 'mainTypeName'
	FROM [content].[scriptableAchievements] sa
	JOIN [content].[globalObjects] glo ON sa.globalObject = glo.globalObject
	JOIN [content].[globalFactions] gf ON sa.achievementFactionId = gf.typeId
	JOIN [content].[achievementTypes] aty ON sa.achievementTypeId = aty.typeId

GO

