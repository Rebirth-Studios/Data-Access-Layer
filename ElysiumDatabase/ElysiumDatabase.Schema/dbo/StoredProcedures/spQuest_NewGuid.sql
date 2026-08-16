CREATE PROCEDURE [dbo].[spQuest_NewGuid]
	-- Add the parameters for the stored procedure here
    @questTitle varchar(1000),
	@questTypeId int,
	@questTierId int,
	@questRankId int,
	@description varchar(1000),
	@requiredProgress int,
	@currentProgress int,
	@questObjective varchar(255),
	@questStatusId int,
	@questValue int,
	@questId uniqueIdentifier,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
BEGIN TRY
	-- Insert statements for procedure here
	INSERT INTO [runtime].[questsGenerated](questId, questTitle, questTypeId, questTierId, questRankId, Description, requiredProgress, currentProgress, questObjectiveCode, questStatusId, questValue, lastUpdate)
	VALUES (@questId, @questTitle, @questTypeId, @questTierId, @questRankId, @description, @requiredProgress, @currentProgress, @questObjective, @questStatusId, @questValue, GETDATE())
END TRY

BEGIN CATCH
	SET @errMessage = ERROR_MESSAGE()
	SET @errParameters =  CONCAT_WS(',','@questTitle - ', @questTitle, 
		 '  @QuestTypeId - ', @questTypeId, 
		 '  @QuestTierId - ', @questTierId, 
		 '  @QuestRankId - ', @questRankId,
		 '  @QuestDescription - ', @description,
		 '  @QuestRequiredProgress - ', @requiredProgress,
		 '  @QuestCurrentProgress - ', @currentProgress,
		 '  @QuestObjective - ', @questObjective,
		 '  @QuestStatusId - ', @questStatusId,
		 '  @QuestId - ', @questId,
		 '  @QuestValue - ', @questValue)
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

