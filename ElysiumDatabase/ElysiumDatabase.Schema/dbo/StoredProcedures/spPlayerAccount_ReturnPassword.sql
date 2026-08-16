
CREATE procedure [dbo].[spPlayerAccount_ReturnPassword] (
	@userName varchar(255),
	@password varchar(255),
	@playerAccountId int OUTPUT
) as
begin;
  SELECT @playerAccountId = playerAccountId
  FROM [identity].[playersAccounts]
  WHERE userName = @userName
  AND password = @password
  
  IF @playerAccountId IS NULL
	SET @playerAccountId = -1
  --IF @playerAccountId = 0
	--SET @playerAccountId = -1
   --IF @playerAccountId = ''
    --SET @playerAccountId = -1

	RETURN @playerAccountId
--PRINT @playerAccountId
end;

GO

