CREATE FUNCTION [dbo].[IsValidConfigChildControlName] (
     @childControlTableName VARCHAR(100),
    @childControlName VARCHAR(100)
)
RETURNS BIT
AS
BEGIN
    IF @childControlName = 'None'
        RETURN 1; -- 'None' is valid

    IF EXISTS (
        SELECT 1
        FROM [ops].[_configDetailsColumnsDataTables]
        WHERE tableName = @childControlTableName
          AND webControlName = @childControlName
    )
        RETURN 1; -- Valid if childControlName, childControlTableName exists as tableName, webControlName

    RETURN 0; -- Invalid otherwise
END;

GO

