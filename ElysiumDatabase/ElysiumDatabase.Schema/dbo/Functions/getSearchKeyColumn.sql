
CREATE FUNCTION [dbo].[getSearchKeyColumn](@tableName VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @type VARCHAR(255)

	SELECT @type = searchKeyColumn
	FROM [ops].[_configDetailsTablesData]
	WHERE tableName = @tableName

    RETURN @type
END

GO

