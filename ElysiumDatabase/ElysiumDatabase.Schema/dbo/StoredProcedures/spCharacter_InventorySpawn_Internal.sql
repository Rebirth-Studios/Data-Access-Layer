

-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables and changed @bagId to int
-- Description: Can be used to move items
-- =============================================
CREATE procedure [dbo].[spCharacter_InventorySpawn_Internal]
	@bagId int,
	@bagSlotId int,
	@itemId uniqueIdentifier,
	@logging bit,
	@batchRowId tinyint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
	@storedProcedureName varchar(255),
	@insertBatchProcessingCount bit,
	@characterId uniqueIdentifier,
	@selectCount int,
	@insertCount int
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @bagId - ', @bagId, 
		 '  @bagSlotId - ', @bagSlotId,
		 '  @itemId - ', @itemId,
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--SET Stored Procedure Name
	SET @storedProcedureName = 'spCharacter_InventorySpawn'
	--INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@storedProcedureName,GETDATE())
	--SET @insertBatchProcessingCount = @@rowcount

	--FIND ITEM
	SELECT @characterId = spawnedWorldObjectId 
	FROM [runtime].[spawnedWorldObjectsBags]
	WHERE characterBagId = @bagId
	SET @selectCount = @@rowcount

	IF (@characterId IS NOT NULL) AND (@selectCount = 1)
	BEGIN
		--INSERT Character Inventory
		insert into [runtime].[spawnedWorldObjectsInventory](spawnedWorldObjectId, instancedItemId, characterBagId, locationInsideBag, lastUpdate)
		VALUES (@characterId, @itemId, @bagId, @bagSlotId, GETDATE())  
		SET @insertCount = @@rowcount
	END

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@insertCount = 0) SET @errCustomMessage = 'NO ITEM FOUND'
	IF (@insertCount > 1) SET @errCustomMessage = 'MULTIPLE ITEMS FOUND WHICH SHOULD NOT BE POSSIBLE!!!'


	--IF CUSTOM ERROR MESSAGE SET OR LOGGING ENABLED
	IF (@characterId IS NULL) OR (@selectCount <> 1) OR (@logging = 1)
	BEGIN
		INSERT INTO [ops].[DB_Errors]
		VALUES
		(SUSER_SNAME(),
		0,
		0,
		0,
		0,
		@storedProcedureName,
		@errCustomMessage,
		GETDATE(),
		CONCAT_WS(',','  @errParameters - ', @errParameters, 
		 '  @characterId- ', @characterId, 
		 '  @selectCount - ', @selectCount, 
		 '  @insertCount  - ', @insertCount,
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
		 '  @characterId- ', @characterId, 
		 '  @selectCount - ', @selectCount, 
		 '  @insertCount  - ', @insertCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
 END CATCH

GO

