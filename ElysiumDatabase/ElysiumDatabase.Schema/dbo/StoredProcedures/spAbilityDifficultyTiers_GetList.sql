
CREATE procedure [dbo].[spAbilityDifficultyTiers_GetList] 

as
BEGIN TRY
	SELECT 
	aDT.abilityDifficultyTier,
	aDT.abilityDifficultyTierId,
	aDT.abilityDifficultyExperiencePenalty
	FROM [content].[abilityDifficultyTiers] aDT
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

