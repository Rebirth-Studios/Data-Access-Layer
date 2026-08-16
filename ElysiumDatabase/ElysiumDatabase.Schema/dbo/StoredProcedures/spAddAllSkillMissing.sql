


CREATE PROCEDURE [dbo].[spAddAllSkillMissing]
	
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @skillName  VARCHAR(255)
		DECLARE @globalObjectSkill VARCHAR(255)

		-- Check if the cursor exists and clean it up
		IF CURSOR_STATUS('global', 'skillCursor') >= -1
		BEGIN
			CLOSE skillCursor
			DEALLOCATE skillCursor
		END

		DECLARE skillCursor CURSOR FOR 
			SELECT SUBSTRING(ss.globalObjectName, CHARINDEX('-', ss.globalObjectName + '-') + 2, LEN(ss.globalObjectName)) AS skillName, ss.globalObject AS globalObjectSkill
			FROM [content].[scriptableSkills] ss
			LEFT JOIN [content].[associatedGlobalObjects] ago ON ss.globalObject = ago.associatedGlobalObject
			WHERE ago.id IS NULL
		
		
		-- Open the cursor
		OPEN skillCursor

		-- Fetch the first record
		FETCH NEXT FROM skillCursor INTO @skillName, @globalObjectSkill

		-- Loop through all records
		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT '@skillName - ' + @skillName;
			PRINT '@globalObjectSkill - ' + @globalObjectSkill;
			-- Execute the stored procedure with the current values
			EXEC spAddSkillMissing @skillName = @skillName, @globalObjectSkill = @globalObjectSkill
    
			-- Fetch the next record
			FETCH NEXT FROM skillCursor INTO @skillName, @globalObjectSkill
		END

		-- Clean up
		CLOSE skillCursor
		DEALLOCATE skillCursor



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

