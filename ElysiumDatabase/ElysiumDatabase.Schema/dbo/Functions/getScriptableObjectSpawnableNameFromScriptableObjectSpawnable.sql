CREATE FUNCTION [dbo].[getScriptableObjectSpawnableNameFromScriptableObjectSpawnable](@scriptableObjectSpawnable VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @ScriptableObjectSpawnableName VARCHAR(255)
	
	SELECT @ScriptableObjectSpawnableName = scriptableObjectSpawnableName
	FROM [content].[scriptableObjectSpawnables]
	WHERE scriptableObjectSpawnable = @scriptableObjectSpawnable

    RETURN @ScriptableObjectSpawnableName
END

GO

