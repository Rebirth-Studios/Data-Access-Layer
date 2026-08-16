
CREATE procedure [dbo].[spPlayerAccount_Create] (
    @steamId varchar(255),
	@steamName varchar(255),
	@userName varchar(255),
	@emailAddress varchar(255),
	@playerAccountId int output
) as
begin;
  
    Insert into [identity].[playersAccounts] (steamId, steamName, userName, password, emailAddress, Salt, LastIpAddressOnLogin, LastLoginTime)
	VALUES (@steamId, @steamName, @userName, 'testpassword', @emailAddress,'Salt','192.168.1.1',GETDATE())

    select @playerAccountId = convert(int,scope_identity());
end;

GO

