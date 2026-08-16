

CREATE FUNCTION [dbo].[getContainerRarityTypeName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = crt.typeName
	FROM [content].[containerRarityTypes] crt
	WHERE crt.typeId = @typeId

    RETURN @type
END

GO

