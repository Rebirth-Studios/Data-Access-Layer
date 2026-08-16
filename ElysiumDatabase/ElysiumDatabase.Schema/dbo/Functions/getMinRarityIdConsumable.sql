CREATE FUNCTION [dbo].[getMinRarityIdConsumable](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @minRarityId TINYINT
	DECLARE @minRarity VARCHAR(255)
	DECLARE @consumableTypeId TINYINT
	DECLARE @consumableClassificationTypeId TINYINT
	DECLARE @consumableSubTypeId TINYINT

	SET @minRarityId = 0;

	SELECT @consumableTypeId = consumableMainTypeId, @consumableClassificationTypeId = consumableClassificationTypeId, @consumableSubTypeId = consumableSubTypeId
	FROM [content].[scriptableConsumables] 
	WHERE globalObject = @globalObject

	IF @consumableSubTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[consumableSubTypes]
			WHERE typeId = @consumableSubTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[consumableSubTypes]
			WHERE typeId = @consumableSubTypeId

	IF @consumableClassificationTypeId > 0
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[consumableClassificationTypes]
			WHERE typeId = @consumableClassificationTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[consumableClassificationTypes]
			WHERE typeId = @consumableClassificationTypeId

	IF @consumableTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[consumableTypes]
			WHERE typeId = @consumableTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[consumableTypes]
			WHERE typeId = @consumableTypeId

	SELECT @minRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @minRarity

    RETURN @minRarityId
END

GO

