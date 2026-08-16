CREATE FUNCTION [dbo].[getTitleName](@globalObject VARCHAR(100))
RETURNS VARCHAR(255)
AS
BEGIN
	
	DECLARE @titleName VARCHAR(255)
	DECLARE @globalObjectName VARCHAR(255)

	SELECT @globalObjectName  = globalObjectName
	FROM [content].[globalObjects]
	WHERE globalObject = @globalObject

	SET @titleName = SUBSTRING(@globalObjectName,9,255)

    RETURN @titleName
END

GO

