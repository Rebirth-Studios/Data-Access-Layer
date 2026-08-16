CREATE FUNCTION [dbo].[isItemImbued](@globalObject VARCHAR(100))
RETURNS BIT
AS
BEGIN
	DECLARE @isItemImbued BIT
	
	SELECT @isItemImbued = isImbued
	FROM [content].[scriptableItems] 
	WHERE globalObject = @globalObject

    RETURN @isItemImbued
END

GO

