


CREATE PROCEDURE [dbo].[spPrefabs]
	
AS
	SELECT 
	pr.globalObject,
	pr.prefabName,
	glo.globalObjectName,
	sp.prefabPath AS 'prefabFilePath'
	FROM [content].[prefabs] pr
	JOIN [content].[globalObjects] glo ON pr.globalObject = glo.globalObject
	JOIN [content].[scriptablePrefabs] sp ON pr.prefabName = sp.prefabName

GO

