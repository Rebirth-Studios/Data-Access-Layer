
CREATE FUNCTION [dbo].[getStatName](@stat VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @statName VARCHAR(255)

	SELECT @statName = st.typeName
	FROM [content].[statNames] st
	WHERE st.type = @stat 

    RETURN @statName
END

GO

