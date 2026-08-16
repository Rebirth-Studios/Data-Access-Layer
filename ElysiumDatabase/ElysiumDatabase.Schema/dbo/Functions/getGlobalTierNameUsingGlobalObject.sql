

CREATE FUNCTION [dbo].[getGlobalTierNameUsingGlobalObject](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = gt.typeName
	FROM [content].[globalObjects] gos
	JOIN [content].[globalTiers] gt ON gos.globalTierId = gt.typeId
	WHERE gos.globalObject = @globalObject
    RETURN @type
END

GO

