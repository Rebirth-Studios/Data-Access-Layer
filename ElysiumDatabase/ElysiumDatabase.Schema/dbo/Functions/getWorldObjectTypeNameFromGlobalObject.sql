CREATE FUNCTION [dbo].[getWorldObjectTypeNameFromGlobalObject](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN

	DECLARE @worldObjectTypeName VARCHAR(100)

	SELECT @worldObjectTypeName = wot.typeName
	FROM [content].[scriptableWorldObjects] swo
	JOIN [content].[worldObjectTypes] wot ON swo.worldObjectTypeId = wot.typeId
	WHERE globalObject = @globalObject

    RETURN @worldObjectTypeName
END

GO

