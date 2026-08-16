
CREATE FUNCTION [dbo].[getParentControlNameFromConfig](@tableName VARCHAR(100), @webControlName VARCHAR(100))
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @parentControlName VARCHAR(100)
	
	SET @parentControlName = 'None'

	SELECT @parentControlName = webControlName
	FROM [ops].[_configDetailsColumnsDataTables]
	WHERE childControlTableName = @tableName AND childControlName = @webControlName
	
    RETURN @parentControlName
END

GO

