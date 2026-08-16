
CREATE FUNCTION [dbo].[getStatExperience](@scriptableObjectSpawnable varchar(100))
RETURNS Decimal(18,2)
AS
BEGIN
    DECLARE @statTotal Decimal(18,2)
	DECLARE @statId tinyint
	DECLARE @statTypeId tinyint

	SELECT @statId = statId, @statTypeId = statTypeId
	FROM [content].[stats]
	WHERE statName = 'Experience'

	SELECT @statTotal = statTotal
	FROM [content].[entityStats]
	WHERE statId = @statId AND statTypeId = @statTypeId AND scriptableObjectSpawnable = @scriptableObjectSpawnable

    RETURN @statTotal
END

GO

