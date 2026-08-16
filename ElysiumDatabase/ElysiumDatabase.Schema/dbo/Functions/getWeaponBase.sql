
CREATE FUNCTION [dbo].[getWeaponBase](@typeId VARCHAR(255), @globalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	IF @globalObject = 'mainhandBase' SET @type = 'baseMainhand'
	ELSE IF @globalObject = 'offhandBase' SET @type = 'baseOffhand'
	ELSE
	SELECT @type = weaponBase
	FROM [content].[weaponsBase]
	WHERE weaponTypeId = @typeId

    RETURN @type
END

GO

