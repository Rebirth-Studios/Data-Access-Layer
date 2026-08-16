CREATE FUNCTION [dbo].[getOffsetRelativeLevelIdTotalGatherable](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS TINYINT
AS
BEGIN
    DECLARE @offsetRelativeLevelIdLocation TINYINT
	DECLARE @offsetRelativeLevelIdImbued TINYINT
	DECLARE @offsetRelativeLevelIdQuantity TINYINT
	DECLARE @offsetRelativeLevelId TINYINT

	SELECT @offsetRelativeLevelIdLocation = edt.offsetRelativeLevelId, @offsetRelativeLevelIdImbued = eit.offsetRelativeLevelId,
	@offsetRelativeLevelIdQuantity = cqt.offsetRelativeLevelId
	FROM [content].[scriptableGatherablesSpawnable] ses
	JOIN [content].[scriptableGatherablesVariations] sev ON ses.variationId = sev.variationId AND ses.gatherableTypeId = sev.gatherableTypeId
	JOIN [content].[gatherableLocationTypes] edt ON sev.gatherableLocationTypeId = edt.typeId
	JOIN [content].[gatherableImbuedTypes] eit ON sev.gatherableImbuedTypeId = eit.typeId
	JOIN [content].[gatherableQuantityTypes] cqt ON sev.gatherableQuantityTypeId = cqt.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel


	SET @offsetRelativeLevelId = @offsetRelativeLevelIdLocation + @offsetRelativeLevelIdImbued + @offsetRelativeLevelIdQuantity
    RETURN @offsetRelativeLevelId
END

GO

