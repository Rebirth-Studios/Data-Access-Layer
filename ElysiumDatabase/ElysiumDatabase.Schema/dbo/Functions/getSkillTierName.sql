

CREATE FUNCTION [dbo].[getSkillTierName](@skillTierId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @skillTier VARCHAR(255)

	SELECT @skillTier = typeName
	FROM [content].[skillTiers]
	WHERE typeId = @skillTierId

    RETURN @skillTier
END

GO

