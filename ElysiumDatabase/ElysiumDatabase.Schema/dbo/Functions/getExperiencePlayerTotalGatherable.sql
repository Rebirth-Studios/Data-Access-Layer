CREATE FUNCTION [dbo].[getExperiencePlayerTotalGatherable](@globalObject varchar(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS DECIMAL (5,2)
AS
BEGIN
    declare @experienceTotalPlayer DECIMAL (5,2)
	declare @experienceBasePlayer DECIMAL (5,2)
	declare @experienceMultiplierPlayerType DECIMAL (5,2)
	declare @experienceMultiplierPlayerVariation DECIMAL (5,2)
	
	SET @experienceBasePlayer = dbo.getExperiencePlayerBaseGatherable(@globalObject);
	SET @experienceMultiplierPlayerType = dbo.getExperiencePlayerMultiplierGatherable(@globalObject);
	SET @experienceMultiplierPlayerVariation = dbo.getExperiencePlayerMultiplierVariationGatherable(@globalObject, @variationId, @scriptableObjectLevel);

	SET @experienceTotalPlayer = @experienceBasePlayer * @experienceMultiplierPlayerType * @experienceMultiplierPlayerVariation
    
    RETURN @experienceTotalPlayer
END

GO

