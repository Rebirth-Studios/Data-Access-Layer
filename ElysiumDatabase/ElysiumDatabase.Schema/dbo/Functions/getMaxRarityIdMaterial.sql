CREATE FUNCTION [dbo].[getMaxRarityIdMaterial](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @maxRarityId TINYINT
	DECLARE @maxRarity VARCHAR(255)
	DECLARE @materialTypeId TINYINT
	DECLARE @materialClassificationTypeId TINYINT
	DECLARE @materialSubTypeId TINYINT

	SET @maxRarityId = 0;

	SELECT @materialTypeId = materialMainTypeId, @materialClassificationTypeId = materialClassificationTypeId, @materialSubTypeId = materialSubTypeId
	FROM [content].[scriptableMaterials] 
	WHERE globalObject = @globalObject

	IF @materialSubTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[materialSubTypes]
			WHERE typeId = @materialSubTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[materialSubTypes]
			WHERE typeId = @materialSubTypeId

	IF @materialClassificationTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[materialClassificationTypes]
			WHERE typeId = @materialClassificationTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[materialClassificationTypes]
			WHERE typeId = @materialClassificationTypeId

	IF @materialTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[materialTypes]
			WHERE typeId = @materialTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[materialTypes]
			WHERE typeId = @materialTypeId

	SELECT @maxRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @maxRarity

    RETURN @maxRarityId
END

GO

