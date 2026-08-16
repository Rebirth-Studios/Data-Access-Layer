CREATE FUNCTION [dbo].[getModifierTypeName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[modifierTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

