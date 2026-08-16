CREATE FUNCTION [dbo].[getAdditionalRarityTotalGatherable](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS SMALLINT
AS
BEGIN
	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @addtionalRarityLocation SMALLINT
	DECLARE @additionalRarityImbued SMALLINT
	DECLARE @addtionalRarity SMALLINT

	SELECT @addtionalRarityLocation = edt.additionalRarity, @additionalRarityImbued = eit.additionalRarity
	FROM [content].[scriptableGatherablesSpawnable] ses
	JOIN [content].[scriptableGatherablesVariations] sev ON ses.variationId = sev.variationId AND ses.gatherableTypeId = sev.gatherableTypeId
	JOIN [content].[gatherableLocationTypes] edt ON sev.gatherableLocationTypeId = edt.typeId
	JOIN [content].[gatherableImbuedTypes] eit ON sev.gatherableImbuedTypeId = eit.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel

	SET @addtionalRarity = @addtionalRarityLocation + @additionalRarityImbued

    RETURN @addtionalRarity
END

GO

