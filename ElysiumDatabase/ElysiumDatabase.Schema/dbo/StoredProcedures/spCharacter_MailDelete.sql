





-- =============================================
-- Author: Eric Ingram
-- Create date: 02/12/2022
-- Updated: 02/27/2022 - Added @batchRowId
-- Description: Set deletedbyPlayerDateTime to current datetime if player clicks delete button on UI. Will be excluded from results from spCharacter_MailGetAll		
-- =============================================
CREATE procedure [dbo].[spCharacter_MailDelete]
    @charactersMailId uniqueIdentifier,
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS 
DECLARE 
	@insertBatchProcessingCount tinyint,
	@updateMail int
BEGIN TRY 
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @charactersMailId - ', @charactersMailId, 
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	UPDATE [runtime].[charactersMail]
	SET deletedbyPlayerDateTime = GETDATE()
	WHERE charactersMailId = @charactersMailId
	SET @updateMail = @@rowcount
	
	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@updateMail = 0) SET @errCustomMessage = 'NO INSERT MADE'
	IF (@updateMail > 1) SET @errCustomMessage = 'MULTIPLE INSERTS MADE WHICH SHOULD NOT BE POSSIBLE!!!'

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
		 '  @updateMail - ', @updateMail,
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
		 '  @updateMail - ', @updateMail,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
 END CATCH

GO

