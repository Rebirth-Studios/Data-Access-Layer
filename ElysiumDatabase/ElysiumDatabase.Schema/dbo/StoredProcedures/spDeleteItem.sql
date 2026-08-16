

CREATE PROCEDURE [dbo].[spDeleteItem]
	@globalObject VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
		--1
		DELETE FROM [content].[associatedGlobalObjects]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[prefabs]
		WHERE globalObject = @globalObject

		--2
		DELETE FROM [content].[Icons]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableRequirements]
		WHERE globalObject = @globalObject
		
		DELETE FROM [content].[scriptableAmmunition]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableBags]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableConsumables]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableGeneralItems]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableMaterials]
		WHERE globalObject = @globalObject

		--3
		DELETE FROM [content].[effectGroupsToItemsMapping]
		WHERE itemGlobalObject = @globalObject

		--4
		DELETE FROM [content].[scriptableItemEffects]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableItemRarities]
		WHERE globalObject = @globalObject

		--5
		DELETE FROM [content].[scriptableItems]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableObjectRarities]
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

