CREATE FUNCTION [dbo].[getExperienceEffectType](@experienceEffectTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[experienceEffectTypes]
	WHERE typeId = @experienceEffectTypeId

    RETURN @type
END

GO

