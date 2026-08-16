
CREATE FUNCTION [dbo].[getLootTableName](@scriptableObjectSpawnable VARCHAR(100))
RETURNS varchar(100)
AS
BEGIN
    DECLARE @lootTableName varchar(100)
	
	SELECT @lootTableName = sTLT.lootTableGlobalObjectName
	FROM [content].[spawnablesToLootTables] sTLT
	WHERE sTLT.scriptableObjectSpawnable = @scriptableObjectSpawnable

    RETURN @lootTableName
END

GO

