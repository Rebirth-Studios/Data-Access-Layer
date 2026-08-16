CREATE FUNCTION [dbo].[getSkillExperiencePlayerBase](@skillCategoryTypeId tinyint)
RETURNS int
AS
BEGIN
    declare @experienceBasePlayer INT
	SELECT @experienceBasePlayer = experienceBasePlayer from [content].[skillCategoryTypes] where typeId = @skillCategoryTypeId
    RETURN @experienceBasePlayer
END

GO

