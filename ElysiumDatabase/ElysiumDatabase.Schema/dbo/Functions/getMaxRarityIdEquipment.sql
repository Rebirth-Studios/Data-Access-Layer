CREATE FUNCTION [dbo].[getMaxRarityIdEquipment](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @maxRarityId TINYINT
	DECLARE @maxRarity VARCHAR(255)
	DECLARE @equipmentTypeId TINYINT
	
	SET @maxRarityId = 0;

	SELECT @equipmentTypeId = equipmentMainTypeId
	FROM [content].[scriptableEquipment]
	WHERE globalObject = @globalObject

	IF @equipmentTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[equipmentTypes]
			WHERE typeId = @equipmentTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[equipmentTypes]
			WHERE typeId = @equipmentTypeId

	SELECT @maxRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @maxRarity

    RETURN @maxRarityId
END

GO

