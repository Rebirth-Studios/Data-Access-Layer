


CREATE PROCEDURE [dbo].[spAddEffectGroupItem]
	@globalObjectCode VARCHAR(255),
	@globalObject VARCHAR(255),
	@globalObjectName VARCHAR(255),
	@globalObjectEffect VARCHAR(255),
	@globalObjectItem VARCHAR(255),
	@rarityId TINYINT
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		DECLARE @scriptableObjectLevel VARCHAR(255)
		DECLARE @scriptableObjectLevelName VARCHAR(255)
		DECLARE @romanNumeral VARCHAR(1)

		IF @rarityId = 1 SET @romanNumeral = 'I'
		IF @rarityId = 2 SET @romanNumeral = 'II'
		IF @rarityId = 3 SET @romanNumeral = 'III'
		IF @rarityId = 4 SET @romanNumeral = 'IV'
		IF @rarityId = 5 SET @romanNumeral = 'V'
		IF @rarityId = 6 SET @romanNumeral = 'VI'
		IF @rarityId = 7 SET @romanNumeral = 'VII'

		SET @scriptableObjectLevel = CONCAT(@globalObject + 'Level', @rarityId)
		SET @scriptableObjectLevelName = @globalObjectName + ' Level ' + @romanNumeral

		--1
		INSERT INTO [content].[globalObjects] VALUES (@globalObjectCode, @globalObject, @globalObjectName, @globalObjectName, 5, 0, 24, 1, 2, 0, 0, 0)
		
		INSERT INTO [content].[scriptableObjects] VALUES (@globalObject, 24)
		
		INSERT INTO [content].[scriptableObjectLevels] VALUES (@globalObject, @rarityId, @scriptableObjectLevel, @scriptableObjectLevelName)

		INSERT INTO [content].[effectGroups] VALUES (@globalObject, 0, 0, 2, 1, 0, 0, -1, 'None', 1, 0)

		INSERT INTO [content].[effectGroupsLevels] VALUES (@globalObject, @scriptableObjectLevel, @rarityId)

		INSERT INTO [content].[effectsToEffectGroupsMapping] VALUES (@globalObjectEffect, @globalObject, @scriptableObjectLevel)

		INSERT INTO [content].[Icons] VALUES (@rarityId, @globalObject, 'unsorted/gray_11')

		INSERT INTO [content].[effectGroupsToItemsMapping] VALUES (@globalObject, @globalObjectItem, @rarityId, @rarityId)


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

