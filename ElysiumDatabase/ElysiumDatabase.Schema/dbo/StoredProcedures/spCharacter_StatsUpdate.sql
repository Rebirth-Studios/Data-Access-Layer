-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/27/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Updated to get spawnedWorldObjectId from character table
-- Description: Update [content].[stats] for character
-- =============================================
CREATE PROCEDURE [dbo].[spCharacter_StatsUpdate]
	@spawnedWorldObjectId uniqueIdentifier,
	@statTypeId int,
    @statId int,
	@characterStatValue float,
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
    @errParameters varchar(MAX) output,
    @errCustomMessage varchar(1000) output
AS
DECLARE
	@insertBatchProcessingCount tinyint,
	@updateStatCount tinyint,
	@characterId int
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		 '  @statTypeId - ', @statTypeId, 
		 '  @statId - ',@statId,
		 '  @characterStatValue - ',@characterStatValue,
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	--GET CHARACTER ID
	SELECT @characterId = characterId
	FROM [runtime].[characters] ch
	JOIN [runtime].[spawnedWorldObjects] sWO ON ch.spawnedWorldObjectId = sWO.spawnedWorldObjectId
	WHERE ch.spawnedWorldObjectId = @spawnedWorldObjectId

	UPDATE [runtime].[charactersStats] SET characterStatValue = @characterStatValue 
	Where characterStatTypeId = @statTypeId And statId = @statId And characterId = @characterId
	SET @updateStatCount = @@rowcount

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@updateStatCount = 0) SET @errCustomMessage = 'NO UPDATE MADE'
	IF (@updateStatCount > 1) SET @errCustomMessage = 'MULTIPLE UPDATES MADE WHICH SHOULD NOT BE POSSIBLE!!!'

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
		 '  @@updateStatCount - ', @updateStatCount,
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
		 '  @@updateStatCount - ', @updateStatCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
END CATCH

GO

