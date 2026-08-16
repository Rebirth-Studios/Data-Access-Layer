CREATE FUNCTION [dbo].[getStatMultiplierEntity](@globalObject varchar(100), @statId tinyint, @statTypeId tinyint)
RETURNS DECIMAL(5,2)
AS
BEGIN
    DECLARE @multiplier DECIMAL(5,2)
	DECLARE @typeNameEntity VARCHAR(100)
	
	SET @typeNameEntity = dbo.getTypeNameEntity(@globalObject);
	IF (@typeNameEntity = 'Animal') SET @multiplier = dbo.getStatMultiplierAnimal(@globalObject, @statId, @statTypeId);
	ELSE IF (@typeNameEntity = 'Enemy Humanoid') SET @multiplier = dbo.getStatMultiplierEnemyHumanoid(@globalObject, @statId, @statTypeId);
	ELSE IF (@typeNameEntity = 'Monster') SET @multiplier = dbo.getStatMultiplierMonster(@globalObject, @statId, @statTypeId);
	ELSE IF (@typeNameEntity = 'Npc') SET @multiplier = dbo.getStatMultiplierNpc(@globalObject, @statId, @statTypeId);

    RETURN @multiplier
END

GO

