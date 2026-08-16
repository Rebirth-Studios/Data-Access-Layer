


CREATE PROCEDURE [dbo].[spGetNextGlobalObjectCode]
	@globalObjectCodeString VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		
		DECLARE @Number INT
		
		SELECT TOP 1 @Number = CAST(SUBSTRING(globalObjectCode, CHARINDEX(':', globalObjectCode + ':') + 1, LEN(globalObjectCode)) AS INT)
		FROM [content].[globalObjects]
		WHERE globalObjectCode LIKE @globalObjectCodeString + '%'
		ORDER BY CAST(SUBSTRING(globalObjectCode, 
                       CHARINDEX(':', globalObjectCode) + 1, 
                       LEN(globalObjectCode)) AS INT) DESC

		SET @Number = @Number+1;

		RETURN @Number
		-- Commit the transaction if everything succeeds
        
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

