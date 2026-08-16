


CREATE PROCEDURE [dbo].[spCheckEffectGroupExists]
	@globalObject VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		
		DECLARE @Number INT
		
		SELECT @Number = Count(effectGroupGlobalObject)
		FROM [content].[effectGroups]
		WHERE effectGroupGlobalObject = @globalObject
		
		RETURN @Number
		-- Commit the transaction if everything succeeds
        
	END TRY

	BEGIN CATCH
		-- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH


END

GO

