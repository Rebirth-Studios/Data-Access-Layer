
CREATE PROCEDURE [dbo].[spDamageTypes_GetList]
	
AS
BEGIN

	SELECT damageTypeId, damageType
	FROM [content].[damageTypes]
	
END

GO

