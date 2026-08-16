






CREATE PROCEDURE [dbo].[spCharacter_AttributePointsGetAmount]
	-- Add the parameters for the stored procedure here
	@tierId int,
	@rankId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	Select attributePointsId, attributePointsValue  FROM [content].[attributePoints] WHERE tierId = @tierId And rankId = @rankId
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

