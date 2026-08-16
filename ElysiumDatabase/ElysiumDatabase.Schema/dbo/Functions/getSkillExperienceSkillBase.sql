CREATE FUNCTION [dbo].[getSkillExperienceSkillBase](@skillCategoryTypeId tinyint)
RETURNS int
AS
BEGIN
    declare @experienceBaseSkill INT
	SELECT @experienceBaseSkill = experienceBaseSkill from [content].[skillCategoryTypes] where typeId = @skillCategoryTypeId
    RETURN @experienceBaseSkill
END

GO

