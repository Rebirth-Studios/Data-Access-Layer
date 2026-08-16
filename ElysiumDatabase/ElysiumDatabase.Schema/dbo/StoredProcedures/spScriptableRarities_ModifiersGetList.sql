CREATE PROCEDURE [dbo].[spScriptableRarities_ModifiersGetList]

AS
BEGIN TRY
    SET NOCOUNT ON;
    Select rarityId, modifierTypeId, modifierMultiplier
    FROM [content].[scriptableRarityModifiers] srM
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

