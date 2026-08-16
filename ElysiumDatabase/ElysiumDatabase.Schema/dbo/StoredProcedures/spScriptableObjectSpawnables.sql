


CREATE PROCEDURE [dbo].[spScriptableObjectSpawnables]
	
AS
	
	SELECT 
	sos.globalObject,
	sos.scriptableObjectLevel,
	sos.variationId,
	sos.scriptableObjectSpawnable,
	sos.scriptableObjectSpawnableName,
	sol.scriptableObjectLevelName  AS 'scriptableObjectLevelName',
	glo.globalObjectName, 
	sos.levelId AS 'levelId',
	wot.typeName AS 'worldObjectTypeName',
	CASE WHEN cit.typeId != 0 THEN cit.typeId WHEN git.typeId != 0 THEN git.typeId WHEN eit.typeId != 0 THEN eit.typeId ELSE 0 END AS 'imbuedTypeId'
	FROM [content].[scriptableObjectSpawnables] sos
	JOIN [content].[globalObjects] glo ON sos.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	JOIN [content].[scriptableWorldObjects] swo ON sos.globalObject = swo.globalObject
	JOIN [content].[worldObjectTypes] wot ON swo.worldObjectTypeId = wot.typeId
	LEFT JOIN [content].[scriptableContainers] sc ON sos.globalObject = sc.globalObject
	LEFT JOIN [content].[containerTypes] ct ON sc.containerMainTypeId = ct.typeId
	LEFT JOIN [content].[scriptableContainersVariations] scv ON sos.variationId = scv.variationId AND sc.containerMainTypeId = scv.containerTypeId
	LEFT JOIN [content].[containerImbuedTypes] cit ON scv.containerImbuedTypeId = cit.typeId
	LEFT JOIN [content].[scriptableGatherables] sg ON sos.globalObject = sg.globalObject
	LEFT JOIN [content].[gatherableTypes] gt ON sg.gatherableTypeId = gt.typeId
	LEFT JOIN [content].[scriptableGatherablesVariations] sgv ON sos.variationId = sgv.variationId AND sg.gatherableTypeId = sgv.gatherableTypeId
	LEFT JOIN [content].[gatherableImbuedTypes] git ON sgv.gatherableImbuedTypeId = git.typeId
	LEFT JOIN [content].[scriptableEntities] se ON sos.globalObject = se.globalObject
	LEFT JOIN [content].[scriptableEntitiesVariations] sev ON sos.variationId = sev.variationId AND se.entityTypeId = sev.entityTypeId
	LEFT JOIN [content].[entityImbuedTypes] eit ON sev.entityImbuedTypeId = eit.typeId

GO

