-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 12/30/2021 - Fixed error
-- Updated: 02/12/2021 - Removed code updating spawnedWorld ObjectId on instanced tables except for instancedItems and updated error handling
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 02/27/2022 - Updated to support @characterBagId changing from uniqueIdentifier to int, removed @fromBagId and @toBagId from parameters
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables
-- Description: Can be used to move items
-- =============================================
CREATE procedure [dbo].[spCharacter_InventoryMove]
    @fromCharacterId uniqueIdentifier,
	@fromBagSlot tinyint,
	@toCharacterId uniqueIdentifier,
	@toBagSlot tinyint,
	@logging bit,
	@batchRowId tinyint,
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
	@fromItemId uniqueIdentifier,
	@toItemId uniqueIdentifier,
	@selectFromCount int,
	@selectToCount int,
	@updateFromItemTempCount int,
	@updateToItemCount int,
	@updateFromItemCount int,
	@moveItemLocation int
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','@fromCharacterId - ', @fromCharacterId, 
		 '  @fromBagId - ', @fromBagId, 
		 '  @fromBagSlot - ', @fromBagSlot, 
		 '  @toCharacterId - ', @toCharacterId,
		 '  @toBagId  - ', @toBagId ,
		 '  @toBagSlot - ', @toBagSlot,
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)
	
	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	--RETRIEVE From Character Bag Id
	SELECT @fromBagId = characterBagId
	FROM [runtime].[spawnedWorldObjectsBags]
	WHERE spawnedWorldObjectId = @fromCharacterId AND bagLocationId = @fromBagSlot
	SET @selectFromCharacterBagIdCount = @@rowcount

	--RETRIEVE To Character Bag Id
	SELECT @toBagId = characterBagId
	FROM [runtime].[spawnedWorldObjectsBags]
	WHERE spawnedWorldObjectId = @toCharacterId AND bagLocationId = @toBagSlot
	SET @selectToCharacterBagIdCount = @@rowcount

	SET @moveItemLocation = 99 -- Used to move item out of slot


	--FIND FROM ITEM
	SELECT @fromItemId = instancedItemId 
	FROM [runtime].[spawnedWorldObjectsInventory]
	WHERE spawnedWorldObjectId = @fromCharacterId AND characterBagId = @fromBagId AND locationInsideBag = @fromBagSlot
	SET @selectFromCount = @@rowcount

	--FIND TO ITEM
	SELECT @toItemId = instancedItemId 
	FROM [runtime].[spawnedWorldObjectsInventory]
	WHERE spawnedWorldObjectId = @toCharacterId AND characterBagId = @toBagId AND locationInsideBag = @toBagSlot
	SET @selectToCount = @@rowcount

	IF (@fromItemId IS NOT NULL) AND (@selectFromCount = 1)
	BEGIN
		IF (@fromCharacterId <> @toCharacterId) --IF MOVING TO DIFFERENT CHARACTER
		BEGIN
			IF (@selectToCount = 0) --IF NO ITEM IN TO_LOCATION
			BEGIN
				--MOVE fromBagSlot -> toBagSlot 
				UPDATE [runtime].[spawnedWorldObjectsInventory]
				SET locationInsideBag = @toBagSlot, lastUpdate = GETDATE(), characterBagId = @toBagId, spawnedWorldObjectId = @toCharacterId
				WHERE instancedItemId = @fromItemId
				SET @updateFromItemCount = @@rowcount
			END
			IF (@selectToCount = 1) --IF ITEM IN TO_LOCATION
			BEGIN
				--TEMP UPDATE FROM_ITEM TO LOCATION 99 SO THERE WILL NOT BE 2 ITEMS IN SAME LOCATION
				UPDATE [runtime].[spawnedWorldObjectsInventory]
				SET locationInsideBag = @moveItemLocation, lastUpdate = GETDATE()
				WHERE instancedItemId = @fromItemId
				SET @updateFromItemTempCount = @@rowcount

				--MOVE TO_ITEM -> FROM_BAGSLOT
				UPDATE [runtime].[spawnedWorldObjectsInventory]
				SET locationInsideBag = @fromBagSlot, lastUpdate = GETDATE(), spawnedWorldObjectId = @fromCharacterId, characterBagId = @fromBagId
				WHERE instancedItemId = @toItemId
				SET @updateToItemCount = @@rowcount

				--UPDATE Item Ownership
				UPDATE [runtime].[instancedItems]
				SET spawnedWorldObjectId = @fromCharacterId
				WHERE instancedItemId = @toItemId

				--MOVE FROM_ITEM -> TO_BAGSLOT 
				UPDATE [runtime].[spawnedWorldObjectsInventory]
				SET locationInsideBag = @toBagSlot, lastUpdate = GETDATE(), spawnedWorldObjectId = @toCharacterId, characterBagId = @toBagId
				WHERE instancedItemId = @fromItemId
				SET @updateFromItemCount = @@rowcount

				--UPDATE Item Ownership
				UPDATE [runtime].[instancedItems]
				SET spawnedWorldObjectId = @toCharacterId
				WHERE instancedItemId = @fromItemId

			END
		END


		


		ELSE--IF MOVING TO SAME CHARACTER
		BEGIN --IF MOVING TO SAME CHARACTER
			IF (@fromBagId = @toBagId) --IF MOVING TO SAME BAG
			BEGIN
				IF (@selectToCount = 0) --IF NO ITEM IN TO_LOCATION
				BEGIN
					--MOVE fromBagSlot -> toBagSlot 
					UPDATE [runtime].[spawnedWorldObjectsInventory]
					SET locationInsideBag = @toBagSlot, lastUpdate = GETDATE()
					WHERE instancedItemId = @fromItemId
					SET @updateFromItemCount = @@rowcount
				END
			
				IF (@selectToCount = 1) --IF ITEM IN TO_LOCATION
				BEGIN
					--TEMP UPDATE FROM_ITEM TO LOCATION 99 SO THERE WILL NOT BE 2 ITEMS IN SAME LOCATION
					UPDATE [runtime].[spawnedWorldObjectsInventory]
					SET locationInsideBag = @moveItemLocation, lastUpdate = GETDATE()
					WHERE instancedItemId = @fromItemId
					SET @updateFromItemTempCount = @@rowcount

					--MOVE TO_ITEM -> FROM_BAGSLOT
					UPDATE [runtime].[spawnedWorldObjectsInventory]
					SET locationInsideBag = @fromBagSlot, lastUpdate = GETDATE()
					WHERE instancedItemId = @toItemId
					SET @updateToItemCount = @@rowcount

					--MOVE FROM_ITEM -> TO_BAGSLOT 
					UPDATE [runtime].[spawnedWorldObjectsInventory]
					SET locationInsideBag = @toBagSlot, lastUpdate = GETDATE()
					WHERE instancedItemId = @fromItemId
					SET @updateFromItemCount = @@rowcount
				END
			END

			ELSE --IF MOVING TO DIFFERENT BAG
			BEGIN 
				IF (@selectToCount = 0) --IF NO ITEM IN TO_LOCATION
				BEGIN
					--MOVE fromBagSlot -> toBagSlot 
					UPDATE [runtime].[spawnedWorldObjectsInventory]
					SET locationInsideBag = @toBagSlot, lastUpdate = GETDATE(), characterBagId = @toBagId
					WHERE instancedItemId = @fromItemId
					SET @updateFromItemCount = @@rowcount
				END
		
				IF (@selectToCount = 1) --IF ITEM IN TO_LOCATION
				BEGIN
					--TEMP UPDATE FROM_ITEM TO LOCATION 99 SO THERE WILL NOT BE 2 ITEMS IN SAME LOCATION
					UPDATE [runtime].[spawnedWorldObjectsInventory]
					SET locationInsideBag = @moveItemLocation, lastUpdate = GETDATE()
					WHERE instancedItemId = @fromItemId
					SET @updateFromItemTempCount = @@rowcount

					--MOVE TO_ITEM -> FROM_BAGSLOT
					UPDATE [runtime].[spawnedWorldObjectsInventory]
					SET locationInsideBag = @fromBagSlot, lastUpdate = GETDATE(), characterBagId = @fromBagId
					WHERE instancedItemId = @toItemId
					SET @updateToItemCount = @@rowcount

					--MOVE FROM_ITEM -> TO_BAGSLOT 
					UPDATE [runtime].[spawnedWorldObjectsInventory]
					SET locationInsideBag = @toBagSlot, lastUpdate = GETDATE(), characterBagId = @toBagId
					WHERE instancedItemId = @fromItemId
					SET @updateFromItemCount = @@rowcount
				END
			END
		END
	END
	

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@selectfromCount = 0) SET @errCustomMessage = 'NO ITEM FOUND TO MOVE'
	IF (@selectfromCount > 1) SET @errCustomMessage = 'MULTIPLE ITEMS FOUND TO MOVE WHICH SHOULD NOT BE POSSIBLE!!!'

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
			 '  @fromItemId - ', @fromItemId,
			 '  @toItemId - ', @toItemId,
			 '  @selectFromCount - ', @selectFromCount,
			 '  @selectToCount - ', @selectToCount, 
			 '  @updateFromItemTempCount  - ', @updateFromItemTempCount ,
			 '  @updateToItemCount  - ', @updateToItemCount ,
			 '  @updateFromItemCount - ', @updateFromItemCount,
			 '  @moveItemLocation  - ', @moveItemLocation,
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
		 '  @fromItemId - ', @fromItemId,
		 '  @toItemId - ', @toItemId,
		 '  @selectFromCount - ', @selectFromCount,
		 '  @selectToCount - ', @selectToCount, 
		 '  @updateFromItemTempCount  - ', @updateFromItemTempCount ,
		 '  @updateToItemCount  - ', @updateToItemCount ,
		 '  @updateFromItemCount - ', @updateFromItemCount,
		 '  @moveItemLocation  - ', @moveItemLocation,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
 END CATCH

GO

