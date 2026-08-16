


CREATE FUNCTION [dbo].[getCraftClassificationTypeName](@craftTypeId tinyint, @craftMainTypeId tinyint, @typeId tinyint)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)
	DECLARE @craftTypeName VARCHAR(255)
	DECLARE @equipmentTypeName VARCHAR(255)

	SET @craftTypeName = ([dbo].[getItemTypeName](@craftTypeId))

	IF @craftTypeName = 'Ammunition'
		SELECT @type = typeName
		FROM [content].[ammunitionClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Bag'
		SELECT @type = typeName
		FROM [content].[bagClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Consumable'
		SELECT @type = typeName
		FROM [content].[consumableClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Currency'
		SET @type = 'Currency'
	ELSE IF @craftTypeName = 'Equipment'
		SET @equipmentTypeName = ([dbo].[getEquipmentTypeName](@craftMainTypeId))
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
	ELSE IF @craftTypeName = 'General Item'
		SELECT @type = typeName
		FROM [content].[generalItemClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Material'
		SELECT @type = typeName
		FROM [content].[materialClassificationTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'None'
		SET @type = 'None'

    RETURN @type
END

GO

