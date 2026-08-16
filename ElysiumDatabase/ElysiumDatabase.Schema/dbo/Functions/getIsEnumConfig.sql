
CREATE FUNCTION [dbo].[getIsEnumConfig](@dataType VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	IF @dataType NOT IN ('bool', 'int', 'byte', 'string', 'float', 'decimal', 'short', 'ushort') 
		SET @type = 1
	ELSE
		SET @type = 0

    RETURN @type
END

GO

