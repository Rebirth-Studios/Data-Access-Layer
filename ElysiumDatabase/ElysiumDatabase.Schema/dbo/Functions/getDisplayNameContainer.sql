CREATE FUNCTION [dbo].[getDisplayNameContainer](@variationId tinyint, @globalObject VARCHAR(100))
RETURNS varchar(100)
AS
BEGIN
    DECLARE @displayName varchar(100)
	DECLARE @imbuedTypeId tinyint
	DECLARE @globalObjectName varchar(100)

	SELECT @globalObjectName = glo.globalObjectName, @imbuedTypeId = sev.containerImbuedTypeId
	FROM [content].[scriptableContainersSpawnable] ses
	JOIN [content].[scriptableContainersVariations] sev ON ses.containerTypeId = sev.containerTypeId AND ses.variationId = sev.variationId
	JOIN [content].[globalObjects] glo ON ses.globalObject = glo.globalObject
	WHERE ses.variationId = @variationId AND ses.globalObject = @globalObject

	IF (@imbuedTypeId < 2) SET @displayName = @globalObjectName
	ELSE SET @displayName = 'Imbued ' + @globalObjectName

    RETURN @displayName
END

GO

