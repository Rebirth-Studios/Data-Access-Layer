CREATE PROCEDURE [dbo].[spCharacter_InventoryGetAll]
AS
BEGIN TRY
    SET NOCOUNT ON;
    Select cI.instancedItemId, cI.locationInsideBag, 
	iI.itemTypeId, cI.spawnedWorldObjectId, cB.bagLocationId
    FROM [runtime].[spawnedWorldObjectsInventory] cI
	JOIN [runtime].[spawnedWorldObjectsBags] cB ON cB.characterBagId = cI.characterBagId
	JOIN [runtime].[instancedItems] iI ON cI.instancedItemId = iI.instancedItemId
           
END TRY

BEGIN CATCH

END CATCH

GO

