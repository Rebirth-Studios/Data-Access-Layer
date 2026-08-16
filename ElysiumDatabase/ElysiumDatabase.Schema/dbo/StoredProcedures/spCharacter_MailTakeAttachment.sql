





-- =============================================
-- Author: Eric Ingram
-- Create date: 02/12/2022
-- Updated: 02/27/2022 - Added @batchRowId
-- Description: Called to 'remove' a single item (attachment) from a mail Id. Sets takenByPlayerDateTime = NOW		
-- =============================================
CREATE procedure [dbo].[spCharacter_MailTakeAttachment]
    @charactersMailId uniqueIdentifier,
	@slotIndex tinyInt,
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS 
DECLARE 
	@insertBatchProcessingCount tinyint,
	@updateMailAttachment int
BEGIN TRY 
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @charactersMailId - ', @charactersMailId, 
		 '  @slotIndex - ', @slotIndex,
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	UPDATE [runtime].[charactersMailAttachments]
	SET takenbyPlayerDateTime = GETDATE()
	WHERE charactersMailId = @charactersMailId AND @slotIndex = slotIndex
	SET @updateMailAttachment = @@rowcount
	
	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@updateMailAttachment = 0) SET @errCustomMessage = 'NO INSERT MADE'
	IF (@updateMailAttachment > 1) SET @errCustomMessage = 'MULTIPLE INSERTS MADE WHICH SHOULD NOT BE POSSIBLE!!!'

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
		 '  @updateMailAttachment - ', @updateMailAttachment,
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
		 '  @updateMailAttachment - ', @updateMailAttachment,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
 END CATCH

GO

