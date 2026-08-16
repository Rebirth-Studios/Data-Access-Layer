CREATE FUNCTION [dbo].[getMonsterSubTypeName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[monsterSubTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

