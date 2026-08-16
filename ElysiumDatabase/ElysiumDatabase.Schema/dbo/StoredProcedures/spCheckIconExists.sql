


CREATE PROCEDURE [dbo].[spCheckIconExists]
	@globalObject VARCHAR(255),
	@rarityId TINYINT
AS

BEGIN
	BEGIN TRY
		
		DECLARE @Number INT
		
		SELECT @Number = Count(globalObject)
		FROM [content].[Icons]
		WHERE globalObject = @globalObject AND rarityId = @rarityId
		
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

