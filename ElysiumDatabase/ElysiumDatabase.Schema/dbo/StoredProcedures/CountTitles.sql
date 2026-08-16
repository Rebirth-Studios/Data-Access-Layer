CREATE PROCEDURE [dbo].[CountTitles]  @RecordCount INT OUTPUT

AS 
BEGIN
   SET NOCOUNT ON 

   SELECT @RecordCount = COUNT(*) FROM titles

END

GO

