CREATE FUNCTION [dbo].[getMaxRarityIdAmmunition](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @maxRarityId TINYINT
	DECLARE @maxRarity VARCHAR(255)
	DECLARE @ammunitionTypeId TINYINT
	DECLARE @ammunitionClassificationTypeId TINYINT
	
	SET @maxRarityId = 0;

	SELECT @ammunitionTypeId = ammunitionMainTypeId, @ammunitionClassificationTypeId = ammunitionClassificationTypeId
	FROM [content].[scriptableAmmunition]
	WHERE globalObject = @globalObject

	IF @ammunitionClassificationTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[ammunitionClassificationTypes]
			WHERE typeId = @ammunitionClassificationTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[ammunitionClassificationTypes]
			WHERE typeId = @ammunitionClassificationTypeId

	IF @ammunitionTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[ammunitionTypes]
			WHERE typeId = @ammunitionTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[ammunitionTypes]
			WHERE typeId = @ammunitionTypeId

	SELECT @maxRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @maxRarity

    RETURN @maxRarityId
END

GO

