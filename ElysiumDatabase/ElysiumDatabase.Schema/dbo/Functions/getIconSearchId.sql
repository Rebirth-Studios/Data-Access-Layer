

CREATE FUNCTION [dbo].[getIconSearchId](@iconSearchName VARCHAR(255))
RETURNS TINYINT
AS
BEGIN
    DECLARE @typeId VARCHAR(255)

	SELECT @typeId = id
	FROM [content].[iconSearches]
	WHERE iconSearchName = @iconSearchName

    RETURN @typeId
END

GO

