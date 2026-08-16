CREATE FUNCTION [dbo].[getItemExperiencePlayerMultiplierImbued](@globalObject VARCHAR(100))
RETURNS DECIMAL(5,2)
AS
BEGIN
	DECLARE @experiencePlayerMultiplierImbued DECIMAL(5,2)
	DECLARE @isItemImbued BIT
	
	SELECT @isItemImbued = isImbued, @experiencePlayerMultiplierImbued = it.experiencePlayerMultiplierImbued
	FROM [content].[scriptableItems] si
	JOIN [content].[itemTypes] it ON si.itemTypeId = it.typeId
	WHERE globalObject = @globalObject

	IF (@isItemImbued = 0) SET @experiencePlayerMultiplierImbued = 1

    RETURN @experiencePlayerMultiplierImbued
END

GO

