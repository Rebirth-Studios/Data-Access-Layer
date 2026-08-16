
CREATE procedure [dbo].[spSkillLevelRequirements_GetList] 

as
BEGIN TRY
	SELECT 
	lRS.rankId, lRS.levelId, lRS.minExperience, lRS.maxExperience
	FROM [content].[levelRequirementsSkills] lRS
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

