

CREATE FUNCTION [dbo].[getGlobalTierIdUsingGlobalObject](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = gos.globalTierId
	FROM [content].[globalObjects] gos
	WHERE gos.globalObject = @globalObject
    RETURN @type
END

GO

