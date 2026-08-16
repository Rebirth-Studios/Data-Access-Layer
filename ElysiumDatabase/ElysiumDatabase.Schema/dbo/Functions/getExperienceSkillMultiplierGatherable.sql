CREATE FUNCTION [dbo].[getExperienceSkillMultiplierGatherable](@globalObject varchar(100))
RETURNS int
AS
BEGIN
    DECLARE @experienceMultiplierSkill INT
	DECLARE @experienceMultiplierSkillSub INT
	DECLARE @experienceMultiplierSkillClassification INT
	DECLARE @experienceMultiplierSkillMain INT

	SELECT @experienceMultiplierSkillMain = ct.experienceMultiplierSkill, @experienceMultiplierSkillClassification = cct.experienceMultiplierSkill, @experienceMultiplierSkillSub = cst.experienceMultiplierSkill
	FROM [content].[scriptableGatherablesSpawnable] scs
	JOIN [content].[scriptableGatherables] sc ON scs.globalObject = sc.globalObject
	JOIN [content].[gatherableTypes] ct ON sc.gatherableTypeId = ct.typeId
	JOIN [content].[gatherableClassificationTypes] cct ON sc.gatherableClassificationTypeId = cct.typeId
	JOIN [content].[gatherableSubTypes] cst ON sc.gatherableSubTypeId = cst.typeId
	where scs.globalObject = @globalObject
	IF (@experienceMultiplierSkillSub > 0) SET @experienceMultiplierSkill = @experienceMultiplierSkillSub
	ELSE IF (@experienceMultiplierSkillClassification > 0) SET @experienceMultiplierSkill = @experienceMultiplierSkillClassification
	ELSE SET @experienceMultiplierSkill = @experienceMultiplierSkillMain

    RETURN @experienceMultiplierSkill
END

GO

