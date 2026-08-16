CREATE FUNCTION [dbo].[getSkillRequiredBase](@globalObject VARCHAR(100))
RETURNS  SMALLINT
AS
BEGIN
	--SMALL INT NEEDED FOR NEGATIVE NUMBERS
	DECLARE @skillRequiredBase SMALLINT
	
	SELECT @skillRequiredBase  = minLevel
	FROM [content].[scriptableInteractables] si
	JOIN [content].[skillRanks] sr ON si.interactableRequiredSkillRankId = sr.typeId
	WHERE globalObject = @globalObject

    RETURN @skillRequiredBase
END

GO

