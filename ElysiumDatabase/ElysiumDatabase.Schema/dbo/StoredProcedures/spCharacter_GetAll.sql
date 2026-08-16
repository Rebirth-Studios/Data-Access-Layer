-- =============================================
-- Author: Eric Ingram
-- Create date: 2021
-- Updated: 02/16/2021 - Only return characters where status = 'active'
-- Description: Gets all players active
-- =============================================
CREATE PROCEDURE [dbo].[spCharacter_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	Select characterName, spawnedWorldObjectId
	From [runtime].[characters] 
	WHERE status = 'active'
	ORDER BY characterName DESC
	RETURN 0
END

GO

