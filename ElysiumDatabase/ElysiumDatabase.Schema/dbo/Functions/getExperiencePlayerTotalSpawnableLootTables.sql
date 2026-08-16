CREATE FUNCTION [dbo].[getExperiencePlayerTotalSpawnableLootTables](@globalObject VARCHAR(100), @scriptableObjectSpawnable varchar(100))
RETURNS DECIMAL(18,2)
AS
BEGIN

	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @experienceTotalPlayer DECIMAL(18,2)
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
		SET @experienceTotalPlayer = dbo.getStatExperience(@scriptableObjectSpawnable)
	ELSE IF (@worldObjectClassificationTypeName = 'Container') 
		SET @experienceTotalPlayer = dbo.getExperiencePlayerTotalContainer(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE IF (@worldObjectClassificationTypeName = 'Gatherable Node') 
		SET @experienceTotalPlayer = dbo.getExperiencePlayerTotalGatherable(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE
		SET @experienceTotalPlayer = 0

    RETURN @experienceTotalPlayer
END

GO

