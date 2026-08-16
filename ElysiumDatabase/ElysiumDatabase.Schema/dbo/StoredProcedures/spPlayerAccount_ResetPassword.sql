
CREATE procedure [dbo].[spPlayerAccount_ResetPassword] (
	@userName varchar(255),
	@password varchar(255),
	@playerAccountId int OUTPUT,
	@errMessage varchar(1000) output,
    @errParameters varchar(MAX) output,
    @errCustomMessage varchar(1000) output
) as
begin;
  
	BEGIN TRY
	  UPDATE [identity].[playersAccounts] SET password = @password
	  WHERE userName = @userName
	  

	  IF (@@ROWCOUNT > 0)
		BEGIN
		SELECT @playerAccountId = playerAccountId
			FROM [identity].[playersAccounts]
			WHERE userName = @userName
			AND password = @password
		END
		ELSE 
		BEGIN
			SET @playerAccountId = -1
		END
	  
	--PRINT @playerAccountId
	END TRY

	BEGIN CATCH
			SET @errMessage = ERROR_MESSAGE()
			SET @errParameters =   CONCAT_WS(',','@userName - ', @userName,
			'  @password - ', @password)

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
		   @errParameters);
	END CATCH

end;

GO

