


CREATE PROCEDURE [dbo].[spIconTypesToSearches]
	
AS

	SELECT 
	type, 
	iconSearch, 
	enumName, 
	ic.id AS iconSearchId
	FROM [content].[iconTypesToSearches] iT
	JOIN [content].[iconSearches] ic ON iT.iconSearch = ic.iconSearchName

GO

