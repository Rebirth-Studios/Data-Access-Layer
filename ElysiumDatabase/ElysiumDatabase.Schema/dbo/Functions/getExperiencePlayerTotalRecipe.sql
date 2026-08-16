CREATE FUNCTION [dbo].[getExperiencePlayerTotalRecipe](@globalObject varchar(100), @productGlobalObject varchar(100))
RETURNS DECIMAL (5,2)
AS
BEGIN
    DECLARE @experiencePlayerTotal DECIMAL (5,2)
	DECLARE @experiencePlayerBase DECIMAL (5,2)
	DECLARE @experiencePlayerMultiplierRecipe DECIMAL (5,2)
	DECLARE @experiencePlayerMultiplierImbued DECIMAL (5,2)
	
	SET @experiencePlayerMultiplierImbued = dbo.getItemExperiencePlayerMultiplierImbued(@productGlobalObject)

	SELECT @experiencePlayerMultiplierRecipe = experiencePlayerMultiplierRecipe, @experiencePlayerBase = experiencePlayerBase
	FROM [content].[scriptableRecipes] sr
	JOIN [content].[scriptableItems] si ON sr.productGlobalObject = si.globalObject
	JOIN [content].[scriptableSkills] ss ON sr.requiredSkillGlobalObject = ss.globalObject
	WHERE sr.globalObject = @globalObject


	SET @experiencePlayerTotal = @experiencePlayerBase * @experiencePlayerMultiplierRecipe * @experiencePlayerMultiplierImbued
    
    RETURN @experiencePlayerTotal
END

GO

