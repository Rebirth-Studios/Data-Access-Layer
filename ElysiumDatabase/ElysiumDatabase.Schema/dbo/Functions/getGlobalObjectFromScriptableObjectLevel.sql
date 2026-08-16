CREATE FUNCTION [dbo].[getGlobalObjectFromScriptableObjectLevel](@scriptableObjectLevel VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @GlobalObject VARCHAR(255)
	
	SELECT @GlobalObject = globalObject
	FROM [content].[scriptableObjectLevels]
	WHERE scriptableObjectLevel = @scriptableObjectLevel

    RETURN @GlobalObject
END

GO

