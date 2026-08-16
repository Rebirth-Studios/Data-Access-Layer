
CREATE FUNCTION [dbo].[getMinRarityIdAmmunition](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @minRarityId TINYINT
	DECLARE @minRarity VARCHAR(255)
	DECLARE @ammunitionTypeId TINYINT
	DECLARE @ammunitionClassificationTypeId TINYINT
	
	SET @minRarityId = 0;

	SELECT @ammunitionTypeId = ammunitionMainTypeId, @ammunitionClassificationTypeId = ammunitionClassificationTypeId
	FROM [content].[scriptableAmmunition]
	WHERE globalObject = @globalObject

	IF @ammunitionClassificationTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[ammunitionClassificationTypes]
			WHERE typeId = @ammunitionClassificationTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[ammunitionClassificationTypes]
			WHERE typeId = @ammunitionClassificationTypeId

	IF @ammunitionTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[ammunitionTypes]
			WHERE typeId = @ammunitionTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[ammunitionTypes]
			WHERE typeId = @ammunitionTypeId

	SELECT @minRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @minRarity

    RETURN @minRarityId
END

GO

