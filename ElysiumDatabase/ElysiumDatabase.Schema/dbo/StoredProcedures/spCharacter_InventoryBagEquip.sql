

-- =============================================
-- Author: Eric Ingram
-- Create date: 10/28/2021
-- Updated: 11/09/2021
-- Updated: 12/16/2021 - Fixed issue with Equipping bag: Added AND characterBagId = @containerBagId to query and added custom error message
-- Updated: 12/16/2021 - Add Type 2 Swap Bags
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 02/27/2022 - Updated to support @characterBagId changing from uniqueIdentifier to int
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables
-- Description: Can be used to equip or de-equip bag. @equipType 0 is for de-equipping bags, @equipType 1 is for equipping bags.
-- =============================================
CREATE procedure [dbo].[spCharacter_InventoryBagEquip] 
    @characterId uniqueIdentifier,
	@equippedBagLocationIndex tinyint, --TYPE 0:  Index of bag you want to de-equip. TYPE 1: Index where you want to equip the bag to.
	@containerBagLocationIndex tinyint, --TYPE 0: Index of container bag where the de-equipped bag will be placed.  TYPE 1: Index of container bag where the bag you want to equip currently resides.
	@bagSlotIndex tinyint, --TYPE 0: Which slot inside the container bag to put the bag being de-equipped.  TYPE 1: Which slot inside the container bag where the bag you want to equip currently resides.
	@equipType tinyint,
	@logging bit,
	@batchRowId int,
	--@newGUID uniqueIdentifier, --TYPE 0: Used to insert record into characterInventory. TYPE 1: Used to insert record into charactersBags
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
	--@storedProcedureName varchar(255),
	@insertBatchProcessingCount tinyint,
	@equippedBagItemId uniqueIdentifier,
	@dequippedBagItemId uniqueIdentifier,
	@containerBagItemId uniqueIdentifier,
	@containerBagId int,
	@selectEquippedBagCount int,
	@selectDequippedBagCount int,
	@selectContainerBagCount int,
	@deleteDequippedCount int,
	@deleteEquippedCount int,
	@insertDequippedCount int,
	@insertEquippedCount int
BEGIN TRY
	SET @errParameters =  CONCAT_WS(',','@characterId - ', @characterId, 
		 '  @equippedBagLocationIndex - ', @equippedBagLocationIndex,
		 '  @containerBagLocationIndex - ', @containerBagLocationIndex, 
		 '  @bagSlotIndex - ', @bagSlotIndex, 
		 '  @equipType - ', @equipType, 
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)
		 --'  @newGUID - ', @newGUID)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	--TYPE 0: FIND instancedItemId for the container BAG where the bag you want de-equip will be placed. 
	--TYPE 1: FIND instancedItemId for the container BAG for where the bag you want to equip currently resides.
	SELECT @containerBagItemId = instancedItemId, @containerBagId = characterBagId
	FROM [runtime].[spawnedWorldObjectsBags]
	WHERE spawnedWorldObjectId = @characterId AND bagLocationId = @containerBagLocationIndex
	SET @selectContainerBagCount = @@rowcount

	--TYPE 0: DE-EQUIP
	If @equipType = 0
	BEGIN
		--TYPE 0: FIND instancedItemId for the BAG TO DE-EQUIP. 
		SELECT @dequippedBagItemId = instancedItemId
		FROM [runtime].[spawnedWorldObjectsBags]
		WHERE spawnedWorldObjectId = @characterId AND bagLocationId = @equippedBagLocationIndex
		SET @selectDequippedBagCount = @@rowcount
		
		--DELETE BAG TO DE-EQUIP FROM CHARACTER BAGS TABLE 
		IF (@selectDequippedBagCount = 1) AND (@selectContainerBagCount = 1)
		BEGIN
			DELETE
			FROM [runtime].[spawnedWorldObjectsBags]
			WHERE spawnedWorldObjectId = @characterId AND instancedItemId = @dequippedBagItemId
			SET @deleteDequippedCount = @@rowcount
		END

		--INSERT DE-EQUIPPED BAG INTO CHARACTER INVENTORY
		IF @deleteDequippedCount = 1
		BEGIN
			INSERT INTO [runtime].[spawnedWorldObjectsInventory](spawnedWorldObjectId, instancedItemId, characterBagId, locationInsideBag, lastUpdate)
			VALUES (@characterId, @dequippedBagItemId, @containerBagId, @bagSlotIndex, GETDATE())  
			SET @insertDequippedCount = @@rowcount
		END
	END
	
	--TYPE 1: EQUIP
	If @equipType = 1
	BEGIN
		--TYPE 1: FIND instancedItemId for the BAG TO EQUIP. 
		SELECT @equippedBagItemId = instancedItemId
		FROM [runtime].[spawnedWorldObjectsInventory]
		WHERE spawnedWorldObjectId = @characterId AND characterBagId = @containerBagId And locationInsideBag = @bagSlotIndex
		SET @selectEquippedBagCount = @@rowcount

		--DELETE BAG TO EQUIP FROM CHARACTER INVENTORY TABLE
		IF (@selectEquippedBagCount = 1) AND (@selectContainerBagCount = 1)
		BEGIN
			DELETE
			FROM [runtime].[spawnedWorldObjectsInventory]
			WHERE spawnedWorldObjectId = @characterId AND instancedItemId = @equippedBagItemId
			SET @deleteEquippedCount = @@rowcount
		END

		--INSERT EQUIPPED BAG INTO CHARACTER BAGS
		IF @deleteEquippedCount = 1
		BEGIN
			INSERT INTO [runtime].[spawnedWorldObjectsBags](spawnedWorldObjectId, instancedItemId, bagLocationId, lastUpdate)
			VALUES (@characterId, @equippedBagItemId, @equippedBagLocationIndex, GETDATE())
			SET @insertEquippedCount = @@rowcount
		END
	END

	--TYPE 2: SWAP BAGS
	If @equipType = 2
	BEGIN
		--FIND instancedItemId for the BAG TO DE-EQUIP. 
		SELECT @dequippedBagItemId = instancedItemId
		FROM [runtime].[spawnedWorldObjectsBags]
		WHERE spawnedWorldObjectId = @characterId AND bagLocationId = @equippedBagLocationIndex
		SET @selectDequippedBagCount = @@rowcount

		--FIND instancedItemId for the BAG TO EQUIP. 
		SELECT @equippedBagItemId = instancedItemId
		FROM [runtime].[spawnedWorldObjectsInventory]
		WHERE spawnedWorldObjectId = @characterId AND characterBagId = @containerBagId And locationInsideBag = @bagSlotIndex
		SET @selectEquippedBagCount = @@rowcount

		--DELETE BAG TO DE-EQUIP FROM CHARACTER BAGS TABLE 
		IF (@selectDequippedBagCount = 1) AND (@selectContainerBagCount = 1)
		BEGIN
			DELETE
			FROM [runtime].[spawnedWorldObjectsBags]
			WHERE spawnedWorldObjectId = @characterId AND instancedItemId = @dequippedBagItemId
			SET @deleteDequippedCount = @@rowcount
		END

		--DELETE BAG TO EQUIP FROM CHARACTER INVENTORY TABLE
		IF (@selectEquippedBagCount = 1) AND (@selectContainerBagCount = 1)
		BEGIN
			DELETE
			FROM [runtime].[spawnedWorldObjectsInventory]
			WHERE spawnedWorldObjectId = @characterId AND instancedItemId = @equippedBagItemId
			SET @deleteEquippedCount = @@rowcount
		END

		--INSERT DE-EQUIPPED BAG INTO CHARACTER INVENTORY
		IF @deleteDequippedCount = 1
		BEGIN
			INSERT INTO [runtime].[spawnedWorldObjectsInventory](spawnedWorldObjectId, instancedItemId, characterBagId, locationInsideBag, lastUpdate)
			VALUES (@characterId, @dequippedBagItemId, @containerBagId, @bagSlotIndex, GETDATE())  
			SET @insertDequippedCount = @@rowcount
		END

		--INSERT EQIUPPED BAG INTO CHARACTER BAGS
		IF @deleteEquippedCount = 1
		BEGIN
			INSERT INTO [runtime].[spawnedWorldObjectsBags](spawnedWorldObjectId, instancedItemId, bagLocationId, lastUpdate)
			VALUES (@characterId, @equippedBagItemId, @equippedBagLocationIndex, GETDATE())
			SET @insertEquippedCount = @@rowcount
		END
	END



	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@selectDequippedBagCount = 0) AND ((@equipType = 0) OR (@equipType = 2)) SET @errCustomMessage = 'BAG TO DE-EQUIP WAS NOT FOUND'
	IF (@selectEquippedBagCount = 0) AND ((@equipType = 1) OR (@equipType = 2)) SET @errCustomMessage = 'BAG TO EQUIP WAS NOT FOUND'
	IF (@selectContainerBagCount = 0) AND ((@equipType = 0) OR (@equipType = 2)) SET @errCustomMessage = 'CONTAINER BAG WHERE TO PLACE DE-EQUIP BAG WAS NOT FOUND'
	IF (@selectContainerBagCount = 0) AND ((@equipType = 1) OR (@equipType = 2)) SET @errCustomMessage = 'CONTAINER BAG WHERE TO FIND BAG TO EQUIP WAS NOT FOUND'
	IF (@deleteEquippedCount = 1) AND (@insertEquippedCount = 0) SET  @errCustomMessage = 'BAG DELETED BUT NOT EQUIPPED'
	IF (@deleteDequippedCount = 1) AND (@insertDequippedCount = 0) SET  @errCustomMessage = 'BAG DELETED BUT NOT PLACED INTO BAG'
	IF (@selectEquippedBagCount > 1) SET @errCustomMessage = 'MORE THAN ONE BAG TO EQUIP FOUND WHICH SHOULD NOT BE POSSIBLE!!!'
	IF (@selectDequippedBagCount > 1) SET @errCustomMessage = 'MORE THAN ONE BAG TO DE-EQUIP FOUND WHICH SHOULD NOT BE POSSIBLE!!!'

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
		 '  @equippedBagItemId- ', @equippedBagItemId,
		 '  @dequippedBagItemId- ', @dequippedBagItemId, 
		 '  @containerBagLocationIndex- ', @containerBagLocationIndex, 
		 '  @containerBagId- ', @containerBagId, 
		 '  @selectEquippedBagCount - ', @selectEquippedBagCount,
		 '  @selectDequippedBagCount - ', @selectDequippedBagCount, 
		 '  @selectContainerBagCount - ', @selectContainerBagCount, 
		 '  @deleteDequippedCount - ', @deleteDequippedCount,
		 '  @deleteEquippedCount - ', @deleteEquippedCount,
		 '  @insertDequippedCount - ', @insertDequippedCount,
		 '  @insertEquippedCount - ', @insertEquippedCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
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
		 '  @equippedBagItemId- ', @equippedBagItemId,
		 '  @dequippedBagItemId- ', @dequippedBagItemId, 
		 '  @containerBagLocationIndex- ', @containerBagLocationIndex, 
		 '  @containerBagId- ', @containerBagId, 
		 '  @selectEquippedBagCount - ', @selectEquippedBagCount,
		 '  @selectDequippedBagCount - ', @selectDequippedBagCount, 
		 '  @selectContainerBagCount - ', @selectContainerBagCount, 
		 '  @deleteDequippedCount - ', @deleteDequippedCount,
		 '  @deleteEquippedCount - ', @deleteEquippedCount,
		 '  @insertDequippedCount - ', @insertDequippedCount,
		 '  @insertEquippedCount - ', @insertEquippedCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
END CATCH

GO

