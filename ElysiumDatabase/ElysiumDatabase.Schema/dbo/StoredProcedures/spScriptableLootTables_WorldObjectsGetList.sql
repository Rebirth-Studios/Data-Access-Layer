
-- =============================================
-- Author: Eric Ingram
-- Create date: 03/04/2022
-- Updated: MM/DD/YYYY
-- Description: 
-- ============================================_
CREATE PROCEDURE [dbo].[spScriptableLootTables_WorldObjectsGetList]
	
AS
BEGIN
	SET NOCOUNT ON;
	Select globalObjectCode, worldObjectGlobalObjectCode
	FROM worldObjectsToLootTables
	--JOIN [content].[scriptableObjects] sO ON sLT.globalObjectCode = sO.globalObjectCode
	--JOIn [content].[globalObjects] glO ON sO.globalObjectCode = glO.globalObjectCode
	ORDER BY globalObjectCode
    RETURN 0
END

GO

