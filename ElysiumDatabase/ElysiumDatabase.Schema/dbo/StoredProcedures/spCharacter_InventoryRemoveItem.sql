-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables
-- Description: Can be used to move items
-- =============================================
CREATE procedure [dbo].[spCharacter_InventoryRemoveItem]
    @spawnedWorldObjectId uniqueIdentifier,
	@instancedItemId uniqueIdentifier,
	@logging bit,
	@batchRowId tinyint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
	@storedProcedureName varchar(255),
	@insertBatchProcessingCount bit,
	@deleteCharactersInventoryCount bit
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','@spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		 '  @instancedItemId - ', @instancedItemId, 
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)
	
	--SET Stored Procedure Name
	SET @storedProcedureName = 'spCharacter_InventoryRemoveItem'
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@storedProcedureName,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount


	DELETE FROM [runtime].[spawnedWorldObjectsInventory] Where instancedItemId = @instancedItemId and spawnedWorldObjectId = @spawnedWorldObjectId
	SET @deleteCharactersInventoryCount = @@rowcount

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@deleteCharactersInventoryCount = 0) SET @errCustomMessage = 'NO ITEM FOUND TO MOVE'
	IF (@deleteCharactersInventoryCount > 1) SET @errCustomMessage = 'MULTIPLE ITEMS FOUND TO MOVE WHICH SHOULD NOT BE POSSIBLE!!!'


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
			@storedProcedureName,
			@errCustomMessage,
			GETDATE(),
			CONCAT_WS(',','  @errParameters - ', @errParameters, 
			 '  @deleteCharactersInventoryCount - ', @deleteCharactersInventoryCount,
			 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
		END
	END TRY

BEGIN CATCH
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
			 '  @deleteCharactersInventoryCount - ', @deleteCharactersInventoryCount,
			 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
 END CATCH

GO

