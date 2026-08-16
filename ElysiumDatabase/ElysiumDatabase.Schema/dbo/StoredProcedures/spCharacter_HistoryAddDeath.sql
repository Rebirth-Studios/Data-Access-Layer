


CREATE procedure [dbo].[spCharacter_HistoryAddDeath] (
	@playerCharacterSpawnedWorldId uniqueidentifier output,
	@killedBySpawnedWorldId uniqueidentifier output,
	@globalTierId int,
	@globalRankId int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
) as
BEGIN TRY

		INSERT INTO dbo.historyPlayerCharacterDeaths (playerCharacterSpawnedWorldId, killedBySpawnedWorldId, lastUpdate, globalTierId, globalRankId)
		VALUES (@playerCharacterSpawnedWorldId, @killedBySpawnedWorldId,  GETDATE(), @globalTierId, @globalRankId)
		

END TRY
BEGIN CATCH
	SET @errMessage = ERROR_MESSAGE()
	SET @errParameters =   CONCAT('@playerCharacterSpawnedWorldId - ', @playerCharacterSpawnedWorldId, 
	 '  @killedBySpawnedWorldId - ', @killedBySpawnedWorldId, 
	 '  @globalTierId - ', @globalTierId, 
	 '  @globalRankId - ', @globalRankId)
	

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
   @errParameters);

 END CATCH

GO

