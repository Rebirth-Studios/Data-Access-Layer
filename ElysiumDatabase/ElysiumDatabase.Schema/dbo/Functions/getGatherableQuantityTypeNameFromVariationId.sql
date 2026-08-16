

CREATE FUNCTION [dbo].[getGatherableQuantityTypeNameFromVariationId](@variationId TINYINT, @gatherableTypeId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = sGV.gatherableQuantityTypeName
	FROM [content].[scriptableGatherablesVariations] sGV
	WHERE sGV.variationId = @variationId AND sGV.gatherableTypeId = gatherableTypeId

    RETURN @type
END

GO

