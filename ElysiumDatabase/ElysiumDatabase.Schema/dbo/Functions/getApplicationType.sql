
CREATE FUNCTION [dbo].[getApplicationType](@applicationTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = type
	FROM [content].[applicationTypes]
	WHERE typeId = @applicationTypeId

    RETURN @type
END

GO

