CREATE PROCEDURE ViewRemoveSchemaBinding
    @ViewName VARCHAR(MAX)
AS
BEGIN
    DECLARE @PositionShemaBinding INT
    DECLARE @Command NVARCHAR(MAX)

    SELECT @Command = OBJECT_DEFINITION(OBJECT_ID(@ViewName));
    SET @PositionShemaBinding = CHARINDEX('WITH SCHEMABINDING', @Command)

    IF NOT @PositionShemaBinding = 0 BEGIN
        -- WITH SCHEMA BINDING IS PRESENT... Let's remove it !
        SET @Command = STUFF(@Command, CHARINDEX('WITH SCHEMABINDING', @Command), LEN('WITH SCHEMABINDING'), '');
        SET @Command = REPLACE(@Command, 'CREATE VIEW', 'ALTER VIEW');

        EXECUTE sp_executesql @Command
    END
END

GO

