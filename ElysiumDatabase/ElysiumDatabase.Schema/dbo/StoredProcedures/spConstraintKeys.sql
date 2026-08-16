


CREATE PROCEDURE [dbo].[spConstraintKeys]
	@constraintName VARCHAR(255), @tableName VARCHAR(255)
AS

	BEGIN
		SELECT 
			fk.name AS ConstraintName,
			OBJECT_NAME(fk.parent_object_id) AS TableName,
			COL_NAME(fkc.parent_object_id, fkc.parent_column_id) AS ColumnName,
			OBJECT_NAME(fk.referenced_object_id) AS ReferencedTableName,
			COL_NAME(fkc.referenced_object_id, fkc.referenced_column_id) AS ReferencedColumnName,
			fkc.constraint_column_id AS ColumnPosition
		FROM 
			sys.foreign_keys fk
			INNER JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
		WHERE 
			 OBJECT_NAME(fk.parent_object_id) = @tableName  -- Optional: Filter by child table
			AND fk.name = @constraintName  -- Optional: Filter by constraint name
		ORDER BY 
			fk.name, fkc.constraint_column_id;
END

GO

