CREATE FUNCTION [dbo].[getSpecialEventType](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[specialEventTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

