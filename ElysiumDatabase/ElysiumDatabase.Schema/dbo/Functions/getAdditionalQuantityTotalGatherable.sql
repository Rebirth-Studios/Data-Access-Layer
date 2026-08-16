CREATE FUNCTION [dbo].[getAdditionalQuantityTotalGatherable](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS  SMALLINT
AS
BEGIN
	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @addtionalQuantity SMALLINT

	SELECT @addtionalQuantity  = edt.additionalQuantity
	FROM [content].[scriptableGatherablesSpawnable] ses
	JOIN [content].[scriptableGatherablesVariations] sev ON ses.variationId = sev.variationId AND ses.gatherableTypeId = sev.gatherableTypeId
	JOIN [content].[gatherableQuantityTypes] edt ON sev.gatherableQuantityTypeId = edt.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel
    RETURN @addtionalQuantity
END

GO

