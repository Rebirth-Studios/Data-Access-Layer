CREATE FUNCTION [dbo].[getMinRarityIdEquipment](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @minRarityId TINYINT
	DECLARE @minRarity VARCHAR(255)
	DECLARE @equipmentTypeId TINYINT
	
	SET @minRarityId = 0;

	SELECT @equipmentTypeId = equipmentMainTypeId
	FROM [content].[scriptableEquipment]
	WHERE globalObject = @globalObject

	IF @equipmentTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[equipmentTypes]
			WHERE typeId = @equipmentTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[equipmentTypes]
			WHERE typeId = @equipmentTypeId


	SELECT @minRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @minRarity

    RETURN @minRarityId
END

GO

