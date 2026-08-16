CREATE FUNCTION [dbo].[getQuestBoardTypeName](@typeId tinyint)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[questBoardTypes]
	WHERE typeId = @typeId

    RETURN @type
END

GO

