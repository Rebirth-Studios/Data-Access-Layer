
CREATE procedure [dbo].[spPlayerAccount_Create2] (
    @steamId varchar(255),
	@username varchar(255),
	@password varchar(255),
	@playerAccountId int output
) as
begin;
  
    Insert into [identity].[playersAccounts] (steamId, steamName, userName, password, emailAddress, Salt, LastIpAddressOnLogin, LastLoginTime)
	VALUES (@steamId, @username, @username, @password, @username,'Salt','192.168.1.1',GETDATE())

    select @playerAccountId = convert(int,scope_identity());
end;

GO

