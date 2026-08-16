CREATE FUNCTION [dbo].[getAdditionalRarityTotalEntity](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS  TINYINT
AS
BEGIN
	declare @addtionalRarityTotal TINYINT
	declare @addtionalRarityDifficulty TINYINT
	declare @addtionalRarityImbued TINYINT

	SELECT @addtionalRarityDifficulty = edt.additionalRarity, @addtionalRarityImbued = eit.additionalRarity
	FROM [content].[scriptableEntitiesSpawnable] ses
	JOIN [content].[scriptableEntitiesVariations] sev ON ses.variationId = sev.variationId AND ses.entityTypeId = sev.entityTypeId
	JOIN [content].[entityDifficultyTypes] edt ON sev.entityDifficultyTypeId = edt.typeId
	JOIN [content].[entityImbuedTypes] eit ON sev.entityImbuedTypeId = eit.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel

	SET @addtionalRarityTotal = @addtionalRarityDifficulty + @addtionalRarityImbued
    RETURN @addtionalRarityTotal
END

GO

