
CREATE PROCEDURE [dbo].[spEffectAmountTypes_GetList]
	
AS
BEGIN

	SELECT effectAmountTypeId,effectAmountType
	FROM [content].[effectAmountTypes]
	
END

GO

