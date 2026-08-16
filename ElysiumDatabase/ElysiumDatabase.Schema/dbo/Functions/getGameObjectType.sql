CREATE FUNCTION [dbo].[getGameObjectType](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = type
	FROM [content].[gameObjectTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

