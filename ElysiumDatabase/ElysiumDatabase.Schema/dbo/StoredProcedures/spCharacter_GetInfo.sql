CREATE PROCEDURE [dbo].[spCharacter_GetInfo]
	@spawnedWorldObjectId uniqueIdentifier
AS
BEGIN TRY

	SELECT cha.characterName, cha.characterTierId, cha.characterRankId, 
	cha.characterExperience, cha.characterFactionId, 
	sWO.coordinateX, sWO.coordinateY, sWO.coordinateZ, 
	sWO.chunk,sWO.rotationX, sWO.rotationY, sWO.rotationZ,
	cha.race, cha.gender, cha.face, cha.eyebrows, cha.hair, cha.facialHair,
    cha.skinColor, cha.eyeColor, cha.hairColor, cha.stubbleColor,
	cC.amount_Gold, cC.amount_Silver, cC.amount_Copper, cC.token_adventuring, 
	cC.token_crafting, cC.token_gathering

	FROM [runtime].[characters] cha 
	JOIN [runtime].[spawnedWorldObjects] sWO ON sWO.spawnedWorldObjectId = cha.spawnedWorldObjectId
	JOIN [runtime].[spawnedWorldObjectsCurrency] cC ON cC.spawnedWorldObjectId = cha.spawnedWorldObjectId
	WHERE cha.spawnedWorldObjectId = @spawnedWorldObjectId

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
   CONCAT('@spawnedWorldObjectId - ', @spawnedWorldObjectId));

 END CATCH

GO

