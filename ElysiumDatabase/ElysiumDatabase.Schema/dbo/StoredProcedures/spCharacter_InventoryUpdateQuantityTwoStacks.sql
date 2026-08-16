


-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables
-- Description: ???
-- =============================================
CREATE procedure [dbo].[spCharacter_InventoryUpdateQuantityTwoStacks] 
    @fromInstancedItemId uniqueIdentifier, 
	@fromQuantity tinyint,
	@toInstancedItemId uniqueIdentifier,
	@toQuantity tinyint,
	@logging bit,
	@batchRowId int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE
	--@storedProcedureName varchar(255),
	@insertBatchProcessingCount bit,
	@updateFromQuantityCount bit,
	@updateToQuantityCount bit
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @fromInstancedItemId - ', @fromInstancedItemId, 
		 '  @fromQuantity - ', @fromQuantity, 
		 '  @fromQuantity - ', @fromQuantity,
		 '  @toInstancedItemId  - ', @toInstancedItemId ,
		 '  @toQuantity - ', @toQuantity,
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--SET Stored Procedure Name
	--SET @storedProcedureName = 'spCharacter_InventorySplitStack'
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	UPDATE [runtime].[instancedItems] Set quantity = @fromQuantity, lastUpdate = GETDATE() Where instancedItemId = @fromInstancedItemId
    SET @updateFromQuantityCount = @@rowcount

	IF @fromQuantity = 0
			BEGIN
				DELETE FROM [runtime].[spawnedWorldObjectsInventory] Where instancedItemId = @fromInstancedItemId
			END

	UPDATE [runtime].[instancedItems] Set quantity = @toQuantity, lastUpdate = GETDATE() Where instancedItemId = @toInstancedItemId
	SET @updateToQuantityCount = @@rowcount

		IF @toQuantity = 0
			BEGIN
				DELETE FROM [runtime].[spawnedWorldObjectsInventory] Where instancedItemId = @toInstancedItemId
			END
	
	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	--IF ((@selectfromInventoryCount = 0) OR (@fromItemId IS NULL)) SET @errCustomMessage = 'NO FROM ITEM FOUND'
	--IF (@selectfromInventoryCount > 1) SET @errCustomMessage = 'MORE THAN ONE ITEM FOUND WHICH SHOULD NOT BE POSSIBLE!!!'


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
		 '  @updateFromQuantityCount - ', @updateFromQuantityCount,
		 '  @updateToQuantityCount - ', @updateToQuantityCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));

	END
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
	 CONCAT_WS(',','  @errParameters - ', @errParameters, 
		 '  @updateFromQuantityCount - ', @updateFromQuantityCount,
		 '  @updateToQuantityCount - ', @updateToQuantityCount,
		 '  @insertBatchProcessingCount - ', @insertBatchProcessingCount));


  
 END CATCH

GO

