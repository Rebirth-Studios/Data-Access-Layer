



CREATE PROCEDURE [dbo].[spDeleteRecipe]
	@globalObject VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
		DELETE FROM [content].[associatedGlobalObjects]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableRecipeIngredients]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[Icons]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableRequirements]
		WHERE globalObject = @globalObject
		
		DELETE FROM [content].[scriptableRecipes]
		WHERE globalObject = @globalObject


		DELETE FROM [content].[scriptableObjects]
		WHERE globalObject = @globalObject

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

        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH


END

GO

