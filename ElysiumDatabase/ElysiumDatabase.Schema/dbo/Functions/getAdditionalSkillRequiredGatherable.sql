CREATE FUNCTION [dbo].[getAdditionalSkillRequiredGatherable](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS  SMALLINT
AS
BEGIN
	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @additionalSkillTotal SMALLINT
	DECLARE @addtionalSkillLocation SMALLINT
	DECLARE @additionalSkillImbued SMALLINT
	DECLARE @addtionalSkillQuantity SMALLINT

	SELECT @addtionalSkillLocation  = glt.additionalSkillRequired, @additionalSkillImbued  = git.additionalSkillRequired, @addtionalSkillQuantity  = gqt.additionalSkillRequired
	FROM [content].[scriptableGatherablesSpawnable] ses
	JOIN [content].[scriptableGatherablesVariations] sev ON ses.variationId = sev.variationId AND ses.gatherableTypeId = sev.gatherableTypeId
	JOIN [content].[gatherableLocationTypes] glt ON sev.gatherableLocationTypeId = glt.locationTypeId
	JOIN [content].[gatherableImbuedTypes] git ON sev.gatherableImbuedTypeId = git.imbuedTypeId
	JOIN [content].[gatherableQuantityTypes] gqt ON sev.gatherableQuantityTypeId = gqt.quantityTypeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel


	SET @additionalSkillTotal = @addtionalSkillLocation + @additionalSkillImbued + @addtionalSkillQuantity

    RETURN @additionalSkillTotal
END

GO

