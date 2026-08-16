CREATE FUNCTION [dbo].[getGlobalObjectNameUsingScriptableObjectLevel](@scriptableObjectLevel VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @globalObjectName VARCHAR(255)
	
	SELECT @globalObjectName = glo.globalObjectName
	FROM [content].[globalObjects] glo
	JOIN [content].[scriptableObjectLevels] sol ON glo.globalObject = sol.globalObject
	WHERE scriptableObjectLevel = @scriptableObjectLevel

    RETURN @globalObjectName
END

GO

