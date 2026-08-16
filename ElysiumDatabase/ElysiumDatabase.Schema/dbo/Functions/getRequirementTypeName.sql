CREATE FUNCTION [dbo].[getRequirementTypeName](@typeId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[requirementTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

