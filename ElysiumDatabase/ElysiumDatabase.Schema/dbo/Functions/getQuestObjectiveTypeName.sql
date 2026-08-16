

CREATE FUNCTION [dbo].[getQuestObjectiveTypeName](@typeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[questObjectiveTypes]
	WHERE  typeId = @typeId

    RETURN @type
END

GO

