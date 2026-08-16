CREATE FUNCTION [dbo].[getAbilityType](@abilityTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[abilityTypes]
	WHERE typeId = @abilityTypeId

    RETURN @type
END

GO

