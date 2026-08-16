CREATE FUNCTION [dbo].[getOffsetRelativeLevelIdTotalContainer](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS TINYINT
AS
BEGIN
    DECLARE @offsetRelativeLevelIdRarity TINYINT
	DECLARE @offsetRelativeLevelIdImbued TINYINT
	DECLARE @offsetRelativeLevelIdQuantity TINYINT
	DECLARE @offsetRelativeLevelId TINYINT

	SELECT @offsetRelativeLevelIdRarity = edt.offsetRelativeLevelId, @offsetRelativeLevelIdImbued = eit.offsetRelativeLevelId,
	@offsetRelativeLevelIdQuantity = cqt.offsetRelativeLevelId
	FROM [content].[scriptableContainersSpawnable] ses
	JOIN [content].[scriptableContainersVariations] sev ON ses.variationId = sev.variationId AND ses.containerTypeId = sev.containerTypeId
	JOIN [content].[containerRarityTypes] edt ON sev.containerRarityTypeId = edt.typeId
	JOIN [content].[containerImbuedTypes] eit ON sev.containerImbuedTypeId = eit.typeId
	JOIN [content].[containerQuantityTypes] cqt ON sev.containerQuantityTypeId = cqt.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel


	SET @offsetRelativeLevelId = @offsetRelativeLevelIdRarity + @offsetRelativeLevelIdImbued + @offsetRelativeLevelIdQuantity
    RETURN @offsetRelativeLevelId
END

GO

