CREATE FUNCTION [dbo].[getAdditionalRarityTotalContainer](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS SMALLINT
AS
BEGIN
	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @addtionalRarityRarity SMALLINT
	DECLARE @additionalRarityImbued SMALLINT
	DECLARE @addtionalRarity SMALLINT

	SELECT @addtionalRarityRarity = edt.additionalRarity, @additionalRarityImbued = eit.additionalRarity
	FROM [content].[scriptableContainersSpawnable] ses
	JOIN [content].[scriptableContainersVariations] sev ON ses.variationId = sev.variationId AND ses.containerTypeId = sev.containerTypeId
	JOIN [content].[containerRarityTypes] edt ON sev.containerRarityTypeId = edt.typeId
	JOIN [content].[containerImbuedTypes] eit ON sev.containerImbuedTypeId = eit.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel

	SET @addtionalRarity = @addtionalRarityRarity + @additionalRarityImbued

    RETURN @addtionalRarity
END

GO

