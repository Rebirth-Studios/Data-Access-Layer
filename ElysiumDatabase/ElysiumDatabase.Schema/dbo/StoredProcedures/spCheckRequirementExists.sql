


CREATE PROCEDURE [dbo].[spCheckRequirementExists]
	@globalObject VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		
		DECLARE @Number INT
		
		SELECT @Number = Count(requiredForGlobalObject)
		FROM [content].[scriptableRequirements]
		WHERE requiredForGlobalObject = @globalObject
		
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

