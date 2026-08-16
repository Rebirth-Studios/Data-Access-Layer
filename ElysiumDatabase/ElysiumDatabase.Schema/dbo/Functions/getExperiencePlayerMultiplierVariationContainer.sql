
CREATE FUNCTION [dbo].[getExperiencePlayerMultiplierVariationContainer](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel VARCHAR(100))
RETURNS  DECIMAL (5,2)
AS
BEGIN
    declare @experienceMultiplierPlayerQuantity DECIMAL (5,2)
	declare @experienceMultiplierPlayerImbued DECIMAL (5,2)
	declare @experienceMultiplierPlayerRarity DECIMAL (5,2)
	declare @experienceMultiplierPlayer DECIMAL (5,2)

	SELECT @experienceMultiplierPlayerQuantity = edt.experienceMultiplierPlayer, @experienceMultiplierPlayerImbued = eit.experienceMultiplierPlayer,
	@experienceMultiplierPlayerRarity = eit.experienceMultiplierPlayer
	FROM [content].[scriptableContainersSpawnable] ses
	JOIN [content].[scriptableContainersVariations] sev ON ses.variationId = sev.variationId AND ses.containerTypeId = sev.containerTypeId
	JOIN [content].[scriptableObjectLevels] sol ON ses.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[containerQuantityTypes] edt ON sev.containerQuantityTypeId = edt.typeId
	JOIN [content].[containerImbuedTypes] eit ON sev.containerImbuedTypeId = eit.typeId
	JOIN [content].[containerRarityTypes] crt ON sev.containerRarityTypeId = crt.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel

	SET @experienceMultiplierPlayer =(@experienceMultiplierPlayerQuantity - 1) + (@experienceMultiplierPlayerImbued - 1) + (@experienceMultiplierPlayerRarity - 1) + 1

    RETURN @experienceMultiplierPlayer
END

GO

