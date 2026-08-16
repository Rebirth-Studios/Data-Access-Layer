
CREATE FUNCTION [dbo].[getExperiencePlayerMultiplierVariationGatherable](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel VARCHAR(100))
RETURNS  DECIMAL (5,2)
AS
BEGIN
    declare @experienceMultiplierPlayerQuantity DECIMAL (5,2)
	declare @experienceMultiplierPlayerImbued DECIMAL (5,2)
	declare @experienceMultiplierPlayerLocation DECIMAL (5,2)
	declare @experienceMultiplierPlayer DECIMAL (5,2)

	SELECT @experienceMultiplierPlayerQuantity = edt.experienceMultiplierPlayer, @experienceMultiplierPlayerImbued = eit.experienceMultiplierPlayer,
	@experienceMultiplierPlayerLocation = eit.experienceMultiplierPlayer
	FROM [content].[scriptableGatherablesSpawnable] ses
	JOIN [content].[scriptableGatherablesVariations] sev ON ses.variationId = sev.variationId AND ses.gatherableTypeId = sev.gatherableTypeId
	JOIN [content].[scriptableObjectLevels] sol ON ses.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[gatherableQuantityTypes] edt ON sev.gatherableQuantityTypeId = edt.typeId
	JOIN [content].[gatherableImbuedTypes] eit ON sev.gatherableImbuedTypeId = eit.typeId
	JOIN [content].[gatherableLocationTypes] crt ON sev.gatherableLocationTypeId = crt.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel

	SET @experienceMultiplierPlayer =(@experienceMultiplierPlayerQuantity - 1) + (@experienceMultiplierPlayerImbued - 1) + (@experienceMultiplierPlayerLocation - 1) + 1

    RETURN @experienceMultiplierPlayer
END

GO

