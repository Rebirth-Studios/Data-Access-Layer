
CREATE PROCEDURE [dbo].[spRenameEffectGroupGlobalObject]
	@globalObjectCurrent VARCHAR(255),
	@globalObjectNew VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		
	
		--FK_scriptableObjects_globalObjects											scriptableObjects
		--FK__associate__globa__405F0DC1												associatedGlobalObjects
		--effectGroups_scriptableObjects_globalObjectCode_fk							effectGroups
		--effectsToEffectGroupsMapping_effectGroups_effectGroupGlobalObjectCode_fk		effectsToEffectGroupsMapping
		--effectGroupsToArmorSetsMapping_effectGroups_effectGroupGlobalObjectCode_fk	effectGroupsToGearSetsMapping
		--effectGroupsToItemsMapping_effectGroups_effectGroupGlobalObjectCode_fk		effectGroupsToItemsMapping
		--effectGroupsToObjectsMapping_effectGroups_globalObject_fk						effectGroupsToObjectsMapping


		--1
		ALTER TABLE [content].[scriptableObjects] DROP CONSTRAINT FK_scriptableObjects_globalObjects
		PRINT 'scriptableObjects DROPPED CONSTRAINT'
		ALTER TABLE [content].[scriptableObjectLevels] DROP CONSTRAINT FK__scriptabl__globa__78AA5B29
		PRINT 'scriptableObjectLevels DROPPED CONSTRAINT'
		ALTER TABLE [content].[associatedGlobalObjects] DROP CONSTRAINT FK__associate__globa__405F0DC1
		PRINT 'associatedGlobalObjects DROPPED CONSTRAINT'
		ALTER TABLE [content].[associatedGlobalObjects] DROP CONSTRAINT FK__associate__assoc__415331FA
		PRINT 'associatedGlobalObjects DROPPED CONSTRAINT'
		ALTER TABLE [content].[effectGroups] DROP CONSTRAINT effectGroups_scriptableObjects_globalObjectCode_fk
		PRINT 'effectGroups DROPPED CONSTRAINT'
		ALTER TABLE [content].[effectGroupsLevels] DROP CONSTRAINT FK_effectGroupsLevels_effectGroups
		PRINT 'effectGroupLevels DROPPED CONSTRAINT'
		ALTER TABLE [content].[effectsToEffectGroupsMapping] DROP CONSTRAINT FK_effectsToEffectGroupsMapping_effectGroups
		PRINT 'effectsToEffectGroupsMapping DROPPED CONSTRAINT'
		ALTER TABLE [content].[effectGroupsToGearSetsMapping] DROP CONSTRAINT effectGroupsToArmorSetsMapping_effectGroups_effectGroupGlobalObjectCode_fk
		PRINT 'effectGroupsToGearSetsMapping DROPPED CONSTRAINT'
		ALTER TABLE [content].[effectGroupsToItemsMapping] DROP CONSTRAINT FK_effectGroupsToItemsMapping_effectGroups
		PRINT 'effectGroupsToObjectsMapping DROPPED CONSTRAINT'
		ALTER TABLE [content].[effectGroupsToObjectsMapping] DROP CONSTRAINT effectGroupsToObjectsMapping_effectGroups_globalObject_fk
		ALTER TABLE [content].[Icons] DROP CONSTRAINT FK_Icons_globalObjects

		UPDATE [content].[globalObjects]
		SET globalObject = @globalObjectNew
		WHERE globalObject = @globalObjectCurrent

		UPDATE [content].[scriptableObjects]
		SET globalObject = @globalObjectNew
		WHERE globalObject = @globalObjectCurrent

		UPDATE [content].[scriptableObjectLevels]
		SET globalObject = @globalObjectNew
		WHERE globalObject = @globalObjectCurrent

		--2
		UPDATE [content].[associatedGlobalObjects]
		SET globalObject = @globalObjectNew
		WHERE globalObject = @globalObjectCurrent

		UPDATE [content].[associatedGlobalObjects]
		SET associatedGlobalObject = @globalObjectNew
		WHERE associatedGlobalObject = @globalObjectCurrent

		--3
		UPDATE [content].[effectGroups]
		SET effectGroupGlobalObject = @globalObjectNew
		WHERE effectGroupGlobalObject = @globalObjectCurrent

		UPDATE [content].[effectGroupsLevels]
		SET effectGroupGlobalObject = @globalObjectNew
		WHERE effectGroupGlobalObject = @globalObjectCurrent

		--4
		UPDATE [content].[effectsToEffectGroupsMapping]
		SET effectGroupGlobalObject = @globalObjectNew
		WHERE effectGroupGlobalObject = @globalObjectCurrent

		--5
		UPDATE [content].[effectGroupsToGearSetsMapping]
		SET effectGroupGlobalObject = @globalObjectNew
		WHERE effectGroupGlobalObject = @globalObjectCurrent

		--6
		UPDATE [content].[effectGroupsToItemsMapping]
		SET effectGroupGlobalObject = @globalObjectNew
		WHERE effectGroupGlobalObject = @globalObjectCurrent

		--7
		UPDATE [content].[effectGroupsToObjectsMapping]
		SET effectGroupGlobalObject = @globalObjectNew
		WHERE effectGroupGlobalObject = @globalObjectCurrent
		
		UPDATE [content].[Icons]
		SET globalObject = @globalObjectNew
		WHERE globalObject = @globalObjectCurrent


		ALTER TABLE [content].[scriptableObjects] ADD CONSTRAINT FK_scriptableObjects_globalObjects FOREIGN KEY (globalObject) REFERENCES [content].[globalObjects] ([globalObject])
		ALTER TABLE [content].[scriptableObjectLevels] ADD CONSTRAINT FK__scriptabl__globa__78AA5B29 FOREIGN KEY (globalObject) REFERENCES [content].[scriptableObjects] ([globalObject])
		ALTER TABLE [content].[associatedGlobalObjects] ADD CONSTRAINT FK__associate__globa__405F0DC1 FOREIGN KEY (globalObject) REFERENCES [content].[globalObjects] ([globalObject])
		ALTER TABLE [content].[associatedGlobalObjects] ADD CONSTRAINT FK__associate__assoc__415331FA FOREIGN KEY (associatedGlobalObject) REFERENCES [content].[globalObjects] ([globalObject])
		ALTER TABLE [content].[effectGroups] ADD CONSTRAINT effectGroups_scriptableObjects_globalObjectCode_fk FOREIGN KEY (effectGroupGlobalObject) REFERENCES [content].[scriptableObjects] ([globalObject])
		ALTER TABLE effectGroupLevels ADD CONSTRAINT FK_effectGroupsLevels_effectGroups FOREIGN KEY (effectGroupGlobalObject) REFERENCES [content].[effectGroups] (effectGroupGlobalObject)
		ALTER TABLE [content].[effectsToEffectGroupsMapping] ADD CONSTRAINT FK_effectsToEffectGroupsMapping_effectGroups FOREIGN KEY (effectGroupGlobalObject) REFERENCES [content].[effectGroups] ([effectGroupGlobalObject])
		ALTER TABLE [content].[effectGroupsToGearSetsMapping] ADD CONSTRAINT effectGroupsToArmorSetsMapping_effectGroups_effectGroupGlobalObjectCode_fk FOREIGN KEY (effectGroupGlobalObject) REFERENCES [content].[effectGroups] ([effectGroupGlobalObject])
		ALTER TABLE [content].[effectGroupsToItemsMapping] ADD CONSTRAINT FK_effectGroupsToItemsMapping_effectGroups FOREIGN KEY (effectGroupGlobalObject) REFERENCES [content].[effectGroups] ([effectGroupGlobalObject])
		ALTER TABLE [content].[effectGroupsToObjectsMapping] ADD CONSTRAINT effectGroupsToObjectsMapping_effectGroups_globalObject_fk FOREIGN KEY (effectGroupGlobalObject) REFERENCES [content].[effectGroups] ([effectGroupGlobalObject])
		ALTER TABLE [content].[Icons] ADD CONSTRAINT FK_Icons_globalObjects FOREIGN KEY (globalObject) REFERENCES [content].[globalObjects] ([globalObject])

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

