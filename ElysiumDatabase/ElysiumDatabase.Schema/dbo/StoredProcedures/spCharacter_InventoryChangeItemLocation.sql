
-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables
-- Description: Can be used to change location of item in inventory
-- =============================================
CREATE procedure [dbo].[spCharacter_InventoryChangeItemLocation] (
    @spawnedWorldObjectId uniqueIdentifier,
	@instancedItemId uniqueIdentifier,
	@locationInsideBag tinyint,
	@logging bit,
	@batchRowId tinyint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
) AS
DECLARE
	@insertBatchProcessingCount tinyint,
	@updateCharactersInventoryCount tinyint
BEGIN TRY 
	SET @errParameters =  CONCAT('@spawnedWorldObjectId - ', @spawnedWorldObjectId, 
	 '  @instancedItemId - ', @instancedItemId, 
	 '  @locationInsideBag - ', @locationInsideBag,
	 '  @logging - ', @logging,
	 '  @batchRowId - ', @batchRowId)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount
	
	UPDATE [runtime].[spawnedWorldObjectsInventory] Set locationInsideBag = @locationInsideBag, lastUpdate = GETDATE() Where instancedItemId = @instancedItemId and spawnedWorldObjectId =  @spawnedWorldObjectId 
	SET @updateCharactersInventoryCount = @@rowcount

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@updateCharactersInventoryCount = 0) SET @errCustomMessage = 'NOTHING INSERTED IN CHARACTERS INVENTORY TABLE'

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
		 '  @insertBatchProcessingCount- ', @insertBatchProcessingCount, 
		 '  @updateCharactersInventoryCount - ', @updateCharactersInventoryCount));
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
		 '  @insertBatchProcessingCount- ', @insertBatchProcessingCount, 
		 '  @updateCharactersInventoryCount - ', @updateCharactersInventoryCount));
 END CATCH

GO

