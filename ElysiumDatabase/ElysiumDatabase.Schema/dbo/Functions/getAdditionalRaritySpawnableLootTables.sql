CREATE FUNCTION [dbo].[getAdditionalRaritySpawnableLootTables](@globalObject VARCHAR(100), @scriptableObjectSpawnable varchar(100))
RETURNS SMALLINT
AS
BEGIN

	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @addtionalRarity SMALLINT
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
		SET @addtionalRarity = dbo.getAdditionalRarityTotalEntity(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE IF (@worldObjectClassificationTypeName = 'Container') 
		SET @addtionalRarity = dbo.getAdditionalRarityTotalContainer(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE IF (@worldObjectClassificationTypeName = 'Gatherable Node') 
		SET @addtionalRarity = dbo.getAdditionalRarityTotalGatherable(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE
		SET @addtionalRarity = 0

    RETURN @addtionalRarity
END

GO

