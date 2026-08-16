





CREATE PROCEDURE [dbo].[spCharacter_AttributePointsGetAll]
	
AS
BEGIN TRY
	SET NOCOUNT ON;

	Select attributePointsId, tierId, rankId, attributePointsValue  FROM [content].[attributePoints] 
	RETURN 0
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

