




CREATE PROCEDURE [dbo].[spCharacter_InventoryGetList]
	 @characterId uniqueIdentifier
AS
BEGIN
	SET NOCOUNT ON;
	Select  cI.instancedItemId, cI.locationInsideBag, 
	iI.itemTypeId, cI.spawnedWorldObjectId, cB.bagLocationId
	FROM [runtime].[spawnedWorldObjectsInventory] cI
	JOIN [runtime].[spawnedWorldObjectsBags] cB ON cB.characterBagId = cI.characterBagId
	JOIN [runtime].[instancedItems] iI ON cI.instancedItemId = iI.instancedItemId
	WHERE cI.spawnedWorldObjectId = @characterId
END

GO

