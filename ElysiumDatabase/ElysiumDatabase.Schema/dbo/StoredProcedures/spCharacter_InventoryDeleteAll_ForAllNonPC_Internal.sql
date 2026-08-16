CREATE PROCEDURE [dbo].[spCharacter_InventoryDeleteAll_ForAllNonPC_Internal]
	--@spawnedWorldObjectId uniqueIdentifier,
	--@logging bit
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
	--SET @errParameters =  CONCAT_WS(',','  @spawnedWorldObjectId - ', @spawnedWorldObjectId, 
		 --'  @logging - ', @logging)
		 
	DELETE spawnedWorldObjectsCurrency
	FROM [runtime].[spawnedWorldObjectsCurrency]
	LEFT JOIN [runtime].[spawnedWorldObjects] ON spawnedWorldObjectsCurrency.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    --SET @deleteCharactersInventoryCount = @@rowcount --CHARACTER INVENTORY


	DELETE spawnedWorldObjectsInventory
	FROM [runtime].[spawnedWorldObjectsInventory]
	LEFT JOIN [runtime].[spawnedWorldObjects] ON spawnedWorldObjectsInventory.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteCharactersInventoryCount = @@rowcount --CHARACTER INVENTORY

    DELETE spawnedWorldObjectsEquipment 
	FROM [runtime].[spawnedWorldObjectsEquipment]
	JOIN [runtime].[spawnedWorldObjects] ON spawnedWorldObjectsEquipment.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteCharactersEquipmentCount = @@rowcount --CHARACTER EQUIPMENT


	DELETE spawnedWorldObjectsBags
	FROM [runtime].[spawnedWorldObjectsBags] 
	LEFT JOIN [runtime].[spawnedWorldObjects] ON spawnedWorldObjectsBags.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteCharactersBagsCount = @@rowcount --CHARACTER BAGS

    DELETE [runtime].[instancedArmor]
	FROM [runtime].[instancedArmor] iA
	JOIN [runtime].[instancedEquipment] iE ON iA.instancedItemId = iE.instancedItemId
	JOIN [runtime].[instancedItems] iI ON iE.instancedItemId = iI.instancedItemId
	LEFT JOIN [runtime].[spawnedWorldObjects] ON iI.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteInstancedArmorCount = @@rowcount --INSTANCED ARMOR

	DELETE [runtime].[instancedWeapons]
	FROM [runtime].[instancedWeapons] iW
	JOIN [runtime].[instancedEquipment] iE ON iW.instancedItemId = iE.instancedItemId
	JOIN [runtime].[instancedItems] iI ON iE.instancedItemId = iI.instancedItemId
	LEFT JOIN [runtime].[spawnedWorldObjects] ON iI.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteInstancedWeaponsCount = @@rowcount --INSTANCED WEAPONS

	DELETE [runtime].[instancedEquipment]
	FROM [runtime].[instancedEquipment] iE
	JOIN [runtime].[instancedItems] iI ON iE.instancedItemId = iI.instancedItemId
	LEFT JOIN [runtime].[spawnedWorldObjects] ON iI.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteInstancedEquipmentCount = @@rowcount --INSTANCED EQUIPMENT

	DELETE [runtime].[instancedMaterials] 
	FROM [runtime].[instancedMaterials] iM
	JOIN [runtime].[instancedItems] iI ON iM.instancedItemId = iI.instancedItemId
	LEFT JOIN [runtime].[spawnedWorldObjects] ON iI.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteInstancedMaterialsCount = @@rowcount --INSTANCED MATERIALS

	DELETE [runtime].[instancedGeneralItems] 
	FROM [runtime].[instancedGeneralItems] iGi
	JOIN [runtime].[instancedItems] iI ON iGi.instancedItemId = iI.instancedItemId
	LEFT JOIN [runtime].[spawnedWorldObjects] ON iI.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteInstancedMaterialsCount = @@rowcount --INSTANCED GENERAL ITEMS

	DELETE [runtime].[instancedConsumables]
	FROM [runtime].[instancedConsumables] iC
	JOIN [runtime].[instancedItems] iI ON iC.instancedItemId = iI.instancedItemId
	LEFT JOIN [runtime].[spawnedWorldObjects] ON iI.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteInstancedConsumablesCount = @@rowcount --INSTANCED CONSUMABLES

	DELETE [runtime].[instancedBags]
	FROM [runtime].[instancedBags] iB
	JOIN [runtime].[instancedItems] iI ON iB.instancedItemId = iI.instancedItemId
	LEFT JOIN [runtime].[spawnedWorldObjects] ON iI.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteInstancedBagsCount = @@rowcount --INSTANCED BAGS

	DELETE [runtime].[instancedItems]
	FROM [runtime].[instancedItems] iI
	LEFT JOIN [runtime].[spawnedWorldObjects] ON iI.spawnedWorldObjectId = spawnedWorldObjects.spawnedWorldObjectId
	LEFT JOIN [runtime].[characters] ON spawnedWorldObjects.spawnedWorldObjectId = characters.spawnedWorldObjectId
	WHERE characterId IS NULL
    SET @deleteInstancedItemsCount = @@rowcount --INSTANCED ITEMS

    
	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	--IF (@selectMail = 0) SET @errCustomMessage = 'NO Mail FOUND'
	

	--IF CUSTOM ERROR MESSAGE SET OR LOGGING ENABLED
	

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

