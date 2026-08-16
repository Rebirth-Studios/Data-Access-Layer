CREATE FUNCTION [dbo].[getIconNameFromIconPath](@iconPath VARCHAR(100))
RETURNS varchar(1000)
AS
BEGIN
    DECLARE @iconName varchar(255)
	
	SELECT @iconName = si.iconName
	FROM [content].[scriptableIcons] si
	WHERE iconPath = @iconPath

    RETURN @iconName
END

GO

