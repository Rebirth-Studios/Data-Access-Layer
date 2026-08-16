


CREATE PROCEDURE [dbo].[spAddAllItemMissing]
	@gameObjectTypeId TINYINT	
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @globalObjectItem  VARCHAR(255)
		DECLARE @globalObjectNameItem VARCHAR(255)

		-- Check if the cursor exists and clean it up
		IF CURSOR_STATUS('global', 'itemAllCursor') >= -1
		BEGIN
			CLOSE itemAllCursor
			DEALLOCATE itemAllCursor
		END

		DECLARE itemAllCursor CURSOR FOR 
			SELECT ss.globalObject AS globalObjectItem, glo.globalObjectName AS globalObjectNameItem
			FROM [content].[scriptableWeapons] ss
			JOIN [content].[globalObjects] glo ON ss.globalObject = glo.globalObject
			LEFT JOIN [content].[associatedGlobalObjects] ago ON ss.globalObject = ago.associatedGlobalObject
			LEFT JOIN [content].[scriptableRequirements] sr ON ss.globalObject = sr.requiredForGlobalObject
			WHERE ago.id IS NULL
		
		
		-- Open the cursor
		OPEN itemAllCursor

		-- Fetch the first record
		FETCH NEXT FROM itemAllCursor INTO @globalObjectItem, @globalObjectNameItem

		-- Loop through all records
		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT '@globalObjectItem - ' + @globalObjectItem;
			PRINT '@globalObjectNameItem - ' + @globalObjectNameItem;
			-- Execute the stored procedure with the current values
			EXEC spAddItemMissingAllLevels @globalObjectItem = @globalObjectItem, @globalObjectNameItem = @globalObjectNameItem, @gameObjectTypeId = @gameObjectTypeId
    
			-- Fetch the next record
			FETCH NEXT FROM itemAllCursor INTO @globalObjectItem, @globalObjectNameItem
		END

		-- Clean up
		CLOSE itemAllCursor
		DEALLOCATE itemAllCursor



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

