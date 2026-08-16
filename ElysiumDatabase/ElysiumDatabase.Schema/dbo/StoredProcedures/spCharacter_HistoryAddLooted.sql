




CREATE procedure [dbo].[spCharacter_HistoryAddLooted] (
	@playerCharacterSpawnedWorldId uniqueidentifier output,
	@itemGlobalObjectCode varchar(255),
	@itemGlobalRarityId int,
	@quantity int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
) as
BEGIN TRY

		INSERT INTO dbo.historyPlayerCharacterLoot (playerCharacterSpawnedWorldId, quantity, lastUpdate, itemGlobalObjectCode, itemGlobalRarityId)
		VALUES (@playerCharacterSpawnedWorldId, @quantity, GETDATE(), @itemGlobalObjectCode, @itemGlobalRarityId)

END TRY
BEGIN CATCH
	SET @errMessage = ERROR_MESSAGE()
	SET @errParameters =   CONCAT('@playerCharacterSpawnedWorldId - ', @playerCharacterSpawnedWorldId, 
	 '  @itemGlobalObjectCode - ', @itemGlobalObjectCode, 
	 '  @itemGlobalRarityId - ', @itemGlobalRarityId, 
	 '  @quantity - ', @quantity)

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

