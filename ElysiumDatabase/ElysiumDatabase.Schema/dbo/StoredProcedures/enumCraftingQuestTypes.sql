CREATE PROCEDURE [dbo].[enumCraftingQuestTypes]
	
AS
BEGIN TRY

	SELECT craftingQuestTypeId, craftingQuestType
	FROM [content].[craftingQuestTypes]
	ORDER BY craftingQuestTypeId
	

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
   'N/A');

 END CATCH

GO

