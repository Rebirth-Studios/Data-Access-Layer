CREATE FUNCTION [dbo].[getQualityName](@typeId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @qualityName VARCHAR(255)
	
	SELECT @qualityName = typeName
	FROM [content].[scriptableQualities]
	WHERE typeId = @typeId

    RETURN @qualityName
END

GO

