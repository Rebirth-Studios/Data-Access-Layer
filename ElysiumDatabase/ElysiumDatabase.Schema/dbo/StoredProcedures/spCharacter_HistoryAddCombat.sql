



CREATE procedure [dbo].[spCharacter_HistoryAddCombat] (
	@playerCharacterSpawnedWorldId uniqueidentifier output,
	@blocks int,
	@blocked int,
	@strikesReceived int,
	@strikesGiven int,
	@damageReceived int,
	@damageGiven int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
) as
BEGIN TRY

		INSERT INTO dbo.historyPlayerCharacterCombat (playerCharacterSpawnedWorldId, blocks, blocked, strikesReceived, strikesGiven, damageReceived, damageGiven, lastUpdate)
		VALUES (@playerCharacterSpawnedWorldId, @blocks, @blocked, @strikesReceived, @strikesGiven, @damageReceived, @damageGiven, GETDATE())

END TRY
BEGIN CATCH
	SET @errMessage = ERROR_MESSAGE()
	SET @errParameters =   CONCAT('@playerCharacterSpawnedWorldId - ', @playerCharacterSpawnedWorldId, 
	 '  @blocks - ', @blocks, 
	 '  @blocked - ', @blocked, 
	 '  @strikesReceived - ', @strikesReceived, 
	 '  @strikesGiven - ', @strikesGiven, 
	 '  @damageReceived - ', @damageReceived, 
	 '  @damageGiven - ', @damageGiven)

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

