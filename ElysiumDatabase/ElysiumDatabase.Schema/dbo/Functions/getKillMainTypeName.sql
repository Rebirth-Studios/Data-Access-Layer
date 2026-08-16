

CREATE FUNCTION [dbo].[getKillMainTypeName](@entityTypeId tinyint, @typeId tinyint)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)
	DECLARE @entityTypeName VARCHAR(255)

	SET @entityTypeName = ([dbo].[getEntityTypeName](@entityTypeId))

	IF @entityTypeName = 'Animal'
		SELECT @type = typeName
		FROM [content].[animalTypes]
		WHERE typeId = @typeId
	ELSE IF @entityTypeName = 'Enemy Humanoid'
		SELECT @type = typeName
		FROM [content].[enemyHumanoidTypes]
		WHERE typeId = @typeId
	ELSE IF @entityTypeName = 'Monster'
		SELECT @type = typeName
		FROM [content].[monsterTypes]
		WHERE typeId = @typeId
	ELSE IF @entityTypeName = 'NPC'
		SET @type = 'NPC'
	ELSE IF @entityTypeName = 'PC'
		SET @type = 'PC'
	ELSE IF @entityTypeName = 'None'
		SET @type = 'None'
		
    RETURN @type
END

GO

