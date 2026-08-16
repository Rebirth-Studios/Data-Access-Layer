CREATE PROCEDURE [dbo].[CountEquipmentMaterialModifiers]  @RecordCount INT OUTPUT

AS 
BEGIN
   SET NOCOUNT ON 

   SELECT @RecordCount = COUNT(*) FROM [content].[equipmentMaterialModifiers]

END

GO

