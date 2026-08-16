CREATE FUNCTION [dbo].[getVariationIdFromScriptableObjectSpawnable](@scriptableObjectSpawnable VARCHAR(100))
RETURNS TINYINT
AS
BEGIN
    DECLARE @variationId TINYINT
	
	SELECT @variationId = variationId
	FROM [content].[scriptableObjectSpawnables]
	WHERE scriptableObjectSpawnable = @scriptableObjectSpawnable

    RETURN @variationId
END

GO

