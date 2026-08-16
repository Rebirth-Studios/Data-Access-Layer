
CREATE FUNCTION [dbo].[getBodyPartType](@bodyPartTypeId VARCHAR(255))
RETURNS VARCHAR(255) WITH SCHEMABINDING
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[bodyPartTypes]
	WHERE typeId = @bodyPartTypeId

    RETURN @type
END

GO

