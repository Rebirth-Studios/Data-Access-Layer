
-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Renamed charactersEquipment to spawnedWorldObjectsEquipment
-- Description: Used to remove equipped item
-- =============================================
CREATE procedure [dbo].[spCharacter_EquipmentRemove]
    @spawnedWorldObjectId uniqueIdentifier,
	@equipmentSlotId tinyint,
	@logging bit,
	@batchRowId int,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS
DECLARE 
	--@storedProcedureName varchar(255),
	@insertBatchProcessingCount bit,
	@deleteCharactersEquipmentCount tinyint
BEGIN TRY
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','@spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		 '  @equipmentSlotId - ', @equipmentSlotId, 
		 '  @logging - ', @logging,
		 '  @batchRowId - ', @batchRowId)

	--SET Stored Procedure Name
	--SET @storedProcedureName = 'spCharacter_EquipmentRemove'
	INSERT INTO [ops].[historyBatchProcessing] (batchRowId, storedProcName, processDateTime) VALUES (@batchRowId,@@PROCID,GETDATE())
	SET @insertBatchProcessingCount = @@rowcount

	DELETE FROM [runtime].[spawnedWorldObjectsEquipment] WHERE spawnedWorldObjectId = @spawnedWorldObjectId AND equipmentLocationId = @equipmentSlotId
	SET @deleteCharactersEquipmentCount = @@rowcount

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@deleteCharactersEquipmentCount = 0) SET @errCustomMessage = 'NO ITEM UNEQUIPPED'
	IF (@deleteCharactersEquipmentCount > 1) SET @errCustomMessage = 'MORE THAN ONE ITEM UNEQUIPPED WHICH SHOULD NOT BE POSSIBLE'

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
		 '  @insertBatchProcessingCount: ', @insertBatchProcessingCount,
		 '  @deleteCharactersEquipmentCount: ', @deleteCharactersEquipmentCount));
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
		 '  @insertBatchProcessingCount: ', @insertBatchProcessingCount,
		 '  @deleteCharactersEquipmentCount: ', @deleteCharactersEquipmentCount));
 END CATCH

GO

