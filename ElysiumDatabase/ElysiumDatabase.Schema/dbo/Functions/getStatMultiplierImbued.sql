
CREATE FUNCTION [dbo].[getStatMultiplierImbued](@scriptableObjectSpawnable VARCHAR(100), @statId tinyint, @statTypeId tinyint)
RETURNS  DECIMAL (5,2)
AS
BEGIN
    DECLARE @multiplier DECIMAL (5,2)
	DECLARE @entityImbuedTypeId TINYINT
	
	SELECT @entityImbuedTypeId = entityImbuedTypeId
	FROM [content].[scriptableEntitiesSpawnable] ses
	JOIN [content].[scriptableEntitiesVariations] sev ON ses.variationId = sev.variationId AND ses.entityTypeId = sev.entityTypeId
	WHERE ses.scriptableObjectSpawnable = @scriptableObjectSpawnable

	SELECT @multiplier = multiplier
	FROM [content].[statsMultiplierImbuedType] seh
	WHERE statId = @statId AND statTypeId = @statTypeId AND entityImbuedTypeId = @entityImbuedTypeId
	
    RETURN @multiplier
END

GO

