
CREATE VIEW [dbo].[gatherableTypesView] AS 
	
	--FOR NONE RECORDS
	SELECT 
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		0 AS 'mainTypeId', 
		'None' AS 'mainType', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		0 AS 'mainTypeExperienceMultiplierPlayer', 
		0 AS 'classificationTypeExperienceMultiplierPlayer', 
		0 AS 'subTypeExperienceMultiplierPlayer', 
		0 AS 'experienceMultiplierPlayer',
		0 AS 'mainTypeExperienceMultiplierSkill',
		0 AS 'classificationTypeExperienceMultiplierSkill',
		0 AS 'subTypeExperienceMultiplierSkill',
		0 AS 'experienceMultiplierSkill'
		FROM [content].[interactableTypes] it
		--JOIN [content].[gatherableTypes] gt ON it.typeId = gt.parentTypeId
		--LEFT JOIN [content].[gatherableClassificationTypes] gct ON gt.typeId = gct.parentTypeId
		--LEFT JOIN [content].[gatherableSubTypes] gst ON gct.typeId = gst.parentTypeId
	WHERE it.type = 'Gatherable'

	UNION

	--FOR RECORDS WITH ONLY MAIN TYPE SET
	SELECT 
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		gt.typeId AS 'mainTypeId', 
		gt.type AS 'mainType', 
		0 AS 'classificationTypeId', 
		'None' AS 'classificationType', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		COALESCE(gt.experienceMultiplierPlayer, 0) AS 'mainTypeExperienceMultiplierPlayer', 
		0 AS 'classificationTypeExperienceMultiplierPlayer', 
		0 AS 'subTypeExperienceMultiplierPlayer', 
		gt.experienceMultiplierPlayer AS 'experienceMultiplierPlayer',
		COALESCE(gt.experienceMultiplierSkill, 0) AS 'mainTypeExperienceMultiplierSkill',
		0 AS 'classificationTypeExperienceMultiplierSkill',
		0 AS 'subTypeExperienceMultiplierSkill',
		gt.experienceMultiplierSkill AS 'experienceMultiplierSkill'
		FROM [content].[interactableTypes] it
		JOIN [content].[gatherableTypes] gt ON it.typeId = gt.parentTypeId
		--LEFT JOIN [content].[gatherableClassificationTypes] gct ON gt.typeId = gct.parentTypeId
		--LEFT JOIN [content].[gatherableSubTypes] gst ON gct.typeId = gst.parentTypeId
	WHERE it.type = 'Gatherable'

	UNION

	--FOR RECORDS WITH ONLY MAIN TYPE AND CLASSIFIED TYPE SET
	SELECT 
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		gt.typeId AS 'mainTypeId', 
		gt.type AS 'mainType', 
		COALESCE(gct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(gct.type, 'None') AS 'classificationType', 
		0 AS 'subTypeId', 
		'None' AS 'subType',
		COALESCE(gt.experienceMultiplierPlayer, 0) AS 'mainTypeExperienceMultiplierPlayer', 
		COALESCE(gct.experienceMultiplierPlayer, 0) AS 'classificationTypeExperienceMultiplierPlayer', 
		0 AS 'subTypeExperienceMultiplierPlayer', 
		(case when gct.experienceMultiplierPlayer > (0) then gct.experienceMultiplierPlayer else gt.experienceMultiplierPlayer end) AS 'experienceMultiplierPlayer',
		COALESCE(gt.experienceMultiplierSkill, 0) AS 'mainTypeExperienceMultiplierSkill',
		COALESCE(gct.experienceMultiplierSkill, 0) AS 'classificationTypeExperienceMultiplierSkill',
		0 AS 'subTypeExperienceMultiplierSkill',
		(case when gct.experienceMultiplierSkill > (0) then gct.experienceMultiplierSkill else gt.experienceMultiplierSkill end) AS 'experienceMultiplierSkill'
		FROM [content].[interactableTypes] it
		JOIN [content].[gatherableTypes] gt ON it.typeId = gt.parentTypeId
		LEFT JOIN [content].[gatherableClassificationTypes] gct ON gt.typeId = gct.parentTypeId
		--LEFT JOIN [content].[gatherableSubTypes] gst ON gct.typeId = gst.parentTypeId
	WHERE it.type = 'Gatherable'

	UNION

	--FOR RECORDS WITH MAIN TYPE AND CLASSIFIED TYPE AND SUB TYPE SET
	SELECT 
		it.typeId AS 'parentTypeId', 
		it.type AS 'parentType', 
		gt.typeId AS 'mainTypeId', 
		gt.type AS 'mainType', 
		COALESCE(gct.typeId, 0) AS 'classificationTypeId', 
		COALESCE(gct.type, 'None') AS 'classificationType', 
		COALESCE(gst.typeId, 0) AS 'subTypeId', 
		COALESCE(gst.type, 'None') AS 'subType',
		COALESCE(gt.experienceMultiplierPlayer, 0) AS 'mainTypeExperienceMultiplierPlayer', 
		COALESCE(gct.experienceMultiplierPlayer, 0) AS 'classificationTypeExperienceMultiplierPlayer', 
		COALESCE(gst.experienceMultiplierPlayer, 0) AS 'subTypeExperienceMultiplierPlayer', 
		(case when gst.experienceMultiplierPlayer >(0) then gst.experienceMultiplierPlayer when gct.experienceMultiplierPlayer > (0) then gct.experienceMultiplierPlayer else gt.experienceMultiplierPlayer end) AS 'experienceMultiplierPlayer',
		COALESCE(gt.experienceMultiplierSkill, 0) AS 'mainTypeExperienceMultiplierSkill',
		COALESCE(gct.experienceMultiplierSkill, 0) AS 'classificationTypeExperienceMultiplierSkill',
		COALESCE(gst.experienceMultiplierSkill, 0) AS 'subTypeExperienceMultiplierSkill',
		(case when gst.experienceMultiplierSkill >(0) then gst.experienceMultiplierSkill when gct.experienceMultiplierSkill > (0) then gct.experienceMultiplierSkill else gt.experienceMultiplierSkill end) AS 'experienceMultiplierSkill'
		FROM [content].[interactableTypes] it
		JOIN [content].[gatherableTypes] gt ON it.typeId = gt.parentTypeId
		LEFT JOIN [content].[gatherableClassificationTypes] gct ON gt.typeId = gct.parentTypeId
		LEFT JOIN [content].[gatherableSubTypes] gst ON gct.typeId = gst.parentTypeId
	WHERE it.type = 'Gatherable'

GO

