
CREATE FUNCTION [dbo].[getGlobalObjectSubTypeName](@typeId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[globalObjectSubTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

