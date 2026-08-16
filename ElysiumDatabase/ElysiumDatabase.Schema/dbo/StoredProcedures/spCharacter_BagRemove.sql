





/****** Object:  StoredProcedure [dbo].[spCharacter_CreateNew]    Script Date: 7/14/21 22:21:02 ******/

-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Renamed characterBags to spawnedWorldObjectsBags, changed @characterBagId to Int
-- Description: Instances bag items
-- =============================================
CREATE procedure [dbo].[spCharacter_BagRemove]
    @spawnedWorldObjectId uniqueIdentifier,
	@bagLocationId tinyint,
	@logging bit,
	@batchRowId int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
	--@storedProcedureName varchar(255),
	@insertBatchProcessingCount tinyint,
	@deleteBagCount tinyint
BEGIN TRY	
	--Add parameters passed by C# for logging
	SET @errMessage = ERROR_MESSAGE()
	SET @errParameters = CONCAT_WS(',','@spawnedWorldObjectId - ', @spawnedWorldObjectId, 
	 '  @bagLocationId - ', @bagLocationId,
	 '  @logging - ', @logging)

	--SET Stored Procedure Name
	--SET @storedProcedureName = 'spCharacter_BagRemove'
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	DELETE FROM [runtime].[spawnedWorldObjectsBags] Where bagLocationId = @bagLocationId and spawnedWorldObjectId = @spawnedWorldObjectId
	SET @deleteBagCount = @@rowcount

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@deleteBagCount = 0) SET @errCustomMessage = 'NO BAGS DELETED'

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
		'  @insertBatchProcessingCount - ', @insertBatchProcessingCount,
		'  @deleteBagCount - ', @deleteBagCount));
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
		'  @insertBatchProcessingCount - ', @insertBatchProcessingCount,
		'  @deleteBagCount - ', @deleteBagCount));
 END CATCH

GO

