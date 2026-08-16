

CREATE FUNCTION [dbo].[getContainerQuantityTypeName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = cqt.typeName
	FROM [content].[containerQuantityTypes] cqt
	WHERE cqt.typeId = @typeId

    RETURN @type
END

GO

