CREATE FUNCTION [dbo].[getTypeNameEntity](@globalObject varchar(100))
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @typeNameEntity VARCHAR(100)
	
	SELECT @typeNameEntity = se.entityTypeName
	FROM [content].[scriptableEntities] se
	JOIN [content].[entityTypes] et ON se.entityTypeId = et.typeId
	WHERE se.globalObject = @globalObject

    RETURN @typeNameEntity
END

GO

