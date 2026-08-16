CREATE FUNCTION [dbo].[getIsImbuedFromScriptableItems](@globalObject VARCHAR(100))
RETURNS BIT
AS
BEGIN
	DECLARE @isItemImbued BIT
	
	SELECT @isItemImbued = isImbued
	FROM [content].[scriptableItems] si
	WHERE globalObject = @globalObject

    RETURN @isItemImbued
END

GO

