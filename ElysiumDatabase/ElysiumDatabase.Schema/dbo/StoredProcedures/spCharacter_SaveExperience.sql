





-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/27/2022 - Added @batchRowId
-- Description: Save character location
-- =============================================
CREATE procedure [dbo].[spCharacter_SaveExperience]
	@spawnedWorldObjectId uniqueIdentifier,
	@characterExperience int,
	@characterTierId int,
	@characterRankId int,
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS 
DECLARE
	@insertBatchProcessingCount tinyint,
	@updateExperienceCount tinyint
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		 '  @characterExperience - ', @characterExperience, 
		 '  @characterTierId - ', @characterTierId, 
		 '  @characterRankId - ', @characterRankId, 
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount


			--Character Experience, Tier, Rank
			Update [runtime].[characters] SET 
			characterExperience = @characterExperience, 
			characterTierId = @characterTierId, 
			characterRankId = @characterRankId, 
			lastUpdated = GETDATE()
			WHERE spawnedWorldObjectId = @spawnedWorldObjectId
			SET @updateExperienceCount = @@rowcount


	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@updateExperienceCount = 0) SET @errCustomMessage = 'NO UPDATE MADE'
	IF (@updateExperienceCount > 1) SET @errCustomMessage = 'MULTIPLE UPDATES MADE WHICH SHOULD NOT BE POSSIBLE!!!'

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
		 '  @updateExperienceCount - ', @updateExperienceCount,
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
		 '  @updateExperienceCount - ', @updateExperienceCount,
		  '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
 END CATCH

GO

