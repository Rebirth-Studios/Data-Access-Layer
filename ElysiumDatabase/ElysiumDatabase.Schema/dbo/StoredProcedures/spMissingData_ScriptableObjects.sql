

CREATE PROCEDURE [dbo].[spMissingData_ScriptableObjects]
	
AS
BEGIN

	SELECT globalObjectCode,globalObjectSubTypeId 
	FROM [content].[globalObjects]
	WHERE globalObjectSubTypeId != '10' AND globalObjectSubTypeId != 15 AND globalObjectSubTypeId != 17 AND globalObjectSubTypeId <> '21' AND globalObjectSubTypeId <> '26' 
	AND globalObjectCode != 'ability:0' AND globalObjectCode != 'skill:0' AND globalObjectCode NOT IN
    (SELECT globalObjectCode 
     FROM [content].[scriptableObjects])
ORDER BY globalObjectCode
	
END

GO

