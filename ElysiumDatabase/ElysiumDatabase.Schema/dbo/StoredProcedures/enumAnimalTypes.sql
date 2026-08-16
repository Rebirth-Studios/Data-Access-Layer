
CREATE PROCEDURE [dbo].[enumAnimalTypes]
	
AS
BEGIN TRY

	SELECT aT.typeId, aT.type
	FROM [content].[animalTypes] aT
	ORDER BY typeId

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

