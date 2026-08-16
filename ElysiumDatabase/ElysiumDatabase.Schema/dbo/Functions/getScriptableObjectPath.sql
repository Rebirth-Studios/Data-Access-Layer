CREATE FUNCTION [dbo].[getScriptableObjectPath](@globalObject VARCHAR(255), @scriptableObjectTypeId TINYINT)
RETURNS VARCHAR(1000)
AS
BEGIN
    DECLARE @scriptableObjectPath VARCHAR(1000)
	DECLARE @globalObjectName VARCHAR(255)

	

	SELECT @scriptableObjectPath = baseScriptableObjectPath
	FROM [content].[scriptableObjectTypes]
	WHERE typeId = @scriptableObjectTypeId

	IF (@scriptableObjectPath is null or @scriptableObjectPath = '') SET @scriptableObjectPath = 'null'

	SET @scriptableObjectPath += '/' + @globalObject;

    RETURN @scriptableObjectPath
END

GO

