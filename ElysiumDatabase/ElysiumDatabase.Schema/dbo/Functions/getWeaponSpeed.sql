CREATE FUNCTION [getWeaponSpeed](
@globalObject varchar(255), 
@weaponTypeId tinyint)
RETURNS DECIMAL (5,2)
AS
BEGIN
    declare @weaponSpeed decimal (5,2)
	declare @overrideValue decimal (5,2)
	SELECT @overrideValue = attackSpeedOverride from [content].[scriptableWeapons] where globalObject = @globalObject
	--SELECT @weaponSpeed = attackSpeed from [content].[weaponsBase] where weaponTypeId = @weaponTypeId
	IF (@overrideValue > 0) SET @weaponSpeed = @overrideValue
    ELSE SELECT @weaponSpeed = attackSpeed from [content].[weaponsBase] where weaponTypeId = @weaponTypeId
    RETURN @weaponSpeed
END

GO

