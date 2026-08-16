CREATE FUNCTION [dbo].[getNpcClassificationTypeName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[npcClassificationTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

