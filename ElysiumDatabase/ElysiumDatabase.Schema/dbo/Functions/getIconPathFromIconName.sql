
CREATE FUNCTION [dbo].[getIconPathFromIconName](@iconName VARCHAR(100))
RETURNS varchar(1000)
AS
BEGIN
    DECLARE @iconPath varchar(255)
	
	SELECT @iconPath = si.iconPath
	FROM [content].[scriptableIcons] si
	WHERE iconName = @iconName

    RETURN @iconPath
END

GO

