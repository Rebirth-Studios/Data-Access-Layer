CREATE PROCEDURE [dbo].[spCharacter_MissionsGetList]
	@spawnedWorldObjectId uniqueIdentifier
AS
BEGIN TRY
	SET NOCOUNT ON;
	SELECT cQ.characterQuestId,
	cQ.characterQuestTitle,
	cQ.characterQuestDescription, 
	cq.characterQuestTypeId,
	cQ.characterQuestTierId,
	cQ.characterQuestRankId,
	cQ.characterQuestObjectiveId, 
	cQ.characterQuestCurrentProgress, 
	cQ.characterQuestRequiredProgress, 
	cQ.characterQuestStatusId, 
	cQ.characterQuestValue
	FROM characterMissions cQ 
	JOIN [runtime].[characters] ch ON cQ.characterId = ch.characterId
	JOIN [runtime].[spawnedWorldObjects] sWO ON ch.spawnedWorldObjectId = sWO.spawnedWorldObjectId
	Where ch.spawnedWorldObjectId = @spawnedWorldObjectId
	RETURN 0
END TRY

BEGIN CATCH
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
   CONCAT('@spawnedWorldObjectId - ', @spawnedWorldObjectId));

   -- Transaction uncommittable
    IF (XACT_STATE()) = -1
      ROLLBACK TRANSACTION
 
-- Transaction committable
    IF (XACT_STATE()) = 1
      COMMIT TRANSACTION
 END CATCH

GO

