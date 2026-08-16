




-- =============================================
-- Author: Eric Ingram
-- Create date: 02/25/2022
-- Updated 03/09/2022 - changed to using @spawnedWorldObjectId from characterId
-- Description: Used to send, receive, accept, reject request or block character
-- =============================================
CREATE procedure [dbo].[spCharacter_SocialAction]
    @spawnedWorldObjectId uniqueIdentifier,
	@socialCharacterId int,
	@socialTypeId int,
	@logging int = 0,
	@errMessage varchar(1000) output,
	@errParameters varchar(MAX) output,
	@errCustomMessage varchar(1000) output
AS 
DECLARE 
	@insertCharactersSocialCount int,
	@selectCharactersSocialCount int,
	@updateCharactersSocialCount int,
	@characterId int
BEGIN TRY 
	SET @errParameters = CONCAT_WS(',','@characterId - ', @characterId, 
	 '  @socialCharacterId - ', @socialCharacterId, 
	 '  @socialTypeId - ', @socialTypeId, 
	 '  @logging - ', @logging);

	 --GET CHARACTER ID
	SELECT @characterId = characterId
	FROM [runtime].[characters] ch
	JOIN [runtime].[spawnedWorldObjects] sWO ON ch.spawnedWorldObjectId = sWO.spawnedWorldObjectId
	WHERE ch.spawnedWorldObjectId = @spawnedWorldObjectId


	 --CHECK IF social relationship exists
	SELECT characterSocialId
	FROM [runtime].[charactersSocial] cS
	WHERE cS.characterId = @characterId AND cS.socialCharacterId = @socialTypeId
	SET @selectCharactersSocialCount = @@rowcount
	
	
	IF (@socialTypeId = 0) --SENT FRIEND REQUEST
	BEGIN
		IF (@selectCharactersSocialCount = 0)
		BEGIN
			insert into [runtime].[charactersSocial](characterId, socialCharacterId, socialTypeId, lastActionDate)
			VALUES (@characterId, @socialCharacterId, @socialTypeId,  GETDATE())  
			SET @insertCharactersSocialCount = @@rowcount
		END
		IF (@selectCharactersSocialCount = 1)
		BEGIN
			Update [runtime].[charactersSocial] Set socialTypeId = @socialTypeId, lastActionDate = GETDATE()
			WHERE characterId = @characterId AND socialCharacterId = @socialTypeId
			SET @updateCharactersSocialCount = @@rowcount
		END
	END

	IF (@socialTypeId = 1) --RECEIVED FRIEND REQUEST
	BEGIN
		IF (@selectCharactersSocialCount = 0)
		BEGIN
			insert into [runtime].[charactersSocial](characterId, socialCharacterId, socialTypeId, lastActionDate)
			VALUES (@characterId, @socialCharacterId, @socialTypeId,  GETDATE())  
			SET @insertCharactersSocialCount = @@rowcount
		END
		IF (@selectCharactersSocialCount = 1)
		BEGIN
			Update [runtime].[charactersSocial] Set socialTypeId = @socialTypeId, lastActionDate = GETDATE()
			WHERE characterId = @characterId AND socialCharacterId = @socialTypeId
			SET @updateCharactersSocialCount = @@rowcount
		END
	END

	IF (@socialTypeId = 2) --APPROVED FRIEND REQUEST
	BEGIN
		IF (@selectCharactersSocialCount = 0)
		BEGIN
			insert into [runtime].[charactersSocial](characterId, socialCharacterId, socialTypeId, lastActionDate)
			VALUES (@characterId, @socialCharacterId, @socialTypeId,  GETDATE())  
			SET @insertCharactersSocialCount = @@rowcount
		END
		IF (@selectCharactersSocialCount = 1)
		BEGIN
			Update [runtime].[charactersSocial] Set socialTypeId = @socialTypeId, lastActionDate = GETDATE()
			WHERE characterId = @characterId AND socialCharacterId = @socialTypeId
			SET @updateCharactersSocialCount = @@rowcount
		END
	END

	IF (@socialTypeId = 3) --BLOCKED
	BEGIN
		IF (@selectCharactersSocialCount = 0)
		BEGIN
			insert into [runtime].[charactersSocial](characterId, socialCharacterId, socialTypeId, lastActionDate)
			VALUES (@characterId, @socialCharacterId, @socialTypeId,  GETDATE())  
			SET @insertCharactersSocialCount = @@rowcount
		END
		IF (@selectCharactersSocialCount = 1)
		BEGIN
			Update [runtime].[charactersSocial] Set socialTypeId = @socialTypeId, lastActionDate = GETDATE()
			WHERE characterId = @characterId AND socialCharacterId = @socialTypeId
			SET @updateCharactersSocialCount = @@rowcount
		END
	END

	IF (@socialTypeId = 4) --REJECTED
	BEGIN
		IF (@selectCharactersSocialCount = 0)
		BEGIN
			insert into [runtime].[charactersSocial](characterId, socialCharacterId, socialTypeId, lastActionDate)
			VALUES (@characterId, @socialCharacterId, @socialTypeId,  GETDATE())  
			SET @insertCharactersSocialCount = @@rowcount
		END
		IF (@selectCharactersSocialCount = 1)
		BEGIN
			Update [runtime].[charactersSocial] Set socialTypeId = @socialTypeId, lastActionDate = GETDATE()
			WHERE characterId = @characterId AND socialCharacterId = @socialTypeId
			SET @updateCharactersSocialCount = @@rowcount
		END
	END

	--SET CUSTOM ERROR MESSAGE FOR DEBUGGING
	IF (@insertCharactersSocialCount = 0) AND (@updateCharactersSocialCount = 0) SET @errCustomMessage = 'NOTHING INSERTED OR UPDATED'
	

	--IF CUSTOM ERROR MESSAGE SET OR LOGGING ENABLED
	IF (@logging = 1) OR (@errCustomMessage IS NOT NULL)
	BEGIN
		INSERT INTO [ops].[DB_Errors]
		VALUES
		(SUSER_SNAME(),
		0,
		0,
		0,
		0,
		'spCharacter_InventoryAddItem',
		@errCustomMessage,
		GETDATE(),
		CONCAT_WS(',','  @errParameters - ', @errParameters, 
		'  @insertCharactersInventoryCount - ', @insertCharactersSocialCount,
		'  @selectCharactersSocialCount - ', @selectCharactersSocialCount,
		'  @updateCharactersSocialCount - ', @updateCharactersSocialCount))
	END
END TRY

BEGIN CATCH
	SET @errMessage = ERROR_MESSAGE()
	
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

GO

