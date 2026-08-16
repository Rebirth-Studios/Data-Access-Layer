
CREATE FUNCTION [dbo].[getPrefabSearchName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = prefabSearchName
	FROM [content].[prefabSearches]
	WHERE id = @typeId

    RETURN @type
END

GO

