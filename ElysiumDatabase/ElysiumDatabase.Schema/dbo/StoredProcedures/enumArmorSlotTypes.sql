
CREATE PROCEDURE [dbo].[enumArmorSlotTypes]
	
AS
BEGIN TRY

	SELECT aST.typeId as 'locationId', aST.type as 'location'
	FROM [content].[armorSlotTypes] aST
	ORDER BY typeId

END TRY
BEGIN CATCH

	INSERT INTO [ops].[DB_Errors]
    VALUES
	(SUSER_SNAME(),
   ERROR_NUMBER(),
   ERROR_STATE(),
   ERROR_SEVERITY(),
   ERROR_LINE(),
   ERROR_PROCEDURE(),
   ERROR_MESSAGE(),
   GETDATE(),
   'N/A');

 END CATCH

GO

