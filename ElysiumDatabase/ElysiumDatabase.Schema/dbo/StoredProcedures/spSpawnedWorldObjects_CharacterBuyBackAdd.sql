

-- =============================================
-- Author: Eric Ingram
-- Create date: 03/10/2022
-- Update: MM/DD/YYYY
-- Description: Used to buy item from buyback table (previously sold to vendor)
-- =============================================

CREATE procedure [dbo].[spSpawnedWorldObjects_CharacterBuyBackAdd]
    @spawnedWorldObjectId uniqueIdentifier,
	@instancedItemId uniqueIdentifier,
	@bagSlotId tinyint,
	@itemLocationInsideBag tinyint,
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
	@insertBatchProcessingCount tinyint,
	@characterBagId int,
	@selectCharacterBagIdCount tinyint,
	@deleteBuyBackItemCount tinyint,
	@insertBuyBackItemCount tinyint
BEGIN TRY
	

	SET @errParameters =  CONCAT_WS(',','@spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		 '  @instancedItemId - ', @instancedItemId,
		 --'  @bagSlotId - ', @bagSlotId,
		 --'  @itemLocationInsideBag - ', @itemLocationInsideBag,
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount


	--RETRIEVE Character Bag Id
	SELECT @characterBagId = characterBagId
	FROM [runtime].[spawnedWorldObjectsBags]
	WHERE spawnedWorldObjectId = @spawnedWorldObjectId AND bagLocationId = @bagSlotId
	SET @selectCharacterBagIdCount = @@rowcount


	BEGIN
		--DELETE ITEM FROM BUY BACK TABLE
			DELETE
			FROM spawnedWorldObjectsBuyBacks
			WHERE spawnedWorldObjectId = @spawnedWorldObjectId AND instancedItemId = @instancedItemId
			SET @deleteBuyBackItemCount = @@rowcount
	END

	IF @deleteBuyBackItemCount = 1
		BEGIN
			--INSERT Character Inventory
			insert into [runtime].[spawnedWorldObjectsInventory](spawnedWorldObjectId, instancedItemId, characterBagId, locationInsideBag, lastUpdate)
			VALUES (@spawnedWorldObjectId, @instancedItemId, @characterBagId, @bagSlotId, GETDATE())  
			SET @insertBuyBackItemCount = @@rowcount
		END
		
	

	
	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@insertBuyBackItemCount = 0) SET @errCustomMessage = 'BUY BACK ITEM WAS NOT INSERTED INTO [runtime].[characters] INVENTORY / BAG'
	IF (@deleteBuyBackItemCount = 0) SET @errCustomMessage = 'BUY BACK ITEM WAS NOT DELETED FROM BUY BACK TABLE'
	IF (@selectCharacterBagIdCount = 0) SET @errCustomMessage = 'BAG TO INSERT ITEM WAS NOT FOUND'

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
		 --'  @characterBagId- ', @characterBagId, 
		 '  @selectCharacterBagIdCount- ', @selectCharacterBagIdCount, 
		 --'  @soldItemId - ', @soldItemId,
		 --'  @selectSoldItem - ', @selectSoldItem, 
		 '  @deleteBuyBackItemCount - ', @deleteBuyBackItemCount,
		 '  @insertBuyBackItemCount - ', @insertBuyBackItemCount));
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
		 --'  @characterBagId- ', @characterBagId, 
		 '  @selectCharacterBagIdCount- ', @selectCharacterBagIdCount, 
		 --'  @soldItemId - ', @soldItemId,
		 --'  @selectSoldItem - ', @selectSoldItem, 
		 '  @deleteBuyBackItemCount - ', @deleteBuyBackItemCount,
		 '  @insertBuyBackItemCount - ', @insertBuyBackItemCount));
 END CATCH

GO

