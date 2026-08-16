


CREATE PROCEDURE [dbo].[spEquipmentRequirementGroups_GetList]
	
AS
BEGIN
	SELECT eRG.equipmentRequirementGroupId,eR.equipmentRequirementId, eR.equipmentRequirement ,sI.globalObjectCode, eRG.requiredAttributeId, eRA.requiredAttributeAmount, stats.stat, eRA.statId, sT.statType, eRA.statTypeId ,sO.scriptableObjectPath AS 'globalObjectPath'
	FROM [content].[scriptableEquipment] sE
	JOIN equipmentRequirements eR ON sE.globalObjectCode = eR.globalObjectCode
	JOIN [content].[scriptableItems] sI ON sE.globalObjectCode = sI.globalObjectCode
	JOIN [content].[scriptableObjects] sO ON sI.globalObjectCode = sO.globalObjectCode
	--JOIN [content].[globalObjects] gOb on sI.globalObjectCode = gOB.globalObjectCode
	JOIN [content].[equipmentRequirementGroups] eRG ON eR.equipmentRequirementId = eRG.equipmentRequirementId
	JOIN [content].[requiredAttributes] eRA ON eRG.requiredAttributeId = eRA.requiredAttributeId
	JOIN [content].[stats] on eRA.statId = stats.statId AND eRA.statTypeId = stats.statTypeId
	JOIN [content].[statTypes] sT on eRA.statTypeId = sT.statTypeId
END

GO

