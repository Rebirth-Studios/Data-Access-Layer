CREATE procedure [dbo].[spLevelRequirements_GetList] 

as
BEGIN TRY
	SELECT 
	lR.rankId,
	lR.levelId,
	lR.minExperience,
	lR.maxExperience
	FROM [content].[levelRequirements] lR
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

