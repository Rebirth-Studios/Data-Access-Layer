CREATE FUNCTION [dbo].[getMinRarityIdMaterial](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @minRarityId TINYINT
	DECLARE @minRarity VARCHAR(255)
	DECLARE @materialTypeId TINYINT
	DECLARE @materialClassificationTypeId TINYINT
	DECLARE @materialSubTypeId TINYINT

	SET @minRarityId = 0;

	SELECT @materialTypeId = materialMainTypeId, @materialClassificationTypeId = materialClassificationTypeId, @materialSubTypeId = materialSubTypeId
	FROM [content].[scriptableMaterials] 
	WHERE globalObject = @globalObject

	IF @materialSubTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[materialSubTypes]
			WHERE typeId = @materialSubTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[materialSubTypes]
			WHERE typeId = @materialSubTypeId

	IF @materialClassificationTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[materialClassificationTypes]
			WHERE typeId = @materialClassificationTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[materialClassificationTypes]
			WHERE typeId = @materialClassificationTypeId

	IF @materialTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[materialTypes]
			WHERE typeId = @materialTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[materialTypes]
			WHERE typeId = @materialTypeId

	SELECT @minRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @minRarity

    RETURN @minRarityId
END

GO

