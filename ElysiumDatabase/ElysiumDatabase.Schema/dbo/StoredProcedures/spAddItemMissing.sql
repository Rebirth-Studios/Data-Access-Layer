


CREATE PROCEDURE [dbo].[spAddItemMissing]
	@globalObjectItem VARCHAR(255),
	@globalObjectNameItem VARCHAR(255),
	@gameObjectTypeId TINYINT,
	@rarityId TINYINT
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @code INT
		DECLARE @globalObjectCodeEffectGroup VARCHAR(255)
		DECLARE @globalObjectEffectGroup VARCHAR(255)
		DECLARE @globalObjectNameEffectGroup VARCHAR(255)
		DECLARE @globalObjectEffect VARCHAR(255)
		DECLARE @globalObjectItemFirstUpper VARCHAR(255)
		DECLARE @count INT
		DECLARE @countAssociated INT
		--DECLARE @rarityId TINYINT

		SET @globalObjectItemFirstUpper = CONCAT(UPPER(LEFT(@globalObjectItem, 1)), SUBSTRING(@globalObjectItem, 2, LEN(@globalObjectItem)))
		SET @globalObjectEffect = 'effectNone'


		EXEC @code = spGetNextGlobalObjectCode @globalObjectCodeString = 'effectGroup';
		SET @globalObjectCodeEffectGroup = CONCAT('effectGroup:', @code);
		SET @globalObjectEffectGroup = 'effectGroup' + @globalObjectItemFirstUpper;
		SET @globalObjectNameEffectGroup = 'Effect Group - ' + @globalObjectNameItem;

		PRINT 'globalObjectCode - ' + @globalObjectCodeEffectGroup
		PRINT 'globalObject - ' + @globalObjectEffectGroup
		PRINT 'globalObjectName - ' + @globalObjectNameEffectGroup

	
		EXEC @count = spCheckEffectGroupExists @globalObject = @globalObjectEffectGroup
		PRINT CONCAT('count EffectGroup - ', @count)

		IF @count = 0
			BEGIN
				DELETE FROM [content].[effectGroupsToItemsMapping] WHERE itemGlobalObject = @globalObjectItem
				
				EXEC spAddEffectGroupItem
				@globalObjectCode = @globalObjectCodeEffectGroup, 
				@globalObject = @globalObjectEffectGroup, 
				@globalObjectName = @globalObjectNameEffectGroup,
				@globalObjectEffect = @globalObjectEffect, 
				@globalObjectItem = @globalObjectItem,
				@rarityId = @rarityId
			END
		ELSE
			BEGIN
				EXEC spAddEffectGroupLevelsItem
				@globalObjectCode = @globalObjectCodeEffectGroup, 
				@globalObject = @globalObjectEffectGroup, 
				@globalObjectName = @globalObjectNameEffectGroup,
				@globalObjectEffect = @globalObjectEffect, 
				@globalObjectItem = @globalObjectItem,
				@rarityId = @rarityId
			END

		

		PRINT 'Added EffectGroup'

		INSERT INTO [content].[scriptableItemEffects] VALUES (@globalObjectItem, @rarityId, @globalObjectEffect, 'None', @rarityId)

		PRINT 'INSERT INTO scriptableItemEffects'

		EXEC @countAssociated = spCheckAssociatedObjectExists @globalObject = @globalObjectItem
		PRINT CONCAT('count Associated - ', @countAssociated)
		
		IF @countAssociated = 0
			BEGIN
				INSERT INTO [content].[associatedGlobalObjects] VALUES (@gameObjectTypeId, @globalObjectItem, @gameObjectTypeId, @globalObjectItem, 0)
				INSERT INTO [content].[associatedGlobalObjects] VALUES (@gameObjectTypeId, @globalObjectItem, 3, @globalObjectEffectGroup, 1)
			END
			
		
		EXEC @count = spCheckRequirementExists @globalObject = @globalObjectItem
		PRINT CONCAT('count Requirement - ', @count)	
		
		IF @count = 0
			BEGIN
				INSERT INTO [content].[scriptableRequirements] VALUES (@globalObjectItem, 'none', 15, 0, 0, 0, 0)
			END

		EXEC @count = spCheckPrefabExists @globalObject = @globalObjectItem
		PRINT CONCAT('count Prefab - ', @count)	
		
		IF @count = 0
			BEGIN
				INSERT INTO [content].[prefabs] VALUES (@globalObjectItem, 'Items/SM_Item_Bag_01')
			END

		EXEC @count = spCheckIconExists @globalObject = @globalObjectItem, @rarityId = @rarityId
		PRINT CONCAT('count Icon - ', @count)	
		
		IF @count = 0
			BEGIN
				INSERT INTO [content].[Icons] VALUES (@rarityId, @globalObjectItem, 'Funtion_Buttons/btn_question_n')
			END	

		-- Commit the transaction if everything succeeds
        COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		-- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH


END

GO

