


CREATE PROCEDURE [dbo].[spAddEffectGroupItemSkill]
	@globalObjectCode VARCHAR(255),
	@globalObject VARCHAR(255),
	@globalObjectName VARCHAR(255),
	@globalObjectEffect VARCHAR(255),
	@globalObjectItem VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		DECLARE @scriptableObjectLevel VARCHAR(255)
		DECLARE @scriptableObjectLevelName VARCHAR(255)

		SET @scriptableObjectLevel = @globalObject + 'Level1'
		SET @scriptableObjectLevelName = @globalObjectName + ' Level I'

		--1
		INSERT INTO [content].[globalObjects] VALUES (@globalObjectCode, @globalObject, @globalObjectName, @globalObjectName, 5, 0, 24, 1, 2, 0, 0, 0)
		
		INSERT INTO [content].[scriptableObjects] VALUES (@globalObject, 24)
		
		INSERT INTO [content].[scriptableObjectLevels] VALUES (@globalObject, 1, @scriptableObjectLevel, @scriptableObjectLevelName)

		INSERT INTO [content].[effectGroups] VALUES (@globalObject, 0, 0, 2, 1, 0, 0, -1, 'None', 3, 6)

		INSERT INTO [content].[effectGroupsLevels] VALUES (@globalObject, @scriptableObjectLevel, 1)

		INSERT INTO [content].[effectsToEffectGroupsMapping] VALUES (@globalObjectEffect, @globalObject, @scriptableObjectLevel)

		INSERT INTO [content].[Icons] VALUES (1, @globalObject, 'unsorted/gray_11')

		INSERT INTO [content].[effectGroupsToItemsMapping] VALUES (@globalObject, @globalObjectItem, 1, 1)


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

