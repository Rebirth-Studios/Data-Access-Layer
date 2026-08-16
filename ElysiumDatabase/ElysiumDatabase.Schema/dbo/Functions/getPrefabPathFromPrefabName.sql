CREATE FUNCTION [dbo].[getPrefabPathFromPrefabName](@prefabName VARCHAR(100))
RETURNS varchar(1000)
AS
BEGIN
    DECLARE @prefabPath varchar(1000)
	
	SELECT @prefabPath = prefabPath
	FROM [content].[scriptablePrefabs]
	WHERE prefabName = @prefabName

    RETURN @prefabPath
END

GO

