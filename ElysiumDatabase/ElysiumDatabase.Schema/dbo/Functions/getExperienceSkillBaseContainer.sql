CREATE FUNCTION [dbo].[getExperienceSkillBaseContainer](@globalObject varchar(100))
RETURNS Decimal(18,2)
AS
BEGIN
    declare @experienceBaseSkill Decimal(18,2)
	SELECT @experienceBaseSkill = sct.experienceBaseSkill
	FROM [content].[scriptableContainersSpawnable] scs
	JOIN [content].[scriptableInteractables] si ON scs.globalObject = si.globalObject
	JOIN [content].[scriptableSkills] ss ON si.interactableRequiredSkillGlobalObject = ss.globalObject
	JOIN [content].[skillCategoryTypes] sct ON ss.skillCategoryTypeId = sct.typeId
	where scs.globalObject = @globalObject
    RETURN @experienceBaseSkill
END

GO

