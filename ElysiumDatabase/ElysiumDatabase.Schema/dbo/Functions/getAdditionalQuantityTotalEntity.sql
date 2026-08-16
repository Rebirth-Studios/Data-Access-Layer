CREATE FUNCTION [dbo].[getAdditionalQuantityTotalEntity](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS  TINYINT
AS
BEGIN
	declare @addtionalQuantity TINYINT
	SELECT @addtionalQuantity  = edt.additionalQuantity
	FROM [content].[scriptableEntitiesSpawnable] ses
	JOIN [content].[scriptableEntitiesVariations] sev ON ses.variationId = sev.variationId AND ses.entityTypeId = sev.entityTypeId
	JOIN [content].[entityDifficultyTypes] edt ON sev.entityDifficultyTypeId = edt.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel
    RETURN @addtionalQuantity
END

GO

