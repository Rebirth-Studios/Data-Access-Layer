CREATE FUNCTION [dbo].[getExperienceSkillMultiplierContainer](@globalObject varchar(100))
RETURNS int
AS
BEGIN
    declare @experienceMultiplierSkill INT
	declare @experienceMultiplierSkillSub INT
	declare @experienceMultiplierSkillClassification INT
	declare @experienceMultiplierSkillMain INT
	SELECT @experienceMultiplierSkillMain = ct.experienceMultiplierSkill, @experienceMultiplierSkillClassification = cct.experienceMultiplierSkill, @experienceMultiplierSkillSub = cst.experienceMultiplierSkill
	FROM [content].[scriptableContainersSpawnable] scs
	JOIN [content].[scriptableContainers] sc ON scs.globalObject = sc.globalObject
	JOIN [content].[containerTypes] ct ON sc.containerMainTypeId = ct.typeId
	JOIN [content].[containerClassificationTypes] cct ON sc.containerClassificationTypeId = cct.typeId
	JOIN [content].[containerSubTypes] cst ON sc.containerSubTypeId = cst.typeId
	where scs.globalObject = @globalObject
	IF (@experienceMultiplierSkillSub > 0) SET @experienceMultiplierSkill = @experienceMultiplierSkillSub
	ELSE IF (@experienceMultiplierSkillClassification > 0) SET @experienceMultiplierSkill = @experienceMultiplierSkillClassification
	ELSE SET @experienceMultiplierSkill = @experienceMultiplierSkillMain

    RETURN @experienceMultiplierSkill
END

GO

