CREATE PROCEDURE [dbo].[RestoreRecipeIngredients]
   @recipeIngredientsDtl dbo.tmpRestorerecipeIngredients READONLY
AS 
BEGIN
   SET NOCOUNT ON 

   INSERT INTO dbo.recipeIngredients(recipeIngredientId, globalObjectCode, ingredientSlotId, globalObjectName, ingredientGlobalObjectCode, ingredientName, ingredientWeight, quantity)
   SELECT recipeIngredientId, globalObjectCode, ingredientSlotId, globalObjectName, ingredientGlobalObjectCode, ingredientName, ingredientWeight, quantity FROM @recipeIngredientsDtl
END

GO

