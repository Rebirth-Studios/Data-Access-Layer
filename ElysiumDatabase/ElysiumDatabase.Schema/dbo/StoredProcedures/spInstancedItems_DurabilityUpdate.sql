



-- =============================================
-- Author: Eric Ingram
-- Create date: 02/06/2022
-- Updated: 02/27/2022 - Added @batchRowId
-- Description: Update durability for instanced items
-- =============================================

CREATE procedure [dbo].[spInstancedItems_DurabilityUpdate]
	@instancedItemId uniqueidentifier output,
	@durabilityPercentage decimal(18,2),
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
	@insertBatchProcessingCount tinyint,
	@updateDurabilityCount tinyint
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @instancedItemId - ', @instancedItemId, 
		 '  @durabilityPercentage - ', @durabilityPercentage, 
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)
	
	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount
	
	--UPDATE Durability
	UPDATE [runtime].[instancedItems]
	SET durabilityPercentage = @durabilityPercentage, lastUpdate = GETDATE()
	WHERE instancedItemId = @instancedItemId
	SET @updateDurabilityCount = @@rowcount
	
	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@updateDurabilityCount = 0) SET @errCustomMessage = 'NO UPDATE MADE'
	IF (@updateDurabilityCount > 1) SET @errCustomMessage = 'MULTIPLE UPDATES MADE WHICH SHOULD NOT BE POSSIBLE!!!'

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
		 '  @updateDurability - ', @updateDurabilityCount,
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
		 '  @updateDurability - ', @updateDurabilityCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
 END CATCH

GO

