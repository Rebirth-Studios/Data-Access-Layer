CREATE FUNCTION [dbo].[getExperienceSkillTotalSpawnableLootTables](@globalObject VARCHAR(255), @scriptableObjectSpawnable varchar(255))
RETURNS DECIMAL(18,2)
AS
BEGIN

	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @experienceTotalSkill DECIMAL(18,2)
	DECLARE @worldObjectClassificationTypeName VARCHAR(100)
	DECLARE @worldObjectTypeName VARCHAR(100)
	DECLARE @variationId TINYINT
	DECLARE @scriptableObjectLevel VARCHAR(100)


	SET @worldObjectTypeName = dbo.getWorldObjectTypeNameFromGlobalObject(@globalObject);
	SET @worldObjectClassificationTypeName = dbo.getWorldObjectClassificationTypeName(@globalObject);
	
	SELECT @variationId = variationId, @scriptableObjectLevel = scriptableObjectLevel
	FROM [content].[scriptableObjectSpawnables] sos
	WHERE scriptableObjectSpawnable = @scriptableObjectSpawnable

	IF (@worldObjectTypeName = 'Entity') 
		SET @experienceTotalSkill = 0
	ELSE IF (@worldObjectClassificationTypeName = 'Container') 
		SET @experienceTotalSkill = dbo.getExperienceSkillTotalContainer(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE IF (@worldObjectClassificationTypeName = 'Gatherable Node') 
		SET @experienceTotalSkill = dbo.getExperienceSkillTotalGatherable(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE
		SET @experienceTotalSkill = 0

    RETURN @experienceTotalSkill
END

GO

