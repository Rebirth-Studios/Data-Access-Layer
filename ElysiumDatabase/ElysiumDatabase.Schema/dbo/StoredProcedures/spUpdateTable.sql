
CREATE PROCEDURE [dbo].[spUpdateTable]
	@tableName varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT * FROM [ops].[lastUpdatedTables] WHERE lastUpdatedTable = @tableName)
		BEGIN
			INSERT INTO [ops].[lastUpdatedTables](lastUpdatedTable, lastUpdate)
			VALUES (@tableName, GETDATE())
		END
	ELSE
		BEGIN
			Update [ops].[lastUpdatedTables] SET lastUpdate = GETDATE()
		END
	RETURN 0
END

GO

