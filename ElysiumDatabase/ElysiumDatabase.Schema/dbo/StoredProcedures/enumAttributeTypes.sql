
CREATE PROCEDURE [dbo].[enumAttributeTypes]
	
AS
BEGIN TRY

	SELECT statId,stat
	FROM [content].[stats]
	WHERE statTypeId IN (1,2)
	ORDER BY statId

	
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

