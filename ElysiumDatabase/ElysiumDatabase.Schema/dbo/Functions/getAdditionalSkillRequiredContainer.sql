CREATE FUNCTION [dbo].[getAdditionalSkillRequiredContainer](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS  SMALLINT
AS
BEGIN
	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @additionalSkillTotal SMALLINT
	DECLARE @addtionalSkillRarity SMALLINT
	DECLARE @additionalSkillImbued SMALLINT
	DECLARE @addtionalSkillQuantity SMALLINT

	SELECT @addtionalSkillRarity  = crt.additionalSkillRequired, @additionalSkillImbued  = cit.additionalSkillRequired, @addtionalSkillQuantity  = cqt.additionalSkillRequired
	FROM [content].[scriptableContainersSpawnable] ses
	JOIN [content].[scriptableContainersVariations] sev ON ses.variationId = sev.variationId AND ses.containerTypeId = sev.containerTypeId
	JOIN [content].[containerRarityTypes] crt ON sev.containerRarityTypeId = crt.rarityTypeId
	JOIN [content].[containerImbuedTypes] cit ON sev.containerImbuedTypeId = cit.imbuedTypeId
	JOIN [content].[containerQuantityTypes] cqt ON sev.containerQuantityTypeId = cqt.quantityTypeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel


	SET @additionalSkillTotal = @addtionalSkillRarity + @additionalSkillImbued + @addtionalSkillQuantity

    RETURN @additionalSkillTotal
END

GO

