



CREATE PROCEDURE [dbo].[spDeleteEffect]
	@globalObject VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
		DELETE FROM [content].[effectsToEffectGroupsMapping]
		WHERE effectGlobalObject = @globalObject

		DELETE FROM [content].[awardEffects]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[experienceEffects]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[unlockEffects]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[statEffects]
		WHERE statEffectGlobalObject = @globalObject

		--17
		DELETE FROM [content].[effects]
		WHERE globalObject = @globalObject

		--18
		DELETE FROM [content].[globalObjects]
		WHERE globalObject = @globalObject

		-- Commit the transaction if everything succeeds
        COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		-- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        -- Optionally, rethrow the error
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END

GO

