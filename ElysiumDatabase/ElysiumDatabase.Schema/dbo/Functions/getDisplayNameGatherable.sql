
CREATE FUNCTION [dbo].[getDisplayNameGatherable](@variationId tinyint, @globalObject VARCHAR(100))
RETURNS varchar(100)
AS
BEGIN
    DECLARE @displayName varchar(100)
	DECLARE @imbuedTypeId tinyint
	DECLARE @globalObjectName varchar(100)

	SELECT @globalObjectName = glo.globalObjectName, @imbuedTypeId = sev.gatherableImbuedTypeId
	FROM [content].[scriptableGatherablesSpawnable] ses
	JOIN [content].[scriptableGatherablesVariations] sev ON ses.gatherableTypeId = sev.gatherableTypeId AND ses.variationId = sev.variationId
	JOIN [content].[globalObjects] glo ON ses.globalObject = glo.globalObject
	WHERE ses.variationId = @variationId AND ses.globalObject = @globalObject

	IF (@imbuedTypeId < 2) SET @displayName = @globalObjectName
	ELSE SET @displayName = 'Imbued ' + @globalObjectName

    RETURN @displayName
END

GO

