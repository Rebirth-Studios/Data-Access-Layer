
CREATE PROCEDURE [dbo].[enumConsumableSubTypes]
	
AS
BEGIN TRY

	SELECT typeId, type
	FROM [content].[consumableSubTypes] cST
	ORDER BY cST.typeId

	
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

