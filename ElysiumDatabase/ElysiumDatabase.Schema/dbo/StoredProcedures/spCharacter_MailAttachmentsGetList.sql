-- =============================================
-- Author: Eric Ingram
-- Create date: 02/12/2022
-- Updated MM/DD/YYYY: 
-- Description: Gives all items for a single mail Id where takenByPlayerDate is Null
--				
-- =============================================

CREATE PROCEDURE [dbo].[spCharacter_MailAttachmentsGetList]
	@charactersMailId uniqueIdentifier,
	@logging int = 0,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE 
@selectMailAttachments int

BEGIN TRY 
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @charactersMailId - ', @charactersMailId, 
		 '  @logging - ', @logging)

	
	Select cMA.instancedItemId
	FROM [runtime].[charactersMailAttachments] cMA
	WHERE cMA.charactersMailId = @charactersMailId AND takenbyPlayerDateTime IS NULL
	SET @selectMailAttachments = @@rowcount

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@selectMailAttachments = 0) SET @errCustomMessage = 'NO ATTACHMENTS FOUND'
	

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
		'spCharacter_MailAttachmentsGetAll',
		@errCustomMessage,
		GETDATE(),
		CONCAT_WS(',','  @errParameters - ', @errParameters, 
		 '  @selectMailAttachments - ', @selectMailAttachments));
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
		@errParameters);
 END CATCH

GO

