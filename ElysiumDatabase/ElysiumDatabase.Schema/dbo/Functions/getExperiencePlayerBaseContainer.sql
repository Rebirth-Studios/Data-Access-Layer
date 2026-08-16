CREATE FUNCTION [dbo].[getExperiencePlayerBaseContainer](@globalObject varchar(100))
RETURNS Decimal(18,2)
AS
BEGIN
    declare @experienceBasePlayer Decimal(18,2)
	SELECT @experienceBasePlayer = sct.experienceBasePlayer
	FROM [content].[scriptableContainersSpawnable] scs
	JOIN [content].[scriptableInteractables] si ON scs.globalObject = si.globalObject
	JOIN [content].[scriptableSkills] ss ON si.interactableRequiredSkillGlobalObject = ss.globalObject
	JOIN [content].[skillCategoryTypes] sct ON ss.skillCategoryTypeId = sct.typeId
	where scs.globalObject = @globalObject
    RETURN @experienceBasePlayer
END

GO

