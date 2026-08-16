

CREATE FUNCTION [dbo].[getCollectMainTypeName](@collectTypeId tinyint, @typeId tinyint)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)
	DECLARE @collectTypeName VARCHAR(255)

	SET @collectTypeName = ([dbo].[getItemTypeName](@collectTypeId))

	IF @collectTypeName = 'Ammunition'
		SELECT @type = typeName
		FROM [content].[ammunitionTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Bag'
		SELECT @type = typeName
		FROM [content].[bagTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Consumable'
		SELECT @type = typeName
		FROM [content].[consumableTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Currency'
		SET @type = 'Currency'
	ELSE IF @collectTypeName = 'Equipment'
		SELECT @type = typeName
		FROM [content].[equipmentTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'General Item'
		SELECT @type = typeName
		FROM [content].[generalItemTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'Material'
		SELECT @type = typeName
		FROM [content].[materialTypes]
		WHERE typeId = @typeId
	ELSE IF @collectTypeName = 'None'
		SET @type = 'None'
		
    RETURN @type
END

GO

