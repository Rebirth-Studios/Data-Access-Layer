

CREATE FUNCTION [dbo].[getPrefabSearchId](@prefabSearchName VARCHAR(255))
RETURNS TINYINT
AS
BEGIN
    DECLARE @typeId VARCHAR(255)

	SELECT @typeId = id
	FROM [content].[prefabSearches]
	WHERE prefabSearchName = @prefabSearchName

    RETURN @typeId
END

GO

