
CREATE FUNCTION [dbo].[getDamageType](@damageTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = type
	FROM [content].[damageTypes]
	WHERE typeId = @damageTypeId

    RETURN @type
END

GO

