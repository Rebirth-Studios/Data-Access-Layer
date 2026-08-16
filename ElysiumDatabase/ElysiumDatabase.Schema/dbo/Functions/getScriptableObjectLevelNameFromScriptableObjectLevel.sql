CREATE FUNCTION [dbo].[getScriptableObjectLevelNameFromScriptableObjectLevel](@scriptableObjectLevel VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @ScriptableObjectLevelName VARCHAR(255)
	
	SELECT @ScriptableObjectLevelName = scriptableObjectLevelName
	FROM [content].[scriptableObjectLevels]
	WHERE scriptableObjectLevel = @scriptableObjectLevel

    RETURN @ScriptableObjectLevelName
END

GO

