CREATE PROCEDURE [dbo].[spLastUpdatedTables_GetList]

AS
BEGIN TRY
    SET NOCOUNT ON;
    SELECT *
	FROM [ops].[lastUpdatedTables] lUT
	ORDER BY lUT.lastUpdatedTable
    RETURN 0
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

