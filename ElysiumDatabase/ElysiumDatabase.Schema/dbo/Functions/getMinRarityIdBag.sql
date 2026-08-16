CREATE FUNCTION [dbo].[getMinRarityIdBag](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @minRarityId TINYINT
	DECLARE @minRarity VARCHAR(255)
	DECLARE @bagTypeId TINYINT
	DECLARE @bagClassificationTypeId TINYINT
	DECLARE @bagSubTypeId TINYINT

	SET @minRarityId = 0;

	SELECT @bagTypeId = bagMainTypeId, @bagClassificationTypeId = bagClassificationTypeId, @bagSubTypeId = bagSubTypeId
	FROM [content].[scriptableBags] 
	WHERE globalObject = @globalObject

	IF @bagSubTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[bagSubTypes]
			WHERE typeId = @bagSubTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[bagSubTypes]
			WHERE typeId = @bagSubTypeId

	IF @bagClassificationTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[bagClassificationTypes]
			WHERE typeId = @bagClassificationTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[bagClassificationTypes]
			WHERE typeId = @bagClassificationTypeId

	IF @bagTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[bagTypes]
			WHERE typeId = @bagTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[bagTypes]
			WHERE typeId = @bagTypeId

	SELECT @minRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @minRarity

    RETURN @minRarityId
END

GO

