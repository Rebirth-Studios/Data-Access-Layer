-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/13/2021 - Updated error handling
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables
-- Updated: 03/31/2022 - Fixed issue with selectCount = 1 never occuring
-- Description: Used to update quantity
-- =============================================
CREATE procedure [dbo].[spCharacter_InventoryUpdateQuantity]
	--@spawnedObjectId uniqueIdentifier,
	--@bagId uniqueIdentifier,
	--@slotIndex int,
	@instancedItemId uniqueIdentifier,
	@quantity tinyint,
	@logging bit,
	@batchRowId int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE 
	@itemId uniqueIdentifier,
	@insertBatchProcessingCount tinyint,
	@selectCount tinyint,
	@updateCount tinyint,
	@deleteCount tinyint
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','@instancedItemId - ', @instancedItemId, 
		 '  @quantity - ', @quantity,
		 '  @logging - ', @logging)

	--SET Stored Procedure Name
	--SET @storedProcedureName = 'spCharacter_InventoryUpdateQuantity'
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	--IF ((@selectCount = 1) AND (@quantity > 0))
	Update [runtime].[instancedItems] Set quantity = @quantity, lastUpdate = GETDATE() Where instancedItemId = @instancedItemId
    SET @updateCount = @@rowcount

	--If Quantity
	IF ((@selectCount = 1) AND (@quantity = 0))
	BEGIN
		UPDATE [runtime].[instancedItems] Set quantity = @quantity, lastUpdate = GETDATE() Where instancedItemId = @instancedItemId
		SET @updateCount = @@rowcount
		DELETE FROM [runtime].[spawnedWorldObjectsInventory] Where instancedItemId = @instancedItemId
		SET @deleteCount = @@rowcount
	END

	IF (@selectCount = 0) SET @errCustomMessage = 'NO ITEM FOUND IN characterInventory'
	

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
		 '  @instancedItemId- ', @instancedItemId, 
		 '  @selectCount - ', @selectCount,
		 '  @updateCount - ', @updateCount,
		 '  @deleteCount - ', @deleteCount));
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
		 '  @instancedItemId- ', @instancedItemId, 
		 '  @selectCount - ', @selectCount,
		 '  @updateCount - ', @updateCount,
		 '  @deleteCount - ', @deleteCount));
 END CATCH

GO

