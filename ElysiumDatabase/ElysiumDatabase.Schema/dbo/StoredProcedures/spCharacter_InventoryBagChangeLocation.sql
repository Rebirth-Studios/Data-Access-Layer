-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 02/27/2022 - Updated to support @characterBagId changing from uniqueIdentifier to int
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables
-- Description: Used to change location of equipped bag
-- =============================================
CREATE procedure [dbo].[spCharacter_InventoryBagChangeLocation] (
    @spawnedWorldObjectId uniqueIdentifier,
	@fromBagIndex tinyint, --Which location the bag is in 0 - 4
	@toBagIndex tinyint, --Which location the bag is in 0 - 4
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
) AS
DECLARE
	--@storedProcedureName varchar(255),
	@insertBatchProcessingCount bit,
	@fromBagId int,
	@toBagId int,
	@selectFromCount int,
	@selectToCount int,
	@updateTempCount int,
	@updateFromCount int,
	@updateToCount int,
	@moveBagLocationIndex int
BEGIN TRY
	

	SET @moveBagLocationIndex = 99 -- Used to move bag temp out of index 

	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','@spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		 '  @fromBagIndex - ', @fromBagIndex, 
		 '  @toBagIndex - ', @toBagIndex, 
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount




	--FIND FROM_BAG
	SELECT @fromBagId = characterBagId
	FROM [runtime].[spawnedWorldObjectsBags]
	WHERE spawnedWorldObjectId = @spawnedWorldObjectId AND bagLocationId = @fromBagIndex
	SET @selectFromCount = @@rowcount

	--FIND TO_BAG
	SELECT @toBagId = characterBagId
	FROM [runtime].[spawnedWorldObjectsBags]
	WHERE spawnedWorldObjectId = @spawnedWorldObjectId AND bagLocationId = @toBagIndex
	SET @selectToCount = @@rowcount

	--IF BAG EXISTS IN INDEX TO MOVE BAG TO
	IF @selectToCount = 1	
	BEGIN
		--MOVE TO_BAG TO TEMP_INDEX
		UPDATE [runtime].[spawnedWorldObjectsBags] Set bagLocationId = @moveBagLocationIndex WHERE characterBagId = @toBagId
		SET @updateTempCount = @@rowcount

		--MOVE FROM_BAG TO TO_INDEX
		UPDATE [runtime].[spawnedWorldObjectsBags] Set bagLocationId = @toBagIndex WHERE characterBagId = @fromBagId
		SET @updateFromCount = @@rowcount

		--MOVE TO_BAG TO FROM_INDEX
		UPDATE [runtime].[spawnedWorldObjectsBags] Set bagLocationId = @fromBagIndex WHERE characterBagId = @toBagId
		SET @updateToCount = @@rowcount
	END

	--IF BAG DOES NOT EXISTS IN INDEX TO MOVE BAG TO, AKA MOVING BAG TO EMPTY BAG INDEX
	IF @selectToCount = 0	
	BEGIN
		--MOVE FROM_BAG TO TO_INDEX
		UPDATE [runtime].[spawnedWorldObjectsBags] Set bagLocationId = @toBagIndex WHERE characterBagId = @fromBagId
		SET @updateFromCount = @@rowcount
    END


	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	--IF (@updateCharactersInventoryCount = 0) SET @errCustomMessage = 'NOTHING INSERTED IN CHARACTERS INVENTORY TABLE'

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
		 '  @fromBagId- ', @fromBagId, 
		 '  @toBagId- ', @toBagId, 
		 '  @selectFromCount - ', @selectFromCount,
		 '  @selectToCount - ', @selectToCount, 
		 '  @updateTempCount - ', @updateTempCount,
		 '  @updateFromCount - ', @updateFromCount,
		 '  @updateToCount - ', @updateToCount,
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
		 '  @fromBagId- ', @fromBagId, 
		 '  @toBagId- ', @toBagId, 
		 '  @selectFromCount - ', @selectFromCount,
		 '  @selectToCount - ', @selectToCount, 
		 '  @updateTempCount - ', @updateTempCount,
		 '  @updateFromCount - ', @updateFromCount,
		 '  @updateToCount - ', @updateToCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
END CATCH

GO

