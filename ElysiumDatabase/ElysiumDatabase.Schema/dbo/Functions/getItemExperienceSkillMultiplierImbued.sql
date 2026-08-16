CREATE FUNCTION [dbo].[getItemExperienceSkillMultiplierImbued](@globalObject VARCHAR(100))
RETURNS DECIMAL(5,2)
AS
BEGIN
	DECLARE @experienceSkillMultiplierImbued DECIMAL(5,2)
	DECLARE @isItemImbued BIT
	
	SELECT @isItemImbued = isImbued, @experienceSkillMultiplierImbued = it.experienceSkillMultiplierImbued
	FROM [content].[scriptableItems] si
	JOIN [content].[itemTypes] it ON si.itemTypeId = it.typeId
	WHERE globalObject = @globalObject

	IF (@isItemImbued = 0) SET @experienceSkillMultiplierImbued = 1

    RETURN @experienceSkillMultiplierImbued
END

GO

