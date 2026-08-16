


CREATE FUNCTION [dbo].[getCollectSubTypeName](@collectTypeId tinyint, @typeId tinyint)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)
	DECLARE @collectTypeName VARCHAR(255)
	DECLARE @equipmentTypeName VARCHAR(255)

	SET @collectTypeName = ([dbo].[getItemTypeName](@collectTypeId))

	IF @collectTypeName = 'Ammunition'
		SELECT @type = typeName
		FROM [content].[ammunitionSubTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Bag'
		SELECT @type = typeName
		FROM [content].[bagSubTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Consumable'
		SELECT @type = typeName
		FROM [content].[consumableSubTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Currency'
		SET @type = 'Currency'
	ELSE IF @collectTypeName = 'Equipment'
		SET @type = 'None'
	ELSE IF @collectTypeName = 'General Item'
		SELECT @type = typeName
		FROM [content].[generalItemSubTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Material'
		SELECT @type = typeName
		FROM [content].[materialSubTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'None'
		SET @type = 'None'

    RETURN @type
END

GO

