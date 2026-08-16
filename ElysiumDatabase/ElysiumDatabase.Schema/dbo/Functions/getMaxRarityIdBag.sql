CREATE FUNCTION [dbo].[getMaxRarityIdBag](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @maxRarityId TINYINT
	DECLARE @maxRarity VARCHAR(255)
	DECLARE @bagTypeId TINYINT
	DECLARE @bagClassificationTypeId TINYINT
	DECLARE @bagSubTypeId TINYINT

	SET @maxRarityId = 0;

	SELECT @bagTypeId = bagMainTypeId, @bagClassificationTypeId = bagClassificationTypeId, @bagSubTypeId = bagSubTypeId
	FROM [content].[scriptableBags]
	WHERE globalObject = @globalObject

	IF @bagSubTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[bagSubTypes]
			WHERE typeId = @bagSubTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[bagSubTypes]
			WHERE typeId = @bagSubTypeId

	IF @bagClassificationTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[bagClassificationTypes]
			WHERE typeId = @bagClassificationTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[bagClassificationTypes]
			WHERE typeId = @bagClassificationTypeId

	IF @bagTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[bagTypes]
			WHERE typeId = @bagTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[bagTypes]
			WHERE typeId = @bagTypeId

	SELECT @maxRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @maxRarity

    RETURN @maxRarityId
END

GO

