CREATE FUNCTION [dbo].[getSkillRequiredTotalContainer](@globalObject VARCHAR(100), @scriptableObjectSpawnable varchar(100))
RETURNS  TINYINT
AS
BEGIN
	DECLARE @addtionalSkillTotal TINYINT
	DECLARE @addtionalSkillRarity TINYINT
	DECLARE @additionalSkillImbued TINYINT
	DECLARE @addtionalSkillQuantity TINYINT
	DECLARE @skillRequiredBase TINYINT

	SET @skillRequiredBase = dbo.getSkillRequiredBase(@globalObject)
	SELECT @addtionalSkillRarity = crt.additionalSkillRequired, @additionalSkillImbued = cit.additionalSkillRequired, @addtionalSkillQuantity = cqt.additionalSkillRequired
	FROM [content].[scriptableContainersSpawnable] ses
	JOIN [content].[scriptableContainersVariations] sev ON ses.variationId = sev.variationId AND ses.containerTypeId = sev.containerTypeId
	JOIN [content].[containerRarityTypes] crt ON sev.containerRarityTypeId = crt.typeId
	JOIN [content].[containerImbuedTypes] cit ON sev.containerImbuedTypeId = cit.typeId
	JOIN [content].[containerQuantityTypes] cqt ON sev.containerQuantityTypeId = cqt.typeId
	WHERE ses.globalObject = @globalObject AND ses.scriptableObjectSpawnable = @scriptableObjectSpawnable


	SET @addtionalSkillTotal = @addtionalSkillRarity + @additionalSkillImbued + @addtionalSkillQuantity + @skillRequiredBase

    RETURN @addtionalSkillTotal
END

GO

