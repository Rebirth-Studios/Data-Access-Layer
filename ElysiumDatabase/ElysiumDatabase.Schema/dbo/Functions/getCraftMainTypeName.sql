

CREATE FUNCTION [dbo].[getCraftMainTypeName](@craftTypeId tinyint, @typeId tinyint)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)
	DECLARE @craftTypeName VARCHAR(255)

	SET @craftTypeName = ([dbo].[getItemTypeName](@craftTypeId))

	IF @craftTypeName = 'Ammunition'
		SELECT @type = typeName
		FROM [content].[ammunitionTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Bag'
		SELECT @type = typeName
		FROM [content].[bagTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Consumable'
		SELECT @type = typeName
		FROM [content].[consumableTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Currency'
		SET @type = 'Currency'
	ELSE IF @craftTypeName = 'Equipment'
		SELECT @type = typeName
		FROM [content].[equipmentTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'General Item'
		SELECT @type = typeName
		FROM [content].[generalItemTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Material'
		SELECT @type = typeName
		FROM [content].[materialTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'None'
		SET @type = 'None'
		
    RETURN @type
END

GO

