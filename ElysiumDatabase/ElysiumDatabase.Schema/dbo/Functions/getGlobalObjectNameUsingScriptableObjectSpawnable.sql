CREATE FUNCTION [dbo].[getGlobalObjectNameUsingScriptableObjectSpawnable](@scriptableObjectSpawnable VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @globalObjectName VARCHAR(255)
	
	SELECT @globalObjectName = glo.globalObjectName
	FROM [content].[globalObjects] glo
	JOIN [content].[scriptableObjectSpawnables] sol ON glo.globalObject = sol.globalObject
	WHERE scriptableObjectSpawnable = @scriptableObjectSpawnable

    RETURN @globalObjectName
END

GO

