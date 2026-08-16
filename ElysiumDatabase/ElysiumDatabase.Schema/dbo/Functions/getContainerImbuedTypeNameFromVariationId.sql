

CREATE FUNCTION [dbo].[getContainerImbuedTypeNameFromVariationId](@variationId TINYINT, @containerTypeId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = sCV.containerImbuedTypeName
	FROM [content].[scriptableContainersVariations] sCV
	WHERE sCV.variationId = @variationId AND sCV.containerTypeId = @containerTypeId

    RETURN @type
END

GO

