





-- =============================================
-- Author: Eric Ingram
-- Create date: 02/12/2022
-- Updated: 02/27/2022 - Added @batchRowId
-- Description: Must be called once for each attachment. Send Attachments with Mail, but must be sent after spCharacter_SendMail
--				@charactersMailId must match the Id for the mail sent, @instancedItemId must be from an existing item on instancedItems table
-- =============================================
CREATE procedure [dbo].[spCharacter_MailSendAttachments]
    @charactersMailId uniqueIdentifier,
	@instancedItemId uniqueIdentifier,
	@slotIndex tinyint,
	@sentDateTime datetime,
	@logging bit,
	@batchRowId smallint,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output

AS 

DECLARE 
	@insertBatchProcessingCount tinyint,
	@insertMailAttachment int
BEGIN TRY 
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @charactersMailId - ', @charactersMailId, 
		 '  @instancedItemId - ', @instancedItemId,
		 '  @@sentDateTime - ', @sentDateTime,
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	insert into [runtime].[charactersMailAttachments](charactersMailId, instancedItemId, slotIndex, sentDateTime)
	VALUES (@charactersMailId, @instancedItemId, @slotIndex, @sentDateTime)  
	SET @insertMailAttachment = @@rowcount


	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@insertMailAttachment = 0) SET @errCustomMessage = 'NO INSERT MADE'
	IF (@insertMailAttachment > 1) SET @errCustomMessage = 'MULTIPLE INSERTS MADE WHICH SHOULD NOT BE POSSIBLE!!!'

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
		 '  @insertMail - ', @insertMailAttachment,
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
		 '  @insertMail - ', @insertMailAttachment,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));
 END CATCH

GO

