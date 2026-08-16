-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/13/2021 - Updated error handling
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Renamed characterBags to spawnedWorldObjectsBags
-- Description: Instances bag items
-- =============================================
CREATE procedure [dbo].[spCharacter_BagAddGuid]
    @spawnedWorldObjectId uniqueIdentifier,
	@instancedItemId uniqueIdentifier,
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
	@insertCharacterBags int
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters = CONCAT_WS(',','@spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		'  @instancedItemId - ', @instancedItemId, 
		'  @bagLocationId - ', @bagLocationId,
		'  @logging - ', @logging)

	--SET Stored Procedure Name
	--SET @storedProcedureName = 'spCharacter_BagAddGuid'
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	insert into [runtime].[spawnedWorldObjectsBags](spawnedWorldObjectId, instancedItemId, bagLocationId, lastUpdate)
	VALUES (@spawnedWorldObjectId, @instancedItemId, @bagLocationId, GETDATE())
	SET @insertCharacterBags = @@rowcount

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@insertCharacterBags = 0) SET @errCustomMessage = 'NOTHING INSERTED INTO CHARACTER BAGS TABLE'

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
		'  @insertBatchProcessingCount - ', @insertCharacterBags,
		'  @insertCharacterBags - ', @insertCharacterBags))
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
		'  @insertBatchProcessingCount - ', @insertCharacterBags,
		'  @insertCharacterBags - ', @insertCharacterBags))
END CATCH

GO

