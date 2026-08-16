CREATE FUNCTION [dbo].[getSkillRequiredSpawnableLootTables](@globalObject VARCHAR(100), @scriptableObjectSpawnable varchar(100))
RETURNS SMALLINT
AS
BEGIN

	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @skillRequired SMALLINT
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
		SET @skillRequired = 0
	ELSE IF (@worldObjectClassificationTypeName = 'Container') 
		SET @skillRequired = dbo.getSkillRequiredTotalContainer(@globalObject, @scriptableObjectSpawnable)
	ELSE IF (@worldObjectClassificationTypeName = 'Gatherable Node') 
		SET @skillRequired = dbo.getSkillRequiredTotalGatherable(@globalObject, @scriptableObjectSpawnable)
	ELSE
		SET @skillRequired = 0

    RETURN @skillRequired
END

GO

