

CREATE PROCEDURE [dbo].[spDeleteVendor]
	@globalObject VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
		DELETE FROM [content].[dataAttributesToGlobalObjects]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableSpawnTableOptions]
		WHERE worldObjectGlobalObject = @globalObject

		DELETE FROM [content].[scriptableSpawnTables]
		WHERE baseSpawnableObjectGlobalObject = @globalObject

		--1
		DELETE FROM [content].[spawnablesToPrefabs]
		WHERE globalObject = @globalObject
		
		--2
		DELETE FROM [content].[bodyPartPaths]
		WHERE globalObject = @globalObject

		--3
		DELETE FROM [content].[associatedGlobalObjects]
		WHERE globalObject = @globalObject

		--4
		DELETE FROM [content].[scriptableEntitiesSpawnable]
		WHERE globalObject = @globalObject

		--5
		DELETE FROM [content].[abilityLevelsToObjectSpawnablesMapping]
		WHERE globalObject = @globalObject

		--6
		DELETE FROM [content].[Icons]
		WHERE globalObject = @globalObject

		--7
		DELETE FROM [content].[bodyPartMultipliers]
		WHERE globalObject = @globalObject

		--8
		DELETE FROM [content].[entityStats]
		WHERE globalObject = @globalObject

		--9
		DELETE FROM [content].[spawnablesToLootTables]
		WHERE globalObject = @globalObject

		--10
		DELETE FROM [content].[scriptableObjectSpawnables]
		WHERE globalObject = @globalObject

		--11
		DELETE FROM [content].[prefabs]
		WHERE globalObject = @globalObject

		--12
		DELETE FROM [content].[scriptableObjectLevels]
		WHERE globalObject = @globalObject

		--13
		DELETE FROM [content].[scriptableEntitiesAttacks]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableVendorItems]
		WHERE npcGlobalObject = @globalObject

		--14
		DELETE FROM [content].[scriptableVendors]
		WHERE globalObject = @globalObject

		DELETE FROM [content].[scriptableQuestGivers]
		WHERE globalObject = @globalObject


		DELETE FROM [content].[scriptableNPCS]
		WHERE globalObject = @globalObject

		--15
		DELETE FROM [content].[scriptableEntities]
		WHERE globalObject = @globalObject

		--16
		DELETE FROM [content].[scriptableWorldObjects]
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

