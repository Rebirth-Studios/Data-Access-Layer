CREATE FUNCTION [dbo].[getPrefabNameFromPrefabPath](@prefabPath VARCHAR(100))
RETURNS varchar(1000)
AS
BEGIN
    DECLARE @prefabName varchar(255)
	
	SELECT @prefabName = sp.prefabName
	FROM [content].[scriptablePrefabs] sp
	WHERE prefabPath = @prefabPath

    RETURN @prefabName
END

GO

