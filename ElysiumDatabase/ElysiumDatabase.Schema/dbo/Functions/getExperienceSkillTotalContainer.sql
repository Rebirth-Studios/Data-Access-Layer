CREATE FUNCTION [dbo].[getExperienceSkillTotalContainer](@globalObject varchar(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS DECIMAL (5,2)
AS
BEGIN
    declare @experienceTotalSkill DECIMAL (5,2)
	declare @experienceBaseSkill DECIMAL (5,2)
	declare @experienceMultiplierSkillType DECIMAL (5,2)
	declare @experienceMultiplierSkillVariation DECIMAL (5,2)
	
	SET @experienceBaseSkill = dbo.getExperienceSkillBaseContainer(@globalObject);
	SET @experienceMultiplierSkillType = dbo.getExperienceSkillMultiplierContainer(@globalObject);
	SET @experienceMultiplierSkillVariation = dbo.getExperienceSkillMultiplierVariationContainer(@globalObject, @variationId, @scriptableObjectLevel);

	SET @experienceTotalSkill = @experienceBaseSkill * @experienceMultiplierSkillType * @experienceMultiplierSkillVariation
    
    RETURN @experienceTotalSkill
END

GO

