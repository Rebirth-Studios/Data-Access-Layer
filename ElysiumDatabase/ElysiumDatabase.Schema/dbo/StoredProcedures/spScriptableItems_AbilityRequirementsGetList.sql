
CREATE PROCEDURE [dbo].[spScriptableItems_AbilityRequirementsGetList]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT sIR.globalObjectCode, sIR.requiredTypeId, sIRA.requiredAbilityGlobalObjectCode
	FROM scriptableItemRequirements sIR
	INNER JOIN scriptableItemRequirementsAbility sIRA ON sIR.globalObjectCode = sIRA.globalObjectCode
	ORDER BY sIR.globalObjectCode
	RETURN 0
END

GO

