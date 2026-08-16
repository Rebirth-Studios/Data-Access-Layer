CREATE FUNCTION [dbo].[getScriptableObjectTypeNameFromGlobalObject](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @scriptableObjectType VARCHAR(255)

	SELECT @scriptableObjectType = sot.typeName
	FROM [content].[scriptableObjects] so
	JOIN [content].[scriptableObjectTypes] sot ON so.scriptableObjectTypeId = sot.typeId
	WHERE globalObject = @globalObject

    RETURN @scriptableObjectType
END

GO

