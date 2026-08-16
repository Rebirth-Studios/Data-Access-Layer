CREATE FUNCTION [dbo].[getGlobalObjectName](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @globalObjectName VARCHAR(255)
	
	SELECT @globalObjectName = globalObjectName
	FROM [content].[globalObjects]
	WHERE globalObject = @globalObject

    RETURN @globalObjectName
END

GO

