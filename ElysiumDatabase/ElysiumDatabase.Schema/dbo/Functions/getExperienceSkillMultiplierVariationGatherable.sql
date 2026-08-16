
CREATE FUNCTION [dbo].[getExperienceSkillMultiplierVariationGatherable](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel VARCHAR(100))
RETURNS  DECIMAL (5,2)
AS
BEGIN
    DECLARE @experienceMultiplierSkill DECIMAL (5,2)
	DECLARE @experienceMultiplierSkillQuantity DECIMAL (5,2)
	DECLARE @experienceMultiplierSkillImbued DECIMAL (5,2)
	DECLARE @experienceMultiplierSkillLocation DECIMAL (5,2)
	

	SELECT @experienceMultiplierSkillQuantity = edt.experienceMultiplierSkill, @experienceMultiplierSkillImbued = eit.experienceMultiplierSkill,
	@experienceMultiplierSkillLocation = eit.experienceMultiplierSkill
	FROM [content].[scriptableGatherablesSpawnable] ses
	JOIN [content].[scriptableGatherablesVariations] sev ON ses.variationId = sev.variationId AND ses.gatherableTypeId = sev.gatherableTypeId
	JOIN [content].[scriptableObjectLevels] sol ON ses.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[gatherableQuantityTypes] edt ON sev.gatherableQuantityTypeId = edt.typeId
	JOIN [content].[gatherableImbuedTypes] eit ON sev.gatherableImbuedTypeId = eit.typeId
	JOIN [content].[gatherableLocationTypes] crt ON sev.gatherableLocationTypeId = crt.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel

	SET @experienceMultiplierSkill =(@experienceMultiplierSkillQuantity - 1) + (@experienceMultiplierSkillImbued - 1) + (@experienceMultiplierSkillLocation - 1) + 1

    RETURN @experienceMultiplierSkill
END

GO

