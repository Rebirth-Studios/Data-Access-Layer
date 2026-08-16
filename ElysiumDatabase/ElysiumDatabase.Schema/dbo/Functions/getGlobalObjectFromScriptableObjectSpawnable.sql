CREATE FUNCTION [dbo].[getGlobalObjectFromScriptableObjectSpawnable](@scriptableObjectSpawnable VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @GlobalObject VARCHAR(255)
	
	SELECT @GlobalObject = globalObject
	FROM [content].[scriptableObjectSpawnables]
	WHERE scriptableObjectSpawnable = @scriptableObjectSpawnable

    RETURN @GlobalObject
END

GO

