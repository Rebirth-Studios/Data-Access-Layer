CREATE FUNCTION [dbo].[getAdditionalQuantitySpawnableLootTables](@globalObject VARCHAR(100), @scriptableObjectSpawnable varchar(100))
RETURNS SMALLINT
AS
BEGIN

	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @addtionalQuantity SMALLINT
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
		SET @addtionalQuantity = dbo.getAdditionalQuantityTotalEntity(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE IF (@worldObjectClassificationTypeName = 'Container') 
		SET @addtionalQuantity = dbo.getAdditionalQuantityTotalContainer(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE IF (@worldObjectClassificationTypeName = 'Gatherable Node') 
		SET @addtionalQuantity = dbo.getAdditionalQuantityTotalGatherable(@globalObject, @variationId, @scriptableObjectLevel)
	ELSE
		SET @addtionalQuantity = 0

    RETURN @addtionalQuantity
END

GO

