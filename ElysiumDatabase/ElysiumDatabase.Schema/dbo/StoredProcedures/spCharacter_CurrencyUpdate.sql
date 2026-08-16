-- =============================================
-- Author: Eric Ingram
-- Create date: 02/12/2022
-- Updated: 03/06/2022 - Renamed characterCurrency table to spawnedWorldObjectsCurrency
-- Updated: 03/19/2022 - Added support for tokens
-- Description: 
-- =============================================
CREATE procedure [dbo].[spCharacter_CurrencyUpdate] (
	@spawnedWorldObjectId uniqueIdentifier,
	@amount_Gold smallint,
	@amount_Silver tinyint,
	@amount_Copper tinyint,
	@tokens_Adventurer smallint,
	@tokens_Gatherer smallint,
	@tokens_Crafter smallint,
	@description varchar(255),
	@logging bit,
	@batchRowId int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
) AS
DECLARE
	@selectCurrentCurrencyCount int,
	@updateCurrencyCount int,
	@insertHistoryCount int,
	@amount_GoldCurrent int,
	@amount_GoldTransaction int,
	@amount_SilverCurrent int,
	@amount_SilverTransaction int,
	@amount_CopperCurrent int,
	@amount_CopperTransaction int,
	@tokens_AdventurerCurrent int,
	@tokens_AdventurerTransaction int,
	@tokens_GathererCurrent int,
	@tokens_GathererTransaction int,
	@tokens_CrafterCurrent int,
	@tokens_CrafterTransaction int,
	@characterId int,
	--@storedProcedureName varchar(255),
	@insertBatchProcessingCount bit
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		 '  @amount_Gold - ', @amount_Gold, 
		 '  @amount_Silver  - ', @amount_Silver ,
		 '  @amount_Copper - ', @amount_Copper,
		 '  @tokens_Adventurer - ', @tokens_Adventurer, 
		 '  @tokens_Gatherer  - ', @tokens_Gatherer ,
		 '  @tokens_Crafter - ', @tokens_Crafter,
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)
	
	--USED IF SERVER CRASHES DURING PROCESSING
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	--FIND Current Currency
	SELECT @amount_GoldCurrent = amount_Gold, @amount_SilverCurrent = amount_Silver, @amount_CopperCurrent = amount_Copper, 
	@tokens_AdventurerCurrent = token_adventuring, @tokens_GathererCurrent = token_gathering, @tokens_CrafterCurrent = token_crafting
	FROM [runtime].[spawnedWorldObjectsCurrency]
	WHERE spawnedWorldObjectId = @spawnedWorldObjectId
	SET @selectCurrentCurrencyCount = @@rowcount

	--UPDATE Currency
	UPDATE [runtime].[spawnedWorldObjectsCurrency]
	SET amount_Gold = (amount_Gold + @amount_Gold), amount_Silver = (amount_Silver + @amount_Silver), amount_Copper = (amount_Copper + @amount_Copper), lastUpdate = GETDATE(),
	token_adventuring = (token_adventuring + @tokens_Adventurer), token_gathering = (token_gathering + @tokens_Gatherer), token_crafting = (token_crafting + @tokens_Crafter)
	WHERE spawnedWorldObjectId = @spawnedWorldObjectId
	SET @updateCurrencyCount = @@rowcount
	
	SET @amount_GoldTransaction = @amount_GoldCurrent - @amount_Gold
	SET @amount_SilverTransaction = @amount_SilverCurrent - @amount_Silver
	SET @amount_CopperTransaction = @amount_CopperCurrent - @amount_Copper
	SET @tokens_AdventurerTransaction = @tokens_AdventurerCurrent - @tokens_Adventurer
	SET @tokens_GathererTransaction = @tokens_GathererCurrent - @tokens_Gatherer
	SET @tokens_CrafterTransaction = @tokens_CrafterCurrent - @tokens_Crafter


	INSERT INTO [history].[historyCurrencyTransactions](transactionDate, spawnedWorldObjectId, amount_Gold, amount_Silver, amount_Copper, description, tokens_Adventurer, tokens_Gatherer, tokens_Crafter)
	VALUES (GETDATE(), @spawnedWorldObjectId, @amount_GoldTransaction, @amount_SilverTransaction, @amount_CopperTransaction, @description, @tokens_AdventurerTransaction, @tokens_GathererTransaction, @tokens_CrafterTransaction)
	SET @insertHistoryCount = @@rowcount


	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@selectCurrentCurrencyCount = 0) SET @errCustomMessage = 'CHARACTER NOT FOUND IN charactersCurrency Table'
	IF (@insertHistoryCount = 0) SET @errCustomMessage = 'NO RECORD INSERTED INTO TRANSACTION TABLE'
	IF (@updateCurrencyCount = 0) SET @errCustomMessage = 'NO UPDATE MADE'
	IF (@updateCurrencyCount > 1) SET @errCustomMessage = 'MULTIPLE UPDATES MADE WHICH SHOULD NOT BE POSSIBLE!!!'

	--IF CUSTOM ERROR MESSAGE SET OR LOGGING ENABLED
	IF (@logging = 1) OR (@errCustomMessage IS NOT NULL)
	BEGIN
		INSERT INTO [ops].[DB_Errors]
		VALUES
		(SUSER_SNAME(),
		0,
		0,
		0,
		0,
		@@PROCID,
		@errCustomMessage,
		GETDATE(),
		CONCAT_WS(',','  @errParameters - ', @errParameters, 
		'  @insertBatchProcessingCount - ', @insertBatchProcessingCount,
		'  @selectCurrentCurrencyCount - ', @selectCurrentCurrencyCount,
		'  @updateCurrencyCount - ', @updateCurrencyCount,
		'  @amount_GoldCurrent - ', @amount_GoldCurrent,
		'  @amount_GoldTransaction - ', @amount_GoldTransaction,
		'  @amount_SilverCurrent - ', @amount_SilverCurrent,
		'  @amount_SilverTransaction - ', @amount_SilverTransaction,
		'  @amount_CopperCurrent - ', @amount_CopperCurrent,
		'  @amount_CopperTransaction - ', @amount_CopperTransaction,
		'  @tokens_AdventurerCurrent - ', @tokens_AdventurerCurrent,
		'  @tokens_AdventurerTransaction - ', @tokens_AdventurerTransaction,
		'  @tokens_GathererCurrent - ', @tokens_GathererCurrent,
		'  @tokens_GathererTransaction - ', @tokens_GathererTransaction,
		'  @tokens_CrafterCurrent - ', @tokens_CrafterCurrent,
		'  @tokens_CrafterTransaction - ', @tokens_CrafterTransaction,
		'  @insertHistoryCount - ', @insertHistoryCount,
		'  @updateCurrencyCount - ', @updateCurrencyCount));
	END

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
		'  @insertBatchProcessingCount - ', @insertBatchProcessingCount,
		'  @selectCurrentCurrencyCount - ', @selectCurrentCurrencyCount,
		'  @updateCurrencyCount - ', @updateCurrencyCount,
		'  @amount_GoldCurrent - ', @amount_GoldCurrent,
		'  @amount_GoldTransaction - ', @amount_GoldTransaction,
		'  @amount_SilverCurrent - ', @amount_SilverCurrent,
		'  @amount_SilverTransaction - ', @amount_SilverTransaction,
		'  @amount_CopperCurrent - ', @amount_CopperCurrent,
		'  @amount_CopperTransaction - ', @amount_CopperTransaction,
		'  @tokens_AdventurerCurrent - ', @tokens_AdventurerCurrent,
		'  @tokens_AdventurerTransaction - ', @tokens_AdventurerTransaction,
		'  @tokens_GathererCurrent - ', @tokens_GathererCurrent,
		'  @tokens_GathererTransaction - ', @tokens_GathererTransaction,
		'  @tokens_CrafterCurrent - ', @tokens_CrafterCurrent,
		'  @tokens_CrafterTransaction - ', @tokens_CrafterTransaction,
		'  @insertHistoryCount - ', @insertHistoryCount,
		'  @updateCurrencyCount - ', @updateCurrencyCount));
 END CATCH

GO

