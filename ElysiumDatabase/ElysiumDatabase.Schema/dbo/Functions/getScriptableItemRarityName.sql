CREATE FUNCTION [dbo].[getScriptableItemRarityName](@globalObject VARCHAR(255), @rarityId TINYINT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @scriptableItemRarityName VARCHAR(255)
	DECLARE @globalObjectName VARCHAR(255)
	DECLARE @rarityName VARCHAR(255)

	SELECT @globalObjectName = globalObjectName
	FROM [content].[globalObjects]
	WHERE globalObject = @globalObject

	SELECT @rarityName = typeName
	FROM [content].[scriptableRarities]
	WHERE typeId = @rarityId

	SET @scriptableItemRarityName = @globalObjectName + ' ' + @rarityName;

    RETURN @scriptableItemRarityName
END

GO

