CREATE FUNCTION [dbo].[getScriptableObjectTypeFromGlobalObject](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @scriptableObjectType VARCHAR(255)

	SELECT @scriptableObjectType = sot.type
	FROM [content].[scriptableObjects] so
	JOIN [content].[scriptableObjectTypes] sot ON so.scriptableObjectTypeId = sot.typeId
	WHERE globalObject = @globalObject

    RETURN @scriptableObjectType
END

GO

