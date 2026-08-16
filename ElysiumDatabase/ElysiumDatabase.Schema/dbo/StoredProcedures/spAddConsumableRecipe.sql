


CREATE PROCEDURE [dbo].[spAddConsumableRecipe]
	@globalObjectCode VARCHAR(255),
	@globalObject VARCHAR(255),
	@globalObjectName VARCHAR(255),
	@globalObjectEffect VARCHAR(255),
	@description VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		--1
		INSERT INTO [content].[globalObjects] VALUES (@globalObjectCode, @globalObject, @globalObjectName, @globalObjectName, 7, 12, 17, 1, 2, 0, 0, 0)
		
		INSERT INTO [content].[scriptableObjects] VALUES (@globalObject, 17)
		
		INSERT INTO [content].[scriptableItems] VALUES (@globalObject, 3, 1.00, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, @description, 0)

		INSERT INTO [content].[Icons] VALUES (1, @globalObject, 'books/129_t')

		INSERT INTO [content].[prefabs] VALUES (@globalObject, 'Ingredients & Decoration/Book_Closed_01')

		INSERT INTO [content].[scriptableItemRarities] VALUES (@globalObject, 1, @description)

		INSERT INTO [content].[scriptableItemEffects] VALUES (@globalObject, 1, @globalObjectEffect, @description, 1)

		INSERT INTO [content].[scriptableRequirements] VALUES (@globalObject, 'none', 15, 0, 0, 0, 0)

		INSERT INTO [content].[scriptableConsumables] VALUES (@globalObject, 2, 8, 0, @description)


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

