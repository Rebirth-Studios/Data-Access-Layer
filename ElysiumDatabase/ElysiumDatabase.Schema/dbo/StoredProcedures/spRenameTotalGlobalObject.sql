

CREATE PROCEDURE [dbo].[spRenameTotalGlobalObject]
	@globalObjectCurrent VARCHAR(255),
	@globalObjectNew VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
	
		ALTER TABLE [content].[scriptableObjects] DROP CONSTRAINT FK_scriptableObjects_globalObjects
		ALTER TABLE [content].[scriptableTotals] DROP CONSTRAINT scriptableTotals_scriptableObjects_globalObjectCode_fk
		ALTER TABLE [content].[scriptableTotalsCollect] DROP CONSTRAINT scriptableTotalsCollect_scriptableTotals_totalGlobalObjectCode_fk
		ALTER TABLE [content].[scriptableTotalsConsume] DROP CONSTRAINT FK_scriptableTotalsConsume_scriptableTotals
		ALTER TABLE [content].[scriptableTotalsCraft] DROP CONSTRAINT scriptableTotalsCraft_scriptableTotals_totalGlobalObjectCode_fk
		ALTER TABLE [content].[scriptableTotalsGather] DROP CONSTRAINT scriptableTotalsGather_scriptableTotals_totalGlobalObjectCode_fk
		ALTER TABLE [content].[scriptableTotalsKill] DROP CONSTRAINT scriptableTotalsKill_scriptableTotals_totalGlobalObjectCode_fk

		UPDATE [content].[globalObjects]
		SET globalObject = @globalObjectNew
		WHERE globalObject = @globalObjectCurrent

		UPDATE [content].[scriptableObjects]
		SET globalObject = @globalObjectNew
		WHERE globalObject = @globalObjectCurrent

		UPDATE [content].[scriptableTotals]
		SET totalGlobalObject = @globalObjectNew
		WHERE totalGlobalObject = @globalObjectCurrent

		UPDATE [content].[scriptableTotalsCollect]
		SET totalGlobalObject = @globalObjectNew
		WHERE totalGlobalObject = @globalObjectCurrent

		UPDATE [content].[scriptableTotalsConsume]
		SET globalObject = @globalObjectNew
		WHERE globalObject = @globalObjectCurrent

		UPDATE [content].[scriptableTotalsCraft]
		SET totalGlobalObject = @globalObjectNew
		WHERE totalGlobalObject = @globalObjectCurrent
		
		UPDATE [content].[scriptableTotalsGather]
		SET totalGlobalObject = @globalObjectNew
		WHERE totalGlobalObject = @globalObjectCurrent

		UPDATE [content].[scriptableTotalsKill]
		SET totalGlobalObject = @globalObjectNew
		WHERE totalGlobalObject = @globalObjectCurrent


		ALTER TABLE [content].[scriptableObjects] ADD CONSTRAINT FK_scriptableObjects_globalObjects FOREIGN KEY (globalObject) REFERENCES [content].[globalObjects] ([globalObject])
		ALTER TABLE [content].[scriptableTotals] ADD CONSTRAINT scriptableTotals_scriptableObjects_globalObjectCode_fk FOREIGN KEY (totalGlobalObject) REFERENCES [content].[scriptableObjects] ([globalObject])
		ALTER TABLE [content].[scriptableTotalsCollect] ADD CONSTRAINT scriptableTotalsCollect_scriptableTotals_totalGlobalObjectCode_fk FOREIGN KEY (totalGlobalObject) REFERENCES [content].[scriptableTotals] (totalGlobalObject)
		ALTER TABLE [content].[scriptableTotalsConsume] ADD CONSTRAINT FK_scriptableTotalsConsume_scriptableTotals FOREIGN KEY (globalObject) REFERENCES [content].[scriptableTotals] (totalGlobalObject)
		ALTER TABLE [content].[scriptableTotalsCraft] ADD CONSTRAINT scriptableTotalsCraft_scriptableTotals_totalGlobalObjectCode_fk FOREIGN KEY (totalGlobalObject) REFERENCES [content].[scriptableTotals] (totalGlobalObject)
		ALTER TABLE [content].[scriptableTotalsGather] ADD CONSTRAINT scriptableTotalsGather_scriptableTotals_totalGlobalObjectCode_fk FOREIGN KEY (totalGlobalObject) REFERENCES [content].[scriptableTotals] (totalGlobalObject)
		ALTER TABLE [content].[scriptableTotalsKill] ADD CONSTRAINT scriptableTotalsKill_scriptableTotals_totalGlobalObjectCode_fk FOREIGN KEY (totalGlobalObject) REFERENCES [content].[scriptableTotals] (totalGlobalObject)
		

		-- Commit the transaction if everything succeeds
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

