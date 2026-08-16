CREATE FUNCTION [dbo].[getStatBaseEntity](@globalObject varchar(100), @statId tinyint, @statTypeId tinyint)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @statInitialValue Decimal(18,2)
	
	SELECT @statInitialValue = sbt.statInitialValue 
	FROM [content].[globalObjects] glo
	JOIN [content].[statsBaseTiers] sbt ON glo.globalTierId = sbt.globalTierId
	WHERE glo.globalObject = @globalObject AND sbt.statId = @statId AND sbt.statTypeId = @statTypeId

    RETURN @statInitialValue
END

GO

