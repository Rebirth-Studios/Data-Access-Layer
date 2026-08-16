
CREATE FUNCTION [dbo].[getIconSearchName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = iconSearchName
	FROM [content].[iconSearches]
	WHERE id = @typeId

    RETURN @type
END

GO

