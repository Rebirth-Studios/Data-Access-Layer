
CREATE PROCEDURE [dbo].[spScriptableItems_CharacterLevelRequirementsGetList]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT sIR.globalObjectCode, sIR.requiredTypeId, sIRL.characterLevel
	FROM scriptableItemRequirements sIR
	INNER JOIN scriptableItemRequirementsLevel sIRL ON sIR.globalObjectCode = sIRL.globalObjectCode
	ORDER BY sIR.globalObjectCode
	RETURN 0
END

GO

