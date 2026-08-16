-- =============================================
-- Author: Eric Ingram
-- Create date: 03/07/2022
-- Updated: 03/11/2022 - Added spawnedVendorInventory, spawnedVendors, and updated spawnedNPC join to use spawnedEntityId
-- 
-- Description: Deletes all spawned Animal world objects (spawnedWorldObjectId)
-- =============================================
CREATE PROCEDURE [dbo].[spSpawnedWorldObjects_DeleteAllNonPC_Internal]
	--@logging bit,
	--@batchRowId smallint,
	--@errMessage varchar(1000) output,
	--@errParameters varchar(MAX) output,
	--@errCustomMessage varchar(1000) output
AS
DECLARE
	--@storedProcedureName varchar(255),
	@insertBatchProcessingCount int,
	@deleteSpawnedContainersCount int,
    @deleteSpawnedInteractablesCount int,
    @deleteSpawnedWorldObjectsCount int,
	@errMessage varchar(1000),
	@errParameters varchar(MAX)
BEGIN TRY
    --Add parameters passed by C# for logging
    --SET @errParameters =   CONCAT_WS(',','@spawnedWorldObjectId - ', @spawnedWorldObjectId,
                                     --'  @logging - ',@logging,
									 --'  @batchRowId - ',@batchRowId)

	--SET Stored Procedure Name
	--SET @storedProcedureName = 'spSpawnedWorldObjects_AnimalDelete'
	--INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	--SET @insertBatchProcessingCount = @@rowcount


    --ADD TO HISTORY TABLE


	EXEC spCharacter_InventoryDeleteAll_ForAllNonPC_Internal
    
    --DELETE FROM SPAWNED TABLES
    DELETE spawnedAnimals
	FROM [runtime].[spawnedAnimals]
	JOIN [runtime].[spawnedEntities] ON spawnedAnimals.spawnedWorldObjectId = spawnedEntities.spawnedWorldObjectId
	JOIN [runtime].[spawnedWorldObjects] ON spawnedEntities.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedContainersCount = @@rowcount


	DELETE spawnedEnemyHumanoids
	FROM [runtime].[spawnedEnemyHumanoids]
	JOIN [runtime].[spawnedEntities] ON spawnedEnemyHumanoids.spawnedWorldObjectId = spawnedEntities.spawnedWorldObjectId
	JOIN [runtime].[spawnedWorldObjects] ON spawnedEntities.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedContainersCount = @@rowcount

	DELETE spawnedMonsters
	FROM [runtime].[spawnedMonsters]
	JOIN [runtime].[spawnedEntities] ON spawnedMonsters.spawnedWorldObjectId = spawnedEntities.spawnedWorldObjectId
	JOIN [runtime].[spawnedWorldObjects] ON spawnedEntities.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedContainersCount = @@rowcount

	DELETE [runtime].[spawnedVendorInventory]
	FROM [runtime].[spawnedVendorInventory] sVI
	JOIN [runtime].[spawnedVendors] sV ON sVI.spawnedWorldObjectId = sV.spawnedWorldObjectId
	JOIN [runtime].[spawnedNPCs] sN ON sV.spawnedWorldObjectId = sN.spawnedWorldObjectId
	JOIN [runtime].[spawnedEntities] sE ON sN.spawnedWorldObjectId = sE.spawnedWorldObjectId
	JOIN [runtime].[spawnedWorldObjects] sWO ON sE.spawnedWorldObjectId = sWO.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON sWO.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedContainersCount = @@rowcount

	DELETE [runtime].[spawnedVendors]
	FROM [runtime].[spawnedVendors] sV
	JOIN [runtime].[spawnedNPCs] sN ON sV.spawnedWorldObjectId = sN.spawnedWorldObjectId
	JOIN [runtime].[spawnedEntities] sE ON sN.spawnedWorldObjectId = sE.spawnedWorldObjectId
	JOIN [runtime].[spawnedWorldObjects] sWO ON sE.spawnedWorldObjectId = sWO.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON sWO.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedContainersCount = @@rowcount

	DELETE [runtime].[spawnedNPCs]
	FROM [runtime].[spawnedNPCs] sN
	JOIN [runtime].[spawnedEntities] sE ON sN.spawnedWorldObjectId = sE.spawnedWorldObjectId
	JOIN [runtime].[spawnedWorldObjects] sWO ON sE.spawnedWorldObjectId = sWO.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON sWO.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedContainersCount = @@rowcount

	DELETE spawnedEntities
	FROM [runtime].[spawnedEntities]
	JOIN [runtime].[spawnedWorldObjects] ON spawnedEntities.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedInteractablesCount = @@rowcount


	DELETE spawnedContainers
	FROM [runtime].[spawnedContainers]
	JOIN [runtime].[spawnedInteractables] ON spawnedContainers.spawnedWorldObjectId = spawnedInteractables.spawnedWorldObjectId
	JOIN [runtime].[spawnedWorldObjects] ON spawnedInteractables.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedContainersCount = @@rowcount

	DELETE spawnedGatherables
	FROM [runtime].[spawnedGatherables]
	JOIN [runtime].[spawnedInteractables] ON spawnedGatherables.spawnedWorldObjectId = spawnedInteractables.spawnedWorldObjectId
	JOIN [runtime].[spawnedWorldObjects] ON spawnedInteractables.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedContainersCount = @@rowcount

	DELETE spawnedInteractables
	FROM [runtime].[spawnedInteractables]
	JOIN [runtime].[spawnedWorldObjects] ON spawnedInteractables.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedContainersCount = @@rowcount

    DELETE spawnedWorldObjects
	FROM [runtime].[spawnedWorldObjects]
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteSpawnedWorldObjectsCount = @@rowcount


    
END TRY

BEGIN CATCH
    SET @errMessage = ERROR_MESSAGE()

    INSERT INTO [ops].[DB_Errors]
    VALUES
        (SUSER_SNAME(),
         ERROR_NUMBER(),
         ERROR_STATE(),
         ERROR_SEVERITY(),
         ERROR_LINE(),
         ERROR_PROCEDURE(),
         ERROR_MESSAGE(),
         GETDATE(),
         CONCAT_WS(',','  @errParameters - ', @errParameters,
                           '  @deleteSpawnedContainersCount - ',@deleteSpawnedContainersCount,
                           '  @deleteSpawnedInteractablesCount - ',@deleteSpawnedInteractablesCount,
						   '  @insertBatchProcessingCount - ',@insertBatchProcessingCount,
                           '  @deleteSpawnedWorldObjectsCount - ',@deleteSpawnedWorldObjectsCount));
END CATCH

GO

