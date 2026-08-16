
CREATE FUNCTION [dbo].[getPanelNameFromConfig](@tableName VARCHAR(100))
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @panelName VARCHAR(100)
	
	SET @panelName = 'None'

	SELECT @panelName = panelName
	FROM [ops].[_configDetailsTablesData]
	WHERE tableName = @tableName
	
    RETURN @panelName
END

GO

