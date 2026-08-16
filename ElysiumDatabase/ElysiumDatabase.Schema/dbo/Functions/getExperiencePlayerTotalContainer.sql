CREATE FUNCTION [dbo].[getExperiencePlayerTotalContainer](@globalObject varchar(100), @variationId tinyint, @scriptableObjectLevel varchar(100))
RETURNS DECIMAL (5,2)
AS
BEGIN
    declare @experienceTotalPlayer DECIMAL (5,2)
	declare @experienceBasePlayer DECIMAL (5,2)
	declare @experienceMultiplierPlayerType DECIMAL (5,2)
	declare @experienceMultiplierPlayerVariation DECIMAL (5,2)
	
	SET @experienceBasePlayer = dbo.getExperiencePlayerBaseContainer(@globalObject);
	SET @experienceMultiplierPlayerType = dbo.getExperiencePlayerMultiplierContainer(@globalObject);
	SET @experienceMultiplierPlayerVariation = dbo.getExperiencePlayerMultiplierVariationContainer(@globalObject, @variationId, @scriptableObjectLevel);

	SET @experienceTotalPlayer = @experienceBasePlayer * @experienceMultiplierPlayerType * @experienceMultiplierPlayerVariation
    
    RETURN @experienceTotalPlayer
END

GO

