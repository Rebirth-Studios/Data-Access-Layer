
CREATE FUNCTION [dbo].[getDataAttributeType](@dataAttributeTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @typeName VARCHAR(255)

	SELECT @typeName = typeName
	FROM [content].[dataAttributeTypes]
	WHERE typeId = @dataAttributeTypeId

    RETURN @typeName
END

GO

