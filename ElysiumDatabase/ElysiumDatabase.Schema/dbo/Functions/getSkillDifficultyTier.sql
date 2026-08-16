
CREATE FUNCTION [dbo].[getSkillDifficultyTier](@skillDifficultyTierId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @skillDifficultyTier VARCHAR(255)

	SELECT @skillDifficultyTier = skillDifficultyTier
	FROM [content].[skillDifficultyTiers]
	WHERE skillDifficultyTierId = @skillDifficultyTierId

    RETURN @skillDifficultyTier
END

GO

