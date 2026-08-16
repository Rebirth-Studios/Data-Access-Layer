


CREATE PROCEDURE [dbo].[spAddItemMissingAllLevels]
	@globalObjectItem VARCHAR(255),
	@globalObjectNameItem VARCHAR(255),
	@gameObjectTypeId TINYINT
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @rarityId TINYINT
		DECLARE @count INT

		-- Check if the cursor exists and clean it up
		IF CURSOR_STATUS('global', 'itemCursor') >= -1
		BEGIN
			CLOSE itemCursor
			DEALLOCATE itemCursor
		END

		EXEC @count = spCheckItemRarityExists @globalObject = @globalObjectItem
		IF @count = 0
			BEGIN
				INSERT INTO [content].[scriptableItemRarities] VALUES (@globalObjectItem, 1, 'None')
				PRINT 'INSERTED INTO scriptableItemRarities'
			END


		DECLARE itemCursor CURSOR FOR 
			SELECT rarityId
			FROM [content].[scriptableItemRarities]
			WHERE globalObject = @globalObjectItem
		
		
		-- Open the cursor
		OPEN itemCursor

		-- Fetch the first record
		FETCH NEXT FROM itemCursor INTO @rarityId

		-- Loop through all records
		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT CONCAT('@rarityId - ', @rarityId)
			-- Execute the stored procedure with the current values
			EXEC spAddItemMissing @globalObjectItem = @globalObjectItem, @globalObjectNameItem = @globalObjectNameItem, @gameObjectTypeId = @gameObjectTypeId, @rarityId = @rarityId

			-- Fetch the next record
			FETCH NEXT FROM itemCursor INTO @rarityId
		END

		-- Clean up
		CLOSE itemCursor
		DEALLOCATE itemCursor



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

