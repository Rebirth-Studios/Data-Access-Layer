
CREATE FUNCTION [dbo].[getExperienceSkillMultiplierVariationContainer](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel VARCHAR(100))
RETURNS  DECIMAL (5,2)
AS
BEGIN
    declare @experienceMultiplierSkillQuantity DECIMAL (5,2)
	declare @experienceMultiplierSkillImbued DECIMAL (5,2)
	declare @experienceMultiplierSkillRarity DECIMAL (5,2)
	declare @experienceMultiplierSkill DECIMAL (5,2)

	SELECT @experienceMultiplierSkillQuantity = edt.experienceMultiplierSkill, @experienceMultiplierSkillImbued = eit.experienceMultiplierSkill,
	@experienceMultiplierSkillRarity = eit.experienceMultiplierSkill
	FROM [content].[scriptableContainersSpawnable] ses
	JOIN [content].[scriptableContainersVariations] sev ON ses.variationId = sev.variationId AND ses.containerTypeId = sev.containerTypeId
	JOIN [content].[scriptableObjectLevels] sol ON ses.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[containerQuantityTypes] edt ON sev.containerQuantityTypeId = edt.typeId
	JOIN [content].[containerImbuedTypes] eit ON sev.containerImbuedTypeId = eit.typeId
	JOIN [content].[containerRarityTypes] crt ON sev.containerRarityTypeId = crt.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel

	SET @experienceMultiplierSkill =(@experienceMultiplierSkillQuantity - 1) + (@experienceMultiplierSkillImbued - 1) + (@experienceMultiplierSkillRarity - 1) + 1

    RETURN @experienceMultiplierSkill
END

GO

