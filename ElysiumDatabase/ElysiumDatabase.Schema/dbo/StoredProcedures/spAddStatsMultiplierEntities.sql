CREATE PROCEDURE [dbo].[spAddStatsMultiplierEntities]
	@entityTypeId TINYINT,
	@mainTypeId TINYINT,
	@classificationTypeId TINYINT,
	@subTypeId TINYINT
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 3, 1, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 3, 2, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 3, 3, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 3, 4, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 3, 5, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 3, 6, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 3, 7, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 1, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 2, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 3, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 4, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 5, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 6, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 7, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 8, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 9, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 10, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 11, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 12, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 13, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 18, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 20, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 21, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 6, 22, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
			INSERT INTO [content].[statsMultiplierEntities] VALUES (@entityTypeId, 8, 5, @mainTypeId, @classificationTypeId, @subTypeId, 1.00, 1.00, 1.00)
		COMMIT TRANSACTION;
	END TRY

	BEGIN CATCH
		-- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        -- Optionally, rethrow the error
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END

GO

