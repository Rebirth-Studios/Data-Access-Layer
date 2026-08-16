CREATE FUNCTION [dbo].[getStatMultiplierEnemyHumanoid](@globalObject varchar(100), @statId tinyint, @statTypeId tinyint)
RETURNS Decimal(18,2)
AS
BEGIN
    DECLARE @multiplier VARCHAR(255)
	DECLARE @experienceMultiplierSub DECIMAL(18,2)
	DECLARE @experienceMultiplierClassification DECIMAL(18,2)
	DECLARE @experienceMultiplierMain DECIMAL(18,2)
	
	SELECT @experienceMultiplierMain = mt.multiplier, @experienceMultiplierClassification = ct.multiplier, @experienceMultiplierSub = st.multiplier
	FROM [content].[scriptableEnemyHumanoids] seh
	JOIN [content].[statsMultiplierMainTypeEnemyHumanoid] mt ON seh.enemyHumanoidMainTypeId = mt.mainTypeId
	JOIN [content].[statsMultiplierClassificationTypeEnemyHumanoid] ct ON seh.enemyHumanoidClassificationTypeId = ct.classificationTypeId
	JOIN [content].[statsMultiplierSubTypeEnemyHumanoid] st ON seh.enemyHumanoidSubTypeId = st.subTypeId
	WHERE seh.globalObject = @globalObject 
	AND mt.statId = @statId AND mt.statTypeId = @statTypeId 
	AND ct.statId = @statId AND ct.statTypeId = @statTypeId
	AND st.statId = @statId AND st.statTypeId = @statTypeId

	IF (@experienceMultiplierSub > 0) SET @multiplier = @experienceMultiplierSub
	ELSE IF (@experienceMultiplierClassification > 0) SET @multiplier = @experienceMultiplierClassification
	ELSE SET @multiplier = @experienceMultiplierMain

    RETURN @multiplier
END

GO

