CREATE FUNCTION [dbo].[getLevelIdFromScriptableObjectSpawnable](@scriptableObjectSpawnable VARCHAR(100))
RETURNS TINYINT
AS
BEGIN
    DECLARE @levelId TINYINT
	
	SELECT @levelId = sol.levelId
	FROM [content].[scriptableObjectSpawnables] sos
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	WHERE sos.scriptableObjectSpawnable = @scriptableObjectSpawnable

    RETURN @levelId
END

GO

