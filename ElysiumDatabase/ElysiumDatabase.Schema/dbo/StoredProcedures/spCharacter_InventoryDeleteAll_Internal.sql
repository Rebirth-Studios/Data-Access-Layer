
-- =============================================
-- Author: Eric Ingram
-- Create date: 02/12/2022
-- Updated: 02/26/2022 - Added @batchRowId
-- Updated: 03/09/2022 - Renamed character tables to spawnedWorldObjects tables
-- Description: Delete all items for character				
-- =============================================

CREATE PROCEDURE [dbo].[spCharacter_InventoryDeleteAll_Internal]
	@spawnedWorldObjectId uniqueIdentifier,
	@logging bit
AS
DECLARE 
	@errMessage varchar(1000),
	@errParameters varchar(MAX),
	@errCustomMessage varchar(1000),
	@deleteCharactersInventoryCount tinyint,
    @deleteCharactersEquipmentCount tinyint,
	@deleteCharactersBagsCount tinyint,
    @deleteInstancedArmorCount tinyint,
    @deleteInstancedWeaponsCount tinyint,
    @deleteInstancedEquipmentCount tinyint,
    @deleteInstancedConsumablesCount tinyint,
    @deleteInstancedMaterialsCount tinyint,
	@deleteInstancedGeneralItemsCount tinyint,
	@deleteInstancedBagsCount tinyint,
	@deleteInstancedItemsCount tinyint
BEGIN TRY 
	--Add parameters passed by C# for logging
	SET @errParameters =  CONCAT_WS(',','  @spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		 '  @logging - ', @logging)
		 

	DELETE FROM [runtime].[spawnedWorldObjectsInventory] WHERE spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteCharactersInventoryCount = @@rowcount --CHARACTER INVENTORY
    DELETE FROM [runtime].[spawnedWorldObjectsEquipment] WHERE spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteCharactersEquipmentCount = @@rowcount --CHARACTER EQUIPMENT
	DELETE FROM [runtime].[spawnedWorldObjectsBags] WHERE spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteCharactersBagsCount = @@rowcount --CHARACTER BAGS

    DELETE instancedArmor
	FROM [runtime].[instancedArmor] iA
	JOIN [runtime].[instancedEquipment] iE ON iA.instancedItemId = iE.instancedItemId
	JOIN [runtime].[instancedItems] iI ON iE.instancedItemId = iI.instancedItemId
	WHERE iI.spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteInstancedArmorCount = @@rowcount --INSTANCED ARMOR

	DELETE instancedWeapons
	FROM [runtime].[instancedWeapons] iW
	JOIN [runtime].[instancedEquipment] iE ON iW.instancedItemId = iE.instancedItemId
	JOIN [runtime].[instancedItems] iI ON iE.instancedItemId = iI.instancedItemId
	WHERE iI.spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteInstancedWeaponsCount = @@rowcount --INSTANCED WEAPONS

	DELETE instancedEquipment
	FROM [runtime].[instancedEquipment] iE
	JOIN [runtime].[instancedItems] iI ON iE.instancedItemId = iI.instancedItemId
	WHERE iI.spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteInstancedEquipmentCount = @@rowcount --INSTANCED EQUIPMENT

	DELETE instancedMaterials 
	FROM [runtime].[instancedMaterials] iM
	JOIN [runtime].[instancedItems] iI ON iM.instancedItemId = iI.instancedItemId
	WHERE iI.spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteInstancedMaterialsCount = @@rowcount --INSTANCED MATERIALS

	DELETE instancedGeneralItems 
	FROM [runtime].[instancedGeneralItems] iGi
	JOIN [runtime].[instancedItems] iI ON iGi.instancedItemId = iI.instancedItemId
	WHERE iI.spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteInstancedMaterialsCount = @@rowcount --INSTANCED GENERAL ITEMS

	DELETE instancedConsumables
	FROM [runtime].[instancedConsumables] iC
	JOIN [runtime].[instancedItems] iI ON iC.instancedItemId = iI.instancedItemId
	WHERE iI.spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteInstancedConsumablesCount = @@rowcount --INSTANCED CONSUMABLES

	DELETE instancedBags
	FROM [runtime].[instancedBags] iB
	JOIN [runtime].[instancedItems] iI ON iB.instancedItemId = iI.instancedItemId
	WHERE iI.spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteInstancedBagsCount = @@rowcount --INSTANCED BAGS

	DELETE instancedItems
	FROM [runtime].[instancedItems]
	WHERE spawnedWorldObjectId = @spawnedWorldObjectId
    SET @deleteInstancedItemsCount = @@rowcount --INSTANCED ITEMS

    
	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	--IF (@selectMail = 0) SET @errCustomMessage = 'NO Mail FOUND'
	

	--IF CUSTOM ERROR MESSAGE SET OR LOGGING ENABLED
	IF (@logging = 1) --OR (@errCustomMessage IS NOT NULL)
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
		'  @deleteCharactersInventoryCount - ', @deleteCharactersInventoryCount,
		'  @deleteCharactersEquipmentCount - ', @deleteCharactersEquipmentCount,
		'  @deleteCharactersBagsCount - ', @deleteCharactersBagsCount,
		'  @deleteInstancedArmorCount - ', @deleteInstancedArmorCount,
		'  @deleteInstancedWeaponsCount - ', @deleteInstancedWeaponsCount,
		'  @deleteInstancedEquipmentCount - ', @deleteInstancedEquipmentCount,
		'  @deleteInstancedMaterialsCount - ', @deleteInstancedMaterialsCount,
		'  @deleteInstancedGeneralItemsCount - ', @deleteInstancedGeneralItemsCount,
		'  @deleteInstancedConsumablesCount - ', @deleteInstancedConsumablesCount,
		'  @deleteInstancedBagsCount - ', @deleteInstancedBagsCount,
		'  @deleteInstancedItemsCount - ', @deleteInstancedItemsCount));
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
		'  @deleteCharactersInventoryCount - ', @deleteCharactersInventoryCount,
		'  @deleteCharactersEquipmentCount - ', @deleteCharactersEquipmentCount,
		'  @deleteCharactersBagsCount - ', @deleteCharactersBagsCount,
		'  @deleteInstancedArmorCount - ', @deleteInstancedArmorCount,
		'  @deleteInstancedWeaponsCount - ', @deleteInstancedWeaponsCount,
		'  @deleteInstancedEquipmentCount - ', @deleteInstancedEquipmentCount,
		'  @deleteInstancedMaterialsCount - ', @deleteInstancedMaterialsCount,
		'  @deleteInstancedGeneralItemsCount - ', @deleteInstancedGeneralItemsCount,
		'  @deleteInstancedConsumablesCount - ', @deleteInstancedConsumablesCount,
		'  @deleteInstancedBagsCount - ', @deleteInstancedBagsCount,
		'  @deleteInstancedItemsCount - ', @deleteInstancedItemsCount));
 END CATCH

GO

