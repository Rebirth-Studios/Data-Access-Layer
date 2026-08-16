CREATE FUNCTION [dbo].[getMaxRarityIdItem](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @maxRarityId TINYINT
	DECLARE @itemTypeName VARCHAR(255)
	DECLARE @isImbued BIT

	SET @maxRarityId = 0;

	SELECT @itemTypeName = item.typeName, @isImbued = isImbued
	FROM [content].[scriptableItems] si
	JOIN [content].[itemTypes] item ON si.itemTypeId = item.typeId
	WHERE globalObject = @globalObject

	IF @itemTypeName = 'Ammunition' SET @maxRarityId = dbo.getMaxRarityIdAmmunition(@globalObject, @isImbued);
	IF @itemTypeName = 'Bag' SET @maxRarityId = dbo.getMaxRarityIdBag(@globalObject, @isImbued);
	IF @itemTypeName = 'Consumable' SET @maxRarityId = dbo.getMaxRarityIdConsumable(@globalObject, @isImbued);
	IF @itemTypeName = 'Equipment' SET @maxRarityId = dbo.getMaxRarityIdEquipment(@globalObject, @isImbued);
	IF @itemTypeName = 'General Item' SET @maxRarityId = dbo.getMaxRarityIdGeneralItem(@globalObject, @isImbued);
	IF @itemTypeName = 'Material' SET @maxRarityId = dbo.getMaxRarityIdMaterial(@globalObject, @isImbued);

    RETURN @maxRarityId
END

GO

