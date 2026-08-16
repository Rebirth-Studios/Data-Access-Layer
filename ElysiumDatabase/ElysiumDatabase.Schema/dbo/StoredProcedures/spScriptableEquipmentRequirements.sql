
CREATE PROCEDURE [dbo].[spScriptableEquipmentRequirements]
	
AS
	

SELECT
	ser.globalObject,
	ser.statTypeId,
	ser.statId,
	ser.requiredAmount,
	ser.equipmentRequirementDescription,
	glo.globalObjectName,
	sts.statName,
	sts.statTypeName,
	ser.equipmentRequirement,
	glo.globalObjectName + ' Requirement' AS 'equipmentRequirementName'
	FROM [content].[scriptableEquipmentRequirements] ser
	JOIN [content].[globalObjects] glo ON ser.globalObject = glo.globalObject
	JOIN [content].[stats] sts ON ser.statTypeId = sts.statTypeId AND ser.statId = sts.statId

GO

