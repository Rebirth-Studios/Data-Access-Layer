CREATE FUNCTION [dbo].[getAdditionalQuantityTotalContainer](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS SMALLINT
AS
BEGIN
	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @addtionalQuantity SMALLINT

	SELECT @addtionalQuantity  = edt.additionalQuantity
	FROM [content].[scriptableContainersSpawnable] ses
	JOIN [content].[scriptableContainersVariations] sev ON ses.variationId = sev.variationId AND ses.containerTypeId = sev.containerTypeId
	JOIN [content].[containerQuantityTypes] edt ON sev.containerQuantityTypeId = edt.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel

    RETURN @addtionalQuantity
END

GO

