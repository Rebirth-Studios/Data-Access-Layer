



CREATE PROCEDURE [dbo].[spPrefabTypesToSearches]
	
AS

	SELECT 
	type, 
	prefabSearch, 
	enumName, 
	ps.id AS prefabSearchId
	FROM [content].[prefabTypesToSearches] pT
	JOIN [content].[prefabSearches] ps ON pT.prefabSearch = ps.prefabSearchName

GO

