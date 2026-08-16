

CREATE FUNCTION [dbo].[getEntityDifficultyTypeNameFromVariationId](@variationId TINYINT, @entityTypeId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = sEV.entityDifficultyTypeName
	FROM [content].[scriptableEntitiesVariations] sEV
	WHERE sEV.variationId = @variationId AND sEV.entityTypeId = @entityTypeId

    RETURN @type
END

GO

