
CREATE FUNCTION [dbo].[getStat](@typeId TINYINT, @statId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = stat
	FROM [content].[stats]
	WHERE statId = @statId AND statTypeId = @typeId

    RETURN @type
END

GO

