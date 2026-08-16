CREATE FUNCTION [dbo].[getAbilitySlotType](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[abilitySlotTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

