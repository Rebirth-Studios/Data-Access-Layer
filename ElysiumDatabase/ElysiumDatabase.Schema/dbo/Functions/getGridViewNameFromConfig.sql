CREATE FUNCTION [dbo].[getGridViewNameFromConfig](@tableName VARCHAR(100))
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @gridViewName VARCHAR(100)
	
	SET @gridViewName = 'None'

	SELECT @gridViewName = gridViewName
	FROM [ops].[_configDetailsTablesData]
	WHERE tableName = @tableName
	
    RETURN @gridViewName
END

GO

