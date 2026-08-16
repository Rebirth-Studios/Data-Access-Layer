CREATE FUNCTION [dbo].[getExperienceSkillTotalRecipe](@globalObject varchar(100), @productGlobalObject varchar(100))
RETURNS DECIMAL (5,2)
AS
BEGIN
    DECLARE @experienceSkillTotal DECIMAL (5,2)
	DECLARE @experienceSkillBase DECIMAL (5,2)
	DECLARE @experienceSkillMultiplierRecipe DECIMAL (5,2)
	DECLARE @experienceSkillMultiplierImbued DECIMAL (5,2)
	
	SET @experienceSkillMultiplierImbued = dbo.getItemExperienceSkillMultiplierImbued(@productGlobalObject)

	SELECT @experienceSkillMultiplierRecipe = experienceSkillMultiplierRecipe, @experienceSkillBase = experienceSkillBase
	FROM [content].[scriptableRecipes] sr
	JOIN [content].[scriptableItems] si ON sr.productGlobalObject = si.globalObject
	JOIN [content].[scriptableSkills] ss ON sr.requiredSkillGlobalObject = ss.globalObject
	WHERE sr.globalObject = @globalObject


	SET @experienceSkillTotal = @experienceSkillBase * @experienceSkillMultiplierRecipe * @experienceSkillMultiplierImbued
    
    RETURN @experienceSkillTotal
END

GO

