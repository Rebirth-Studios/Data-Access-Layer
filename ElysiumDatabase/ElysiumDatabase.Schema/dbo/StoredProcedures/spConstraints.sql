


CREATE PROCEDURE [dbo].[spConstraints]
	@columnName VARCHAR(255), @tableName VARCHAR(255)
AS

	BEGIN
		SELECT
			fk.name AS ForeignKeyName,
			parent_table.name AS TableName,
			parent_column.name AS ColumnName,
			referenced_table.name AS ReferencedTableName,
			referenced_column.name AS ReferencedColumnName
	FROM
		sys.foreign_keys AS fk
	INNER JOIN
		sys.foreign_key_columns AS fk_columns ON fk.object_id = fk_columns.constraint_object_id
	INNER JOIN
		sys.tables AS parent_table ON fk.parent_object_id = parent_table.object_id
	INNER JOIN
		sys.columns AS parent_column ON fk_columns.parent_column_id = parent_column.column_id 
		AND fk_columns.parent_object_id = parent_column.object_id
	INNER JOIN
		sys.tables AS referenced_table ON fk.referenced_object_id = referenced_table.object_id
	INNER JOIN
		sys.columns AS referenced_column ON fk_columns.referenced_column_id = referenced_column.column_id 
		AND fk_columns.referenced_object_id = referenced_column.object_id
	WHERE
		parent_table.name = @tableName
		AND parent_column.name = @columnName;
END

GO

