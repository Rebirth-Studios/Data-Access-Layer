


/****** Object:  StoredProcedure [dbo].[spCharacter_EquipmentMove    Script Date: 12/18/21 22:21:02 ******/

-- =============================================
-- Author: Eric Ingram
-- Create date: 12/18/2021
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Renamed charactersEquipment to spawnedWorldObjectsEquipment
-- Description: Can be used to swap equipped items
-- =============================================
CREATE procedure [dbo].[spCharacter_EquipmentMove] (
    @characterId uniqueIdentifier,
	@fromEquipmentLocationId tinyint,
	@toEquipmentLocationId tinyint,
	@logging bit,
	@batchRowId int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
) AS
DECLARE
	@fromItemId uniqueIdentifier,
	@toItemId uniqueIdentifier,
	@selectFromCount tinyint,
	@selectToCount tinyint,
	@updateFromItemTempCount tinyint,
	@updateToItemCount tinyint,
	@updateFromItemCount tinyint,
	@moveEquipmentLocationId int,
	--@storedProcedureName varchar(255),
	@insertBatchProcessingCount tinyint
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','@characterId - ', @characterId, 
		 '  @fromEquipmentSlotId - ', @fromEquipmentLocationId, 
		 '  @toEquipmentSlotId - ', @toEquipmentLocationId, 
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)
	


	--SET Stored Procedure Name
	--SET @storedProcedureName = 'spCharacter_EquipmentMove'
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	SET @moveEquipmentLocationId = 99 -- Used to move item out of slot

	--FIND FROM ITEM
	SELECT @fromItemId = instancedItemId 
	FROM [runtime].[spawnedWorldObjectsEquipment]
	WHERE spawnedWorldObjectId = @characterId AND equipmentLocationId = @fromEquipmentLocationId
	SET @selectFromCount = @@rowcount

	--FIND TO ITEM
	SELECT @toItemId = instancedItemId 
	FROM [runtime].[spawnedWorldObjectsEquipment]
	WHERE spawnedWorldObjectId = @characterId AND equipmentLocationId = @toEquipmentLocationId
	SET @selectToCount = @@rowcount

	IF ((@fromItemId IS NOT NULL) AND (@selectFromCount = 1)) AND ((@toItemId IS NOT NULL) AND (@selectToCount = 1))
	BEGIN
		--UPDATE FROM EQUIPPED ITEM TO LOCATION 99 SO THERE WILL NOT BE 2 ITEMS IN SAME EQUIPMENT LOCATION
		UPDATE [runtime].[spawnedWorldObjectsEquipment]
		SET equipmentLocationId = @moveEquipmentLocationId, lastUpdate = GETDATE()
		WHERE instancedItemId = @fromItemId
		SET @updateFromItemTempCount = @@rowcount

		--UPDATE TO EQUIPPED ITEM TO FROM_LOCATION_ID
		UPDATE [runtime].[spawnedWorldObjectsEquipment]
		SET equipmentLocationId = @fromEquipmentLocationId, lastUpdate = GETDATE()
		WHERE instancedItemId = @toItemId
		SET @updateToItemCount = @@rowcount
		
		--UPDATE FROM EQUIPPED ITEM TO TO_LOCATION_ID
		UPDATE [runtime].[spawnedWorldObjectsEquipment]
		SET equipmentLocationId = @toEquipmentLocationId, lastUpdate = GETDATE()
		WHERE instancedItemId = @fromItemId
		SET @updateFromItemCount = @@rowcount
	END
	
	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@selectFromCount = 0) SET @errCustomMessage = 'NO ITEM FOUND TO EQUIP IN FROM SLOT'
	IF (@selectToCount = 0) SET @errCustomMessage = 'NO ITEM FOUND TO EQUIP IN TO SLOT'
	IF (@selectFromCount > 1) SET @errCustomMessage = 'MORE THAN ONE ITEM TO EQUIP IN FROM SLOT FOUND WHICH SHOULD NOT BE POSSIBLE!!!'
	IF (@selectToCount > 1) SET @errCustomMessage = 'MORE THAN ONE ITEM TO EQUIP IN TO SLOT FOUND WHICH SHOULD NOT BE POSSIBLE!!!'
	IF (@updateFromItemTempCount = 0) SET @errCustomMessage = 'FROM EQUIPMENT ITEM NOT MOVED TO TEMP LOCATION'
	IF (@updateToItemCount = 0) SET @errCustomMessage = 'TO_EQUIPMENT ITEM NOT MOVED TO FROM_LOCATION'
	IF (@updateFromItemCount = 0) SET @errCustomMessage = 'FROM_EQUIPMENT ITEM NOT MOVED TO TO_LOCATION'

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
		CONCAT_WS(',','  @errParameters: ', @errParameters, 
		 '  @fromItemId: ', @fromItemId,
		 '  @toItemId: ', @toItemId,
		 '  @selectFromCount: ', @selectFromCount,
		 '  @selectToCount: ', @selectToCount, 
		 '  @updateFromItemTempCount : ', @updateFromItemTempCount ,
		 '  @updateToItemCount : ', @updateToItemCount ,
		 '  @updateFromItemCount: ', @updateFromItemCount,
		 '  @insertBatchProcessingCount: ', @insertBatchProcessingCount,
		 '  @updateToItemCount: ', @updateToItemCount));
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
		CONCAT_WS(',','  @errParameters: ', @errParameters, 
		 '  @fromItemId: ', @fromItemId,
		 '  @toItemId: ', @toItemId,
		 '  @selectFromCount: ', @selectFromCount,
		 '  @selectToCount: ', @selectToCount, 
		 '  @updateFromItemTempCount : ', @updateFromItemTempCount ,
		 '  @updateToItemCount : ', @updateToItemCount ,
		 '  @updateFromItemCount: ', @updateFromItemCount,
		 '  @insertBatchProcessingCount: ', @insertBatchProcessingCount,
		 '  @updateToItemCount: ', @updateToItemCount));
 END CATCH

GO

