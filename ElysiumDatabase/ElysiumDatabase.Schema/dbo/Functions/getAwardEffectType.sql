CREATE FUNCTION [dbo].[getAwardEffectType](@awardEffectTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[awardEffectTypes]
	WHERE typeId = @awardEffectTypeId

    RETURN @type
END

GO

