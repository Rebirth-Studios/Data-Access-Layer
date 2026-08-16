


CREATE PROCEDURE [dbo].[spAddEffectUnlock]
	@globalObjectCode VARCHAR(255),
	@globalObject VARCHAR(255),
	@globalObjectName VARCHAR(255),
	@globalObjectSkill VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
		--1
		INSERT INTO [content].[globalObjects] VALUES (@globalObjectCode, @globalObject, @globalObjectName, @globalObjectName, 4, 4, 0, 1, 2, 0, 0, 0)
		
		INSERT INTO [content].[effects] VALUES (@globalObject, 2)
		
		INSERT INTO [content].[unlockEffects] VALUES (@globalObject, @globalObjectSkill, 2, 0, 1, 0)

		-- Commit the transaction if everything succeeds
        COMMIT TRANSACTION;
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

