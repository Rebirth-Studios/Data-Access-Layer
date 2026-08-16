

CREATE PROCEDURE [dbo].[spMissingData_ScriptableBags]
	
AS
BEGIN
	--MISSING scriptableBags
	SELECT scriptableItemId 
	FROM [content].[scriptableItems]
	WHERE itemTypeId = 3 AND scriptableItemId NOT IN
		(SELECT scriptableItemId 
		 FROM [content].[scriptableBags])
	ORDER BY scriptableItemId
END

GO

