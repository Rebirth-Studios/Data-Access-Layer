
CREATE FUNCTION [dbo].[getEffectTypeFromEffects](@effectGlobalObject VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = effectType
	FROM [content].[effects]
	WHERE globalObject = @effectGlobalObject

    RETURN @type
END

GO

