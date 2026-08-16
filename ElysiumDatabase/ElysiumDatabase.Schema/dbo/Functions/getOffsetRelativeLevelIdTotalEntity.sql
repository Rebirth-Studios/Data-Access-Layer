CREATE FUNCTION [dbo].[getOffsetRelativeLevelIdTotalEntity](@globalObject VARCHAR(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS TINYINT
AS
BEGIN
    DECLARE @offsetRelativeLevelIdDifficulty TINYINT
	DECLARE @offsetRelativeLevelIdImbued TINYINT
	DECLARE @offsetRelativeLevelId TINYINT

	SELECT @offsetRelativeLevelIdDifficulty = edt.offsetRelativeLevelId, @offsetRelativeLevelIdImbued = eit.offsetRelativeLevelId
	FROM [content].[scriptableEntitiesSpawnable] ses
	JOIN [content].[scriptableEntitiesVariations] sev ON ses.variationId = sev.variationId AND ses.entityTypeId = sev.entityTypeId
	JOIN [content].[entityDifficultyTypes] edt ON sev.entityDifficultyTypeId = edt.typeId
	JOIN [content].[entityImbuedTypes] eit ON sev.entityImbuedTypeId = eit.typeId
	WHERE ses.globalObject = @globalObject AND ses.variationId = @variationId AND ses.scriptableObjectLevel = @scriptableObjectLevel

	SET @offsetRelativeLevelId = @offsetRelativeLevelIdDifficulty + @offsetRelativeLevelIdImbued
    RETURN @offsetRelativeLevelId
END

GO

