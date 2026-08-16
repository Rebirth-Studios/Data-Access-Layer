CREATE FUNCTION [dbo].[getDungeonStructureTypeName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[dungeonStructureTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

