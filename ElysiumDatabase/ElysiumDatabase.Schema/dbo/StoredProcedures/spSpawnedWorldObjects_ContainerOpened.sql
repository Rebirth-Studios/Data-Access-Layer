



-- =============================================
-- Author: Eric Ingram
-- Create date: 03/07/2022
-- Updated MM/DD/YYYY: 
-- 
-- Description: Used to set OpenedBefore to 1 (True)
-- =============================================
CREATE PROCEDURE [dbo].[spSpawnedWorldObjects_ContainerOpened]
	@spawnedWorldObjectId uniqueIdentifier,
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
	@insertBatchProcessingCount bit,
	@updatedSpawnedContainerCount tinyint
BEGIN TRY
	--Add parameters passed by C# for logging
		SET @errParameters =   CONCAT_WS(',','@spawnedWorldObjectId - ', @spawnedWorldObjectId,
		'  @logging - ',@logging,
		'  @batchRowId - ',@batchRowId)

		--SET Stored Procedure Name
	--SET @storedProcedureName = 'spSpawnedWorldObjects_ContainerDelete'
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

		--ADD TO HISTORY TABLE
		

	--
	UPDATE [runtime].[spawnedContainers] SET openedBefore = 1
	WHERE spawnedWorldObjectId = @spawnedWorldObjectId
	SET @updatedSpawnedContainerCount = @@rowcount
			
	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@updatedSpawnedContainerCount = 0) SET @errCustomMessage = 'NO CONTAINER SET TO OPEN'


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
			 '  @updatedSpawnedContainerCount - ',@updatedSpawnedContainerCount));
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
			 '  @updatedSpawnedContainerCount - ',@updatedSpawnedContainerCount));
 END CATCH

GO

