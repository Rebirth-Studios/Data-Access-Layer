CREATE FUNCTION [dbo].[getLevelIdFromScriptableObjectLevel](@scriptableObjectLevel VARCHAR(255))
RETURNS TINYINT
AS
BEGIN
    DECLARE @levelId TINYINT
	
	SELECT @levelId = levelId
	FROM [content].[scriptableObjectLevels]
	WHERE scriptableObjectLevel = @scriptableObjectLevel

    RETURN @levelId
END

GO

