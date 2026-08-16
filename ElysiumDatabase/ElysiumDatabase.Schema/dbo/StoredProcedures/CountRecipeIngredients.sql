CREATE PROCEDURE [dbo].[CountRecipeIngredients]  @RecordCount INT OUTPUT

AS 
BEGIN
   SET NOCOUNT ON 

   SELECT @RecordCount = COUNT(*) FROM recipeIngredients

END

GO

