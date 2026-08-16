
-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/12/2021 - Removed code to delete instanced items and replaced with stored proc spCharacter_InventoryDeleteAll
-- Updated: 02/26/2022 - Added @batchRowId
-- Description: Deletes spawned Interactable world object (spawnedWorldObjectId)
-- =============================================
CREATE PROCEDURE [dbo].[spSpawnedWorldObjects_InteractableDelete]
	@spawnedWorldObjectId uniqueIdentifier,
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
    @storedProcedureName varchar(255),
	@insertBatchProcessingCount bit,    
	@deleteSpawnedContainersCount int,
	@deleteSpawnedInteractablesCount int,
	@deleteSpawnedWorldObjectsCount int
BEGIN TRY
     --Add parameters passed by C# for logging
    SET @errParameters =   CONCAT_WS(',','@spawnedWorldObjectId - ', @spawnedWorldObjectId,
                                     '  @logging - ',@logging,
									 '  @batchRowId - ',@batchRowId)
	--SET Stored Procedure Name
	--SET @storedProcedureName = 'spSpawnedWorldObjects_InteractableDelete'
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount


    --ADD TO HISTORY TABLE


    EXEC spCharacter_InventoryDeleteAll_Internal @spawnedWorldObjectId, @logging


    --DELETE FROM SPAWNED TABLES
    DELETE FROM [runtime].[spawnedInteractables] WHERE spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteSpawnedInteractablesCount = @@rowcount
    DELETE FROM [runtime].[spawnedWorldObjects] WHERE spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteSpawnedWorldObjectsCount = @@rowcount


    --SET CUSTOM ERROR MESSAGE FOR DEBUGGING
    IF (@deleteSpawnedWorldObjectsCount = 0) SET @errCustomMessage = 'NO spawnedWorldObject deleted'


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
                           '  @deleteSpawnedContainersCount - ',@deleteSpawnedContainersCount,
                           '  @deleteSpawnedInteractablesCount - ',@deleteSpawnedInteractablesCount,
						   '  @insertBatchProcessingCount - ',@insertBatchProcessingCount,
                           '  @deleteSpawnedWorldObjectsCount - ',@deleteSpawnedWorldObjectsCount));
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
                           '  @deleteSpawnedContainersCount - ',@deleteSpawnedContainersCount,
                           '  @deleteSpawnedInteractablesCount - ',@deleteSpawnedInteractablesCount,
						   '  @insertBatchProcessingCount - ',@insertBatchProcessingCount,
                           '  @deleteSpawnedWorldObjectsCount - ',@deleteSpawnedWorldObjectsCount));
END CATCH

GO

