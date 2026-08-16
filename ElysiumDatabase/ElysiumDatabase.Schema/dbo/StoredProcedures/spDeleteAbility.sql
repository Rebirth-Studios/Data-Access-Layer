

CREATE PROCEDURE [dbo].[spDeleteAbility]
	@globalObject VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
		DELETE FROM [content].[Icons]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[effectGroupsToObjectsMapping]
		WHERE abilityGlobalObject = @globalObject

		DELETE FROM [content].[scriptableAbilitiesLevelsActivationCosts]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableAbilitiesLevels]
		WHERE globalObject = @globalObject

		--1
		DELETE FROM [content].[abilityLevelsToObjectSpawnablesMapping]
		WHERE abilityGlobalObject = @globalObject
		
		DELETE FROM [content].[scriptableAbilities]
		WHERE globalObject = @globalObject

		--2
		DELETE FROM [content].[scriptableObjectLevels]
		WHERE globalObject = @globalObject

		--3
		DELETE FROM [content].[associatedGlobalObjects]
		WHERE globalObject = @globalObject

		--12
		DELETE FROM [content].[scriptableObjectLevels]
		WHERE globalObject = @globalObject

		--17
		DELETE FROM [content].[scriptableObjects]
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

