
CREATE procedure [dbo].[spAbilityLevelRequirements_GetList] 

as
BEGIN TRY
	SELECT 
	lRA.rankId, lRA.levelId, lRA.minExperience, lRA.maxExperience
	FROM [content].[levelRequirementsAbilities] lRA
END TRY

BEGIN CATCH
	INSERT INTO [ops].[DB_Errors]
    VALUES
	(SUSER_SNAME(),
   ERROR_NUMBER(),
   ERROR_STATE(),
   ERROR_SEVERITY(),
   ERROR_LINE(),
   ERROR_PROCEDURE(),
   ERROR_MESSAGE(),
   GETDATE(),
   'N/A');
 END CATCH

GO

