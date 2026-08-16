
CREATE FUNCTION [dbo].[getElementalTypeName](@elementalTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @typeName VARCHAR(255)

	SELECT @typeName = typeName
	FROM [content].[elementalTypes]
	WHERE typeId = @elementalTypeId

    RETURN @typeName
END

GO

