CREATE PROCEDURE ViewAddSchemaBinding
    @ViewName VARCHAR(MAX)
AS
BEGIN
    DECLARE @PositionShemaBinding INT
    DECLARE @Command NVARCHAR(MAX)
    DECLARE @ObjectName VARCHAR(MAX)

    SELECT  @Command = OBJECT_DEFINITION(OBJECT_ID(@ViewName)),
            @ObjectName = OBJECT_NAME(OBJECT_ID(@ViewName));

    SET @PositionShemaBinding = PATINDEX('%WITH SCHEMABINDING%', @Command)

    IF @PositionShemaBinding = 0 BEGIN
        -- WITH SCHEMA BINDING IS NOT PRESENT... Let's add it !
        SET @Command = REPLACE(@Command, 'CREATE VIEW', 'ALTER VIEW');

        -- IF OBJECT NAME IS INTO BRAKETS, We need to handle it
       IF NOT CHARINDEX('[' + @ObjectName + ']', @Command) = 0 BEGIN
           SET @ObjectName = '[' + @ObjectName + ']'
       END

       SET @Command = STUFF(@Command, CHARINDEX(@ObjectName, @Command), LEN(@ObjectName), @ObjectName + ' WITH SCHEMABINDING ');

        EXECUTE sp_executesql @Command
    END
END

GO

