CREATE FUNCTION [dbo].[getAbilityDifficultyTier](@tierId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = abilityDifficultyTier
	FROM [content].[abilityDifficultyTiers]
	WHERE abilityDifficultyTierId = @tierId

    RETURN @type
END

GO

