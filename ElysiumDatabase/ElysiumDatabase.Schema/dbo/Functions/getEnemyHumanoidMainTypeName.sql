CREATE FUNCTION [dbo].[getEnemyHumanoidMainTypeName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[enemyHumanoidTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

