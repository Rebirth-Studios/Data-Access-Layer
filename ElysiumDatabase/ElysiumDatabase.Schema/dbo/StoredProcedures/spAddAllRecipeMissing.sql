


CREATE PROCEDURE [dbo].[spAddAllRecipeMissing]
	
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @recipeName  VARCHAR(255)
		DECLARE @globalObjectRecipe VARCHAR(255)
		DECLARE @itemGlobalObject VARCHAR(255)
		DECLARE @effectGlobalObject VARCHAR(255)
		DECLARE @effectGroupGlobalObject VARCHAR(255)

		-- Check if the cursor exists and clean it up
		IF CURSOR_STATUS('global', 'recipeCursor') >= -1
		BEGIN
			CLOSE recipeCursor
			DEALLOCATE recipeCursor
		END

		DECLARE recipeCursor CURSOR FOR 
			SELECT SUBSTRING(ss.globalObjectName, CHARINDEX('-', ss.globalObjectName + '-') + 2, LEN(ss.globalObjectName)) AS recipeName, 
			ss.globalObject AS globalObjectRecipe, 
			sc.globalObject AS itemGlobalObject, 
			ue.globalObject AS effectGlobalObject, 
			ete.effectGroupGlobalObject
			FROM [content].[scriptableRecipes] ss
			JOIN [content].[scriptableConsumables] sc ON sc.description LIKE '%' + ss.recipeDescription + '%'
			JOIN [content].[unlockEffects] ue ON unlockGlobalObject = ss.globalObject
			JOIN [content].[effectsToEffectGroupsMapping] etE ON effectGlobalObject = ue.globalObject
			LEFT JOIN [content].[associatedGlobalObjects] ago ON ss.globalObject = ago.associatedGlobalObject
			WHERE ago.id IS NULL
		
		
		-- Open the cursor
		OPEN recipeCursor

		-- Fetch the first record
		FETCH NEXT FROM recipeCursor INTO @recipeName, @globalObjectRecipe, @itemGlobalObject, @effectGlobalObject, @effectGroupGlobalObject

		-- Loop through all records
		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT '@recipeName - ' + @recipeName;
			PRINT '@globalObjectRecipe - ' + @globalObjectRecipe;
			PRINT '@itemGlobalObject - ' + @itemGlobalObject;
			PRINT '@effectGlobalObject - ' + @effectGlobalObject;
			PRINT '@effectGroupGlobalObject - ' + @effectGroupGlobalObject;
			-- Execute the stored procedure with the current values
			EXEC spAddRecipeMissing @recipeName = @recipeName, @globalObjectRecipe = @globalObjectRecipe, @itemGlobalObject = @itemGlobalObject, @effectGlobalObject = @effectGlobalObject, @effectGroupGlobalObject = @effectGroupGlobalObject
    
			-- Fetch the next record
			FETCH NEXT FROM recipeCursor INTO @recipeName, @globalObjectRecipe, @itemGlobalObject, @effectGlobalObject, @effectGroupGlobalObject
		END

		-- Clean up
		CLOSE recipeCursor
		DEALLOCATE recipeCursor



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

