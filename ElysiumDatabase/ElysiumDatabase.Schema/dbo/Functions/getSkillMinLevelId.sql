CREATE FUNCTION [dbo].[getSkillMinLevelId](@skillRankId TINYINT)
RETURNS  SMALLINT
AS
BEGIN
	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @skillMinLevelId SMALLINT
	
	SELECT @skillMinLevelId  = minLevel
	FROM [content].[skillRanks]
	WHERE skillRankId = @skillRankId

    RETURN @skillMinLevelId
END

GO

