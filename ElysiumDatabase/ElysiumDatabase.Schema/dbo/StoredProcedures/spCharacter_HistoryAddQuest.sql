



CREATE procedure [dbo].[spCharacter_HistoryAddQuest] (
	@playerCharacterSpawnedWorldId uniqueidentifier output,
	@questTypeId int,
	@questTierId int,
	@questRankId int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
) as
BEGIN TRY

		INSERT INTO dbo.historyPlayerCharacterQuests (playerCharacterSpawnedWorldId, questTypeId, questTierId, questRankId, lastUpdate)
		VALUES (@playerCharacterSpawnedWorldId, @questTypeId, @questTierId, @questRankId,  GETDATE())

END TRY
BEGIN CATCH
	SET @errMessage = ERROR_MESSAGE()
	SET @errParameters =   CONCAT('@playerCharacterSpawnedWorldId - ', @playerCharacterSpawnedWorldId, 
	 '  @questTypeId - ', @questTypeId, 
	 '  @questTierId - ', @questTierId, 
	 '  @questRankId - ', @questRankId)

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

