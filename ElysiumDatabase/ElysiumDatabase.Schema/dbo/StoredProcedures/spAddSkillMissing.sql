


CREATE PROCEDURE [dbo].[spAddSkillMissing]
	@skillName VARCHAR(255),
	@globalObjectSkill VARCHAR(255)
AS

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		DECLARE @code INT
		DECLARE @globalObjectCodeEffect VARCHAR(255)
		DECLARE @globalObjectEffect VARCHAR(255)
		DECLARE @globalObjectNameEffect VARCHAR(255)

		DECLARE @globalObjectCodeItem VARCHAR(255)
		DECLARE @globalObjectItem VARCHAR(255)
		DECLARE @globalObjectNameItem VARCHAR(255)
		
		DECLARE @globalObjectCodeEffectGroup VARCHAR(255)
		DECLARE @globalObjectEffectGroup VARCHAR(255)
		DECLARE @globalObjectNameEffectGroup VARCHAR(255)

		DECLARE @description VARCHAR(255)

		EXEC @code = spGetNextGlobalObjectCode @globalObjectCodeString = 'effectUnlockSkill';
		SET @globalObjectCodeEffect = CONCAT('effectUnlockSkill:', @code);
		SET @globalObjectEffect = 'effectUnlockSkill' + @skillName;
		SET @globalObjectNameEffect = 'Effect - Unlock ' + @skillName + ' Skill';

		EXEC @code = spGetNextGlobalObjectCode @globalObjectCodeString = 'manualSkill';
		SET @globalObjectCodeItem = CONCAT('manualSkill:', @code);
		SET @globalObjectItem = 'manualSkill' + @skillName;
		SET @globalObjectNameItem = 'Skill Manual - ' + @skillName;

		EXEC @code = spGetNextGlobalObjectCode @globalObjectCodeString = 'effectGroup';
		SET @globalObjectCodeEffectGroup = CONCAT('effectGroup:', @code);
		SET @globalObjectEffectGroup = 'effectGroupUnlockSkill' + @skillName;
		SET @globalObjectNameEffectGroup = 'Effect Group - Unlock ' + @skillName + ' Skill';

		SET @description = '<color=green>Use: Learn Skill - ' + @skillName + ' </color>'

		--PRINT @globalObjectCodeEffect
		--PRINT @globalObjectEffect
		--PRINT @globalObjectNameEffect
		
		--PRINT @globalObjectCodeItem
		--PRINT @globalObjectItem
		--PRINT @globalObjectNameItem

		--PRINT @globalObjectCodeEffectGroup
		--PRINT @globalObjectEffectGroup
		--PRINT @globalObjectNameEffectGroup

		--PRINT @description

		EXEC spAddEffectUnlock @globalObjectCode = @globalObjectCodeEffect, @globalObject = @globalObjectEffect, @globalObjectName = @globalObjectNameEffect, @globalObjectSkill = @globalObjectSkill

		PRINT 'Added Effect'

		EXEC spAddConsumable @globalObjectCode = @globalObjectCodeItem, @globalObject = @globalObjectItem, @globalObjectName = @globalObjectNameItem, @globalObjectEffect = @globalObjectEffect, @description = @description

		PRINT 'Added Consumable'

		EXEC spAddEffectGroupItemSkill @globalObjectCode = @globalObjectCodeEffectGroup, @globalObject = @globalObjectEffectGroup, @globalObjectName = @globalObjectNameEffectGroup, @globalObjectEffect = @globalObjectEffect, @globalObjectItem = @globalObjectItem

		PRINT 'Added EffectGroup'

		INSERT INTO [content].[associatedGlobalObjects] VALUES (32, @globalObjectSkill, 32, @globalObjectSkill, 0)
		INSERT INTO [content].[associatedGlobalObjects] VALUES (32, @globalObjectSkill, 21, @globalObjectItem, 1)
		INSERT INTO [content].[associatedGlobalObjects] VALUES (32, @globalObjectSkill, 7, @globalObjectEffect, 2)
		INSERT INTO [content].[associatedGlobalObjects] VALUES (32, @globalObjectSkill, 3, @globalObjectEffectGroup, 3)



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

