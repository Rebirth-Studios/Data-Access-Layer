
CREATE PROCEDURE [dbo].[spScriptableItems_RecipeRequirementsGetList]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT sIR.globalObjectCode, sIR.requiredTypeId, sIRR.requiredRecipeGlobalObjectCode
	FROM scriptableItemRequirements sIR
	INNER JOIN scriptableItemRequirementsRecipe sIRR ON sIR.globalObjectCode = sIRR.globalObjectCode
	ORDER BY sIR.globalObjectCode
	RETURN 0
END

GO

