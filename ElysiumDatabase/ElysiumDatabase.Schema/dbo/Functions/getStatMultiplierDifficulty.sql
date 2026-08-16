
CREATE FUNCTION [dbo].[getStatMultiplierDifficulty](@scriptableObjectSpawnable VARCHAR(100), @statId tinyint, @statTypeId tinyint)
RETURNS  DECIMAL (5,2)
AS
BEGIN
    DECLARE @multiplier DECIMAL (5,2)
	DECLARE @entityDifficultyTypeId tinyint

	SELECT @entityDifficultyTypeId = entityDifficultyTypeId
	FROM [content].[scriptableEntitiesSpawnable] ses
	JOIN [content].[scriptableEntitiesVariations] sev ON ses.variationId = sev.variationId AND ses.entityTypeId = sev.entityTypeId
	WHERE ses.scriptableObjectSpawnable = @scriptableObjectSpawnable

	SELECT @multiplier = multiplier
	FROM [content].[statsMultiplierDifficultyType] seh
	WHERE statId = @statId AND statTypeId = @statTypeId AND entityDifficultyTypeId = @entityDifficultyTypeId
	
    RETURN @multiplier
END

GO

