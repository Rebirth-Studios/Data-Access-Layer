


CREATE FUNCTION [dbo].[getCraftSubTypeName](@craftTypeId tinyint, @typeId tinyint)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)
	DECLARE @craftTypeName VARCHAR(255)
	DECLARE @equipmentTypeName VARCHAR(255)

	SET @craftTypeName = ([dbo].[getItemTypeName](@craftTypeId))

	IF @craftTypeName = 'Ammunition'
		SELECT @type = typeName
		FROM [content].[ammunitionSubTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Bag'
		SELECT @type = typeName
		FROM [content].[bagSubTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Consumable'
		SELECT @type = typeName
		FROM [content].[consumableSubTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Currency'
		SET @type = 'Currency'
	ELSE IF @craftTypeName = 'Equipment'
		SET @type = 'None'
	ELSE IF @craftTypeName = 'General Item'
		SELECT @type = typeName
		FROM [content].[generalItemSubTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'Material'
		SELECT @type = typeName
		FROM [content].[materialSubTypes]
		WHERE typeId = @typeId
	ELSE IF @craftTypeName = 'None'
		SET @type = 'None'

    RETURN @type
END

GO

