-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/16/2021 - Only return characters where status = 'active'
-- Description: Gets list of all characters in active status for single player account
-- =============================================
CREATE PROCEDURE [dbo].[spCharacter_GetList]
	@playerAccountId int
AS
BEGIN TRY
	SET NOCOUNT ON;
	Select characterId, characterName, spawnedWorldObjectId, characterRankId, characterTierId, gender, face, eyebrows, hair, facialHair, eyeColor, hairColor, skinColor, race, stubbleColor
	From [runtime].[characters] 
	Where playerAccountId = @playerAccountId and status = 'active'
	ORDER BY lastUpdated DESC
	RETURN 0
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
   CONCAT('@playerAccountId - ', @playerAccountId));
 END CATCH

GO

