
CREATE FUNCTION [dbo].[getDamageTypeName](@damageTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @typeName VARCHAR(255)

	SELECT @typeName = typeName
	FROM [content].[damageTypes]
	WHERE typeId = @damageTypeId

    RETURN @typeName
END

GO

