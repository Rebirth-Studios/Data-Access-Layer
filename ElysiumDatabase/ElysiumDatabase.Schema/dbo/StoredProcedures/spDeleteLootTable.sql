CREATE PROCEDURE [dbo].[spDeleteLootTable]
	@globalObject VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
		--1
		DELETE FROM [content].[scriptableLootTableRarities]
		WHERE globalObject = @globalObject

		--2
		DELETE FROM [content].[scriptableLootTableQuantities]
		WHERE globalObject = @globalObject

		--3
		DELETE FROM [content].[scriptableLootTableDrops]
		WHERE globalObject = @globalObject

		--4
		DELETE FROM [content].[scriptableLootTablesToLootTable]
		WHERE globalObject = @globalObject

		--5
		DELETE FROM [content].[scriptableLootTables]
		WHERE globalObject = @globalObject

		--6
		DELETE FROM [content].[scriptableObjects]
		WHERE globalObject = @globalObject

		--7
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

