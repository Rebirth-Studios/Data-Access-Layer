


-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated 12/19/2021: Updated to work across characters
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 02/27/2022 - Updated to support @characterBagId changing from uniqueIdentifier to int, replaced @fromBagId with @fromSpawnedWorldObjectId and @toBagId with @toSpawnedWorldObjectId
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables
-- Description: Moves bag from one bagLocationIndex to another bagLocationIndex
-- =============================================

CREATE procedure [dbo].[spCharacter_InventoryMergeStacks]
	@fromSpawnedWorldObjectId uniqueIdentifier,
	@fromBagSlot tinyint,
	@fromQuantity tinyint,
	@toSpawnedWorldObjectId uniqueIdentifier,
	@toBagSlot tinyint,
	@toQuantity tinyint,
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
	@insertBatchProcessingCount bit,
	@fromBagId int,
	@selectToCharacterBagIdCount tinyint,
	@toBagId int,
	@selectFromCharacterBagIdCount tinyint,
	@fromInventoryId uniqueIdentifier,
	@fromItemId uniqueIdentifier,
	@toItemId uniqueIdentifier,
	@selectFromCount int,
	@selectToCount int,
	@updatefromQuantityCount int,
	@updatetoQuantityCount int,
	@deleteInventoryCount int,
	@deleteConsumableCount int,
	@deleteMaterialCount int,
	@deleteGeneralItemsCount int,
	@deleteItemCount int
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @fromSpawnedWorldObjectId - ', @fromSpawnedWorldObjectId, 
		 '  @fromBagSlot - ', @fromBagSlot, 
		 '  @fromQuantity  - ', @fromQuantity ,
		 '  @toSpawnedWorldObjectId - ', @toSpawnedWorldObjectId,
		 '  @toSlotId - ', @toBagSlot,
		 '  @toQuantity  - ', @toQuantity,
		 '  @logging  - ', @logging,
		 '  @batchRowId  - ', @batchRowId)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	--RETRIEVE From Character Bag Id
	SELECT @fromBagId = characterBagId
	FROM [runtime].[spawnedWorldObjectsBags]
	WHERE spawnedWorldObjectId = @fromSpawnedWorldObjectId AND bagLocationId = @fromBagSlot
	SET @selectFromCharacterBagIdCount = @@rowcount

	--RETRIEVE To Character Bag Id
	SELECT @toBagId = characterBagId
	FROM [runtime].[spawnedWorldObjectsBags]
	WHERE spawnedWorldObjectId = @toSpawnedWorldObjectId AND bagLocationId = @toBagSlot
	SET @selectToCharacterBagIdCount = @@rowcount


	--FIND FROM_Stack ItemId
	SELECT @fromItemId = instancedItemId
	FROM [runtime].[spawnedWorldObjectsInventory]
	WHERE characterBagId = @fromBagId AND locationInsideBag = @fromBagSlot
	SET @selectFromCount = @@rowcount

	--FIND TO_Stack ItemId
	SELECT @toItemId = instancedItemId
	FROM [runtime].[spawnedWorldObjectsInventory]
	WHERE characterBagId = @toBagId AND locationInsideBag = @toBagSlot
	SET @selectToCount = @@rowcount

	IF (@selectFromCount IS NOT NULL) AND (@selectToCount IS NOT NULL)
		BEGIN
			--UPDATE Item Quantity for FROM_Stack
			UPDATE [runtime].[instancedItems]
			SET quantity = @fromQuantity, lastUpdate = GETDATE()
			WHERE instancedItemId = @fromItemId
			SET @updateFromQuantityCount = @@rowcount

			--UPDATE Item Quantity for TO_Stack
			UPDATE [runtime].[instancedItems]
			SET quantity = @toQuantity, lastUpdate = GETDATE()
			WHERE instancedItemId = @toItemId
			SET @updateToQuantityCount = @@rowcount
		END
	ELSE
		SET @errCustomMessage = 'No Item found'
	
	IF @fromQuantity = 0
		BEGIN
			--DELETE ITEM FROM INVENTORY
			DELETE
			FROM [runtime].[spawnedWorldObjectsInventory]
			WHERE instancedItemId = @fromItemId
			SET @deleteInventoryCount = @@rowcount

			--DELETE ITEM FROM Consumable Items
			DELETE
			FROM [runtime].[instancedConsumables]
			WHERE instancedItemId = @fromItemId
			SET @deleteConsumableCount = @@rowcount

			--DELETE ITEM FROM Materials Items
			DELETE
			FROM [runtime].[instancedMaterials]
			WHERE instancedItemId = @fromItemId
			SET @deleteMaterialCount = @@rowcount

			--DELETE ITEM FROM General Items Items
			DELETE
			FROM [runtime].[instancedMaterials]
			WHERE instancedItemId = @fromItemId
			SET @deleteGeneralItemsCount = @@rowcount


			--DELETE ITEM FROM Instanced Items
			DELETE
			FROM [runtime].[instancedItems]
			WHERE instancedItemId = @fromItemId
			SET @deleteItemCount = @@rowcount
		END

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	--IF (@selectUnEquipCount = 0) AND ((@equipType = 0) OR (@equipType = 2)) SET @errCustomMessage = 'ITEM TO DE-EQUIP WAS NOT FOUND'
	


	--IF CUSTOM ERROR MESSAGE SET OR LOGGING ENABLED
	IF (@logging = 1) OR (@errCustomMessage IS NOT NULL)
	BEGIN
		INSERT INTO [ops].[DB_Errors]
		VALUES
		(SUSER_SNAME(),
		0,
		0,
		0,
		0,
		@@PROCID,
		@errCustomMessage,
		GETDATE(),
		CONCAT_WS(',','  @errParameters - ', @errParameters, 
		 '  @fromInventoryId - ', @fromInventoryId, 
		 '  @fromItemId - ', @fromItemId, 
		 '  @toItemId - ', @toItemId,
		 '  @selectFromCount  - ', @selectFromCount ,
		 '  @selectToCount - ', @selectToCount,
		 '  @updatefromQuantityCount - ', @updateFromQuantityCount,
		 '  @updateToQuantityCount - ', @updateToQuantityCount,
		 '  @deleteInventoryCount - ', @deleteInventoryCount,
		 '  @deleteConsumableCount - ', @deleteConsumableCount,
		 '  @deleteMaterialCount - ', @deleteMaterialCount,
		 '  @deleteGeneralItemsCount - ', @deleteGeneralItemsCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount,
		 '  @deleteItemCount - ', @deleteItemCount));
	END

END TRY

BEGIN CATCH
	SET @errMessage = ERROR_MESSAGE()

	INSERT INTO [ops].[DB_Errors]
		VALUES
		(SUSER_SNAME(),
		ERROR_NUMBER(),
		ERROR_STATE(),
		ERROR_SEVERITY(),
		ERROR_LINE(),
		ERROR_PROCEDURE(),
		ERROR_MESSAGE(),
		GETDATE(),
		CONCAT_WS(',','  @errParameters - ', @errParameters, 
		 '  @fromInventoryId - ', @fromInventoryId, 
		 '  @fromItemId - ', @fromItemId, 
		 '  @toItemId - ', @toItemId,
		 '  @selectFromCount  - ', @selectFromCount ,
		 '  @selectToCount - ', @selectToCount,
		 '  @updatefromQuantityCount - ', @updateFromQuantityCount,
		 '  @updateToQuantityCount - ', @updateToQuantityCount,
		 '  @deleteInventoryCount - ', @deleteInventoryCount,
		 '  @deleteConsumableCount - ', @deleteConsumableCount,
		 '  @deleteMaterialCount - ', @deleteMaterialCount,
		 '  @deleteGeneralItemsCount - ', @deleteGeneralItemsCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount,
		 '  @deleteItemCount - ', @deleteItemCount));
 END CATCH

GO

