CREATE FUNCTION [dbo].[getMinRarityIdItem](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @minRarityId TINYINT
	DECLARE @itemTypeName VARCHAR(255)
	DECLARE @isImbued BIT

	SET @minRarityId = 0;

	SELECT @itemTypeName = item.typeName, @isImbued = isImbued
	FROM [content].[scriptableItems] si
	JOIN [content].[itemTypes] item ON si.itemTypeId = item.typeId
	WHERE globalObject = @globalObject

	IF @itemTypeName = 'Ammunition' SET @minRarityId = dbo.getMinRarityIdAmmunition(@globalObject, @isImbued);
	IF @itemTypeName = 'Bag' SET @minRarityId = dbo.getMinRarityIdBag(@globalObject, @isImbued);
	IF @itemTypeName = 'Consumable' SET @minRarityId = dbo.getMinRarityIdConsumable(@globalObject, @isImbued);
	IF @itemTypeName = 'Equipment' SET @minRarityId = dbo.getMinRarityIdEquipment(@globalObject, @isImbued);
	IF @itemTypeName = 'General Item' SET @minRarityId = dbo.getMinRarityIdGeneralItem(@globalObject, @isImbued);
	IF @itemTypeName = 'Material' SET @minRarityId = dbo.getMinRarityIdMaterial(@globalObject, @isImbued);

    RETURN @minRarityId
END

GO

