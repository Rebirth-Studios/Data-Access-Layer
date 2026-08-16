


CREATE procedure [dbo].[spCharacter_HistoryAddGathered] (
	@playerCharacterSpawnedWorldId uniqueidentifier output,
	@nodeSpawnedWorldId uniqueidentifier output,
	@materialsGlobalObjectCode varchar(255),
	@materialsGlobalRarityId int,
	@quantity int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
) as
BEGIN TRY

		INSERT INTO dbo.historyPlayerCharacterGathered (playerCharacterSpawnedWorldId, nodeSpawnedWorldId, quantity, lastUpdate, materialsGlobalObjectCode, materialsGlobalRarityId)
		VALUES (@playerCharacterSpawnedWorldId, @nodeSpawnedWorldId, @quantity, GETDATE(), @materialsGlobalObjectCode, @materialsGlobalRarityId)

END TRY
BEGIN CATCH
	SET @errMessage = ERROR_MESSAGE()
	SET @errParameters =   CONCAT('@playerCharacterSpawnedWorldId - ', @playerCharacterSpawnedWorldId, 
	 '  @nodeSpawnedWorldId - ', @nodeSpawnedWorldId, 
	 '  @materialsGlobalObjectCode - ', @materialsGlobalObjectCode, 
	 '  @materialsGlobalRarityId - ', @materialsGlobalRarityId, 
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

