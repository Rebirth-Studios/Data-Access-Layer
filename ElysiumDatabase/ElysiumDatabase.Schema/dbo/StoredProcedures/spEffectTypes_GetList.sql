
CREATE PROCEDURE [dbo].[spEffectTypes_GetList]
	
AS
BEGIN

	SELECT effectTypeId,effectType,effectTypeDescription
	FROM [content].[effectTypes]
	
END

GO

