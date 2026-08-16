
CREATE PROCEDURE [dbo].[spScriptableItems_SkillRequirementsGetList]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT sIR.globalObjectCode, sIR.requiredTypeId, sIRS.requiredSkillGlobalObjectCode, sIRS.requiredSkillLevel
	FROM scriptableItemRequirements sIR
	INNER JOIN scriptableItemRequirementsSkill sIRS ON sIR.globalObjectCode = sIRS.globalObjectCode
	ORDER BY sIR.globalObjectCode
	RETURN 0
END

GO

