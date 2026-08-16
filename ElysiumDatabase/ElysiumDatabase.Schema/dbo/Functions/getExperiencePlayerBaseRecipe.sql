CREATE FUNCTION [dbo].[getExperiencePlayerBaseRecipe](@requiredSkillGlobalObject varchar(100))
RETURNS Decimal(5,2)
AS
BEGIN
    DECLARE @experiencePlayerBase Decimal(5,2)

	SELECT @experiencePlayerBase = experiencePlayerBase
	FROM [content].[scriptableSkills]
	where globalObject = @requiredSkillGlobalObject

    RETURN @experiencePlayerBase
END

GO

