


CREATE PROCEDURE [dbo].[spAddRecipeMissing]
	@recipeName VARCHAR(255),
	@globalObjectRecipe VARCHAR(255),
	@itemGlobalObject VARCHAR(255),
	@effectGlobalObject VARCHAR(255),
	@effectGroupGlobalObject VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @code INT
		DECLARE @globalObjectCodeEffect VARCHAR(255)
		DECLARE @globalObjectEffect VARCHAR(255)
		DECLARE @globalObjectNameEffect VARCHAR(255)

		DECLARE @globalObjectCodeItem VARCHAR(255)
		DECLARE @globalObjectItem VARCHAR(255)
		DECLARE @globalObjectNameItem VARCHAR(255)
		
		DECLARE @globalObjectCodeEffectGroup VARCHAR(255)
		DECLARE @globalObjectEffectGroup VARCHAR(255)
		DECLARE @globalObjectNameEffectGroup VARCHAR(255)

		DECLARE @description VARCHAR(255)
		DECLARE @recipeNameNoSpaces VARCHAR(255)

		SET @recipeNameNoSpaces = REPLACE(@recipeName, ' ', '');

		EXEC @code = spGetNextGlobalObjectCode @globalObjectCodeString = 'effectUnlockRecipe';
		SET @globalObjectCodeEffect = CONCAT('effectUnlockRecipe:', @code);
		SET @globalObjectEffect = 'effectUnlockRecipe' + @recipeNameNoSpaces;
		SET @globalObjectNameEffect = 'Effect - Unlock ' + @recipeName + ' Recipe';

		EXEC @code = spGetNextGlobalObjectCode @globalObjectCodeString = 'scrollRecipe';
		SET @globalObjectCodeItem = CONCAT('scrollRecipe:', @code);
		SET @globalObjectItem = 'scrollRecipe' + @recipeNameNoSpaces;
		SET @globalObjectNameItem = 'Recipe Scroll - ' + @recipeName;

		EXEC @code = spGetNextGlobalObjectCode @globalObjectCodeString = 'effectGroup';
		SET @globalObjectCodeEffectGroup = CONCAT('effectGroup:', @code);
		SET @globalObjectEffectGroup = 'effectGroupUnlockRecipe' + @recipeNameNoSpaces;
		SET @globalObjectNameEffectGroup = 'Effect Group - Unlock ' + @recipeName + ' Recipe';

		SET @description = '<color=green>Use: Learn Recipe - ' + @recipeName + ' </color>'

		PRINT @globalObjectCodeEffect
		PRINT @globalObjectEffect
		PRINT @globalObjectNameEffect
		
		PRINT @globalObjectCodeItem
		PRINT @globalObjectItem
		PRINT @globalObjectNameItem

		PRINT @globalObjectCodeEffectGroup
		PRINT @globalObjectEffectGroup
		PRINT @globalObjectNameEffectGroup

		PRINT @description

		EXEC spDeleteItem @globalObject = @itemGlobalObject;
		PRINT 'Deleted Item - ' + @itemGlobalObject

		EXEC spDeleteEffect @globalObject = @effectGlobalObject;
		PRINT 'Deleted Effect - ' + @effectGlobalObject

		EXEC spDeleteEffectGroup @globalObject = @effectGroupGlobalObject;
		PRINT 'Deleted Effect Group- ' + @effectGroupGlobalObject

		
		EXEC spAddEffectUnlockRecipe @globalObjectCode = @globalObjectCodeEffect, @globalObject = @globalObjectEffect, @globalObjectName = @globalObjectNameEffect, @globalObjectRecipe = @globalObjectRecipe

		PRINT 'Added Effect'

		EXEC spAddConsumableRecipe @globalObjectCode = @globalObjectCodeItem, @globalObject = @globalObjectItem, @globalObjectName = @globalObjectNameItem, @globalObjectEffect = @globalObjectEffect, @description = @description

		PRINT 'Added Consumable'

		EXEC spAddEffectGroupItemRecipe @globalObjectCode = @globalObjectCodeEffectGroup, @globalObject = @globalObjectEffectGroup, @globalObjectName = @globalObjectNameEffectGroup, @globalObjectEffect = @globalObjectEffect, @globalObjectItem = @globalObjectItem

		PRINT 'Added EffectGroup'

		INSERT INTO [content].[associatedGlobalObjects] VALUES (31, @globalObjectRecipe, 31, @globalObjectRecipe, 0)
		INSERT INTO [content].[associatedGlobalObjects] VALUES (31, @globalObjectRecipe, 21, @globalObjectItem, 1)
		INSERT INTO [content].[associatedGlobalObjects] VALUES (31, @globalObjectRecipe, 7, @globalObjectEffect, 2)
		INSERT INTO [content].[associatedGlobalObjects] VALUES (31, @globalObjectRecipe, 3, @globalObjectEffectGroup, 3)



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

