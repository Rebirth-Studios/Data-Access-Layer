CREATE PROCEDURE [dbo].[enumMainHandWeaponTypes]
	
AS
BEGIN TRY

	
	SELECT typeId, type
	FROM weaponsMainHandWeaponTypes
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

