CREATE PROCEDURE [dbo].[CountGameObjectTypes]  @RecordCount INT OUTPUT

AS 
BEGIN
   SET NOCOUNT ON 

   SELECT @RecordCount = COUNT(*) FROM [content].[gameObjectTypes]

END

GO

