
CREATE FUNCTION [dbo].[getSkillRankName](@rankId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @skillRankName VARCHAR(255)

	SELECT @skillRankName = typeName
	FROM [content].[skillRanks]
	WHERE typeId = @rankId

    RETURN @skillRankName
END

GO

