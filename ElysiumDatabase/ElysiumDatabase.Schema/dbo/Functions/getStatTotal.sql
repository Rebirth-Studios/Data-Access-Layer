CREATE FUNCTION [dbo].[getStatTotal](@globalObject varchar(100), @statId tinyint, @statTypeId tinyint, @scriptableObjectSpawnable varchar(100), @isCustom bit, @statInitialValue decimal(18,2))
RETURNS Decimal(18,2)
AS
BEGIN
    DECLARE @statTotal Decimal(18,2)
	DECLARE @statBase Decimal(18,2)
	DECLARE @statMultiplierLevel Decimal(18,2)
	DECLARE @statMultiplierType Decimal(18,2)
	DECLARE @statMultiplierImbued Decimal(18,2)
	DECLARE @statMultiplierDifficulty Decimal(18,2)


	SET @statBase = dbo.getStatBaseEntity(@globalObject, @statId, @statTypeId)
	SET @statMultiplierLevel = dbo.getStatMultiplierLevel(@globalObject, @scriptableObjectSpawnable)
	SET @statMultiplierType = dbo.getStatMultiplierEntity(@globalObject, @statId, @statTypeId)
	SET @statMultiplierImbued = dbo.getStatMultiplierImbued(@scriptableObjectSpawnable, @statId, @statTypeId)
	SET @statMultiplierDifficulty = dbo.getStatMultiplierDifficulty(@scriptableObjectSpawnable, @statId, @statTypeId)

	IF (@isCustom = 0) SET @statTotal = @statBase * @statMultiplierLevel * @statMultiplierType * @statMultiplierImbued * @statMultiplierDifficulty
	ELSE SET @statTotal = @statInitialValue * @statMultiplierLevel * @statMultiplierType * @statMultiplierImbued * @statMultiplierDifficulty

    RETURN @statTotal
END

GO

