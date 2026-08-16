CREATE FUNCTION [dbo].[getSkillRequiredTotalGatherable](@globalObject VARCHAR(100), @scriptableObjectSpawnable varchar(100))
RETURNS  TINYINT
AS
BEGIN
	DECLARE @addtionalSkillTotal TINYINT
	DECLARE @addtionalSkillLocation TINYINT
	DECLARE @additionalSkillImbued TINYINT
	DECLARE @addtionalSkillQuantity TINYINT
	DECLARE @skillRequiredBase TINYINT

	SET @skillRequiredBase = dbo.getSkillRequiredBase(@globalObject)

	SELECT @addtionalSkillLocation = crt.additionalSkillRequired, @additionalSkillImbued = cit.additionalSkillRequired, @addtionalSkillQuantity = cqt.additionalSkillRequired
	FROM [content].[scriptableGatherablesSpawnable] ses
	JOIN [content].[scriptableGatherablesVariations] sev ON ses.variationId = sev.variationId AND ses.gatherableTypeId = sev.gatherableTypeId
	JOIN [content].[gatherableLocationTypes] crt ON sev.gatherableLocationTypeId = crt.typeId
	JOIN [content].[gatherableImbuedTypes] cit ON sev.gatherableImbuedTypeId = cit.typeId
	JOIN [content].[gatherableQuantityTypes] cqt ON sev.gatherableQuantityTypeId = cqt.typeId
	WHERE ses.globalObject = @globalObject AND ses.scriptableObjectSpawnable = @scriptableObjectSpawnable


	SET @addtionalSkillTotal = @addtionalSkillLocation + @additionalSkillImbued + @addtionalSkillQuantity + @skillRequiredBase

    RETURN @addtionalSkillTotal
END

GO

