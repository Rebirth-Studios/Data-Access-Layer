CREATE PROCEDURE [dbo].[SaveRecipeIngredients]
   @recipeIngredientsDtl dbo.tmprecipeIngredients READONLY
AS 
BEGIN
   SET NOCOUNT ON 

   INSERT INTO dbo.recipeIngredients(globalObjectCode, ingredientSlotId, globalObjectName, ingredientGlobalObjectCode, ingredientName, ingredientWeight, quantity)
   SELECT globalObjectCode, ingredientSlotId, globalObjectName, ingredientGlobalObjectCode, ingredientName, ingredientWeight, quantity FROM @recipeIngredientsDtl
END

GO

