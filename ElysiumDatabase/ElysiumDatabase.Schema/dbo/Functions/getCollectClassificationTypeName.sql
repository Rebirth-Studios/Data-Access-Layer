


CREATE FUNCTION [dbo].[getCollectClassificationTypeName](@collectTypeId tinyint, @collectMainTypeId tinyint, @typeId tinyint)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)
	DECLARE @collectTypeName VARCHAR(255)
	DECLARE @equipmentTypeName VARCHAR(255)

	SET @collectTypeName = ([dbo].[getItemTypeName](@collectTypeId))

	IF @collectTypeName = 'Ammunition'
		SELECT @type = typeName
		FROM [content].[ammunitionClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Bag'
		SELECT @type = typeName
		FROM [content].[bagClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Consumable'
		SELECT @type = typeName
		FROM [content].[consumableClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Currency'
		SET @type = 'Currency'
	ELSE IF @collectTypeName = 'Equipment'
		SET @equipmentTypeName = ([dbo].[getEquipmentTypeName](@collectMainTypeId))
		IF @equipmentTypeName = 'Armor'
			SELECT @type = typeName
			FROM [content].[armorSlotTypes]
			WHERE typeId = @typeId
		ELSE IF @equipmentTypeName = 'Jewelry'
			SELECT @type = typeName
			FROM [content].[jewelryTypes]
			WHERE typeId = @typeId
		ELSE IF @equipmentTypeName = 'Weapon'
			SELECT @type = typeName
			FROM [content].[weaponTypes]
			WHERE typeId = @typeId
		ELSE IF @equipmentTypeName = 'None'
			SET @type = 'None'
	ELSE IF @collectTypeName = 'General Item'
		SELECT @type = typeName
		FROM [content].[generalItemClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Material'
		SELECT @type = typeName
		FROM [content].[materialClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'None'
		SET @type = 'None'

    RETURN @type
END

GO

