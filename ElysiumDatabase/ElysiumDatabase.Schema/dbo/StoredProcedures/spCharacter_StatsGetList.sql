

CREATE PROCEDURE [dbo].[spCharacter_StatsGetList]
	@spawnedWorldObjectId uniqueIdentifier
AS
BEGIN TRY
	SELECT cS.characterStatStatusId, cS.statId, cS.characterStatTypeId, characterStatValue
	FROM [runtime].[charactersStats] cS
	JOIN [runtime].[characters] ch ON cS.characterId = ch.characterId
	JOIN [runtime].[spawnedWorldObjects] sWO ON ch.spawnedWorldObjectId = sWO.spawnedWorldObjectId
	WHERE ch.spawnedWorldObjectId = @spawnedWorldObjectId
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
 END CATCH

GO

