CREATE FUNCTION [dbo].[getMaxRarityIdConsumable](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @maxRarityId TINYINT
	DECLARE @maxRarity VARCHAR(255)
	DECLARE @consumableTypeId TINYINT
	DECLARE @consumableClassificationTypeId TINYINT
	DECLARE @consumableSubTypeId TINYINT

	SET @maxRarityId = 0;

	SELECT @consumableTypeId = consumableMainTypeId, @consumableClassificationTypeId = consumableClassificationTypeId, @consumableSubTypeId = consumableSubTypeId
	FROM [content].[scriptableConsumables] 
	WHERE globalObject = @globalObject

	IF @consumableSubTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[consumableSubTypes]
			WHERE typeId = @consumableSubTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[consumableSubTypes]
			WHERE typeId = @consumableSubTypeId

	IF @consumableClassificationTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[consumableClassificationTypes]
			WHERE typeId = @consumableClassificationTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[consumableClassificationTypes]
			WHERE typeId = @consumableClassificationTypeId

	IF @consumableTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[consumableTypes]
			WHERE typeId = @consumableTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[consumableTypes]
			WHERE typeId = @consumableTypeId

	SELECT @maxRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @maxRarity

    RETURN @maxRarityId
END

GO

