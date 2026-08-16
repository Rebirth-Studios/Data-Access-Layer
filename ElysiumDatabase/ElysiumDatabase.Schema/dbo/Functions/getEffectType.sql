CREATE FUNCTION [dbo].[getEffectType](@effectTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = type
	FROM [content].[effectTypes]
	WHERE typeId = @effectTypeId

    RETURN @type
END

GO

