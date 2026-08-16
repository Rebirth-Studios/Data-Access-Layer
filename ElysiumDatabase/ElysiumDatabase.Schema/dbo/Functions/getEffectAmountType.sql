
CREATE FUNCTION [dbo].[getEffectAmountType](@effectAmountTypeId VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = typeName
	FROM [content].[effectAmountTypes]
	WHERE typeId = @effectAmountTypeId

    RETURN @type
END

GO

