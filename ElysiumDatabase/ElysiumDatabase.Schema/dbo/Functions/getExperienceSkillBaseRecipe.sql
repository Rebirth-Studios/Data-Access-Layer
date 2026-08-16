CREATE FUNCTION [dbo].[getExperienceSkillBaseRecipe](@requiredSkillGlobalObject varchar(100))
RETURNS Decimal(5,2)
AS
BEGIN
    DECLARE @experienceSkillBase Decimal(5,2)

	SELECT @experienceSkillBase = experienceSkillBase
	FROM [content].[scriptableSkills]
	where globalObject = @requiredSkillGlobalObject

    RETURN @experienceSkillBase
END

GO

