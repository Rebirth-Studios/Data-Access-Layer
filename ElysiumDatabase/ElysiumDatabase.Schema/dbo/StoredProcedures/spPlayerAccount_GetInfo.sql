
CREATE PROCEDURE [dbo].[spPlayerAccount_GetInfo]
	@steamId varchar(255),
	@playerAccountId  int output
AS
BEGIN
	--DECLARE @PlayerName varchar(255)
	SET NOCOUNT ON
	Select @playerAccountId = playerAccountId
	From [identity].[playersAccounts] Where steamId = @steamId
	--RETURN @playerAccountId
	RETURN 0
END

GO

