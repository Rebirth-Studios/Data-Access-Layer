-- =============================================
-- Author: Eric Ingram
-- Create date: 02/12/2022
-- Updated MM/DD/YYYY: 
-- Description: Gives all items for a single mail Id where takenByPlayerDate is Null
--				
-- =============================================

CREATE PROCEDURE [dbo].[spCharacter_MailAttachmentsGetAll]
AS

BEGIN 
	
	Select cMA.instancedItemId, cMA.charactersMailId, cMA.slotIndex, cMA.takenbyPlayerDateTime, iI.itemTypeId
	FROM [runtime].[charactersMailAttachments] cMA
	JOIN [runtime].[instancedItems] iI ON iI.instancedItemId = cMA.instancedItemId


	



END

GO

