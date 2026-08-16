CREATE FUNCTION [dbo].[getStatMultiplierLevel](@globalObject VARCHAR(100), @scriptableObjectSpawnable varchar(100))
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @multiplier DECIMAL(18,2)
	DECLARE @levelId tinyint

	SELECT @levelId = sol.levelId
	FROM [content].[scriptableObjectSpawnables] sos
	JOIN [content].[scriptableObjectLevels] sol ON sos.scriptableObjectLevel = sol.scriptableObjectLevel
	WHERE sos.globalObject = @globalObject AND sos.scriptableObjectSpawnable = @scriptableObjectSpawnable

	SELECT @multiplier = multiplier
	FROM [content].[statsBaseLevels]
	WHERE levelId = @levelId 

    RETURN @multiplier
END

GO

