CREATE FUNCTION [dbo].[getStatMultiplierMonster](@globalObject varchar(100), @statId tinyint, @statTypeId tinyint)
RETURNS Decimal(18,2)
AS
BEGIN
    DECLARE @multiplier VARCHAR(255)
	DECLARE @experienceMultiplierSub DECIMAL(18,2)
	DECLARE @experienceMultiplierClassification DECIMAL(18,2)
	DECLARE @experienceMultiplierMain DECIMAL(18,2)
	
	SELECT @experienceMultiplierMain = mt.multiplier, @experienceMultiplierClassification = ct.multiplier, @experienceMultiplierSub = st.multiplier
	FROM [content].[scriptableMonsters] seh
	JOIN [content].[statsMultiplierMainTypeMonster] mt ON seh.monsterMainTypeId = mt.mainTypeId
	JOIN [content].[statsMultiplierClassificationTypeMonster] ct ON seh.monsterClassificationTypeId = ct.classificationTypeId
	JOIN [content].[statsMultiplierSubTypeMonster] st ON seh.monsterSubTypeId = st.subTypeId
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

