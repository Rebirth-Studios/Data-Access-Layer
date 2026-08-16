
CREATE procedure [dbo].[spSkillDifficultyTiers_GetList] 

as
BEGIN TRY
	SELECT 
	sDT.skillDifficultyTierId,
	sDT.skillDifficultyExperiencePenalty
	FROM [content].[skillDifficultyTiers] sDT
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

