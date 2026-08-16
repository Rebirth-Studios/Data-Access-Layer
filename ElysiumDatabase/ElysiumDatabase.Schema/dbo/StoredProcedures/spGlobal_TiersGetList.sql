




CREATE PROCEDURE [dbo].[spGlobal_TiersGetList]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	SET NOCOUNT ON;

	Select * FROM [content].[globalTiers]
	
	RETURN 0
END

GO

