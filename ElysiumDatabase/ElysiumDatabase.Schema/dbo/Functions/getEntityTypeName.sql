CREATE FUNCTION [dbo].[getEntityTypeName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[entityTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

