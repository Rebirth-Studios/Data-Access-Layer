
CREATE FUNCTION [dbo].[getParentTableNameFromConfig](@tableName VARCHAR(100), @webControlName VARCHAR(100))
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @parentTableName VARCHAR(100)
	
	SET @parentTableName = 'None'

	SELECT @parentTableName = tableName
	FROM [ops].[_configDetailsColumnsDataTables]
	WHERE childControlTableName = @tableName AND childControlName = @webControlName
	
    RETURN @parentTableName
END

GO

