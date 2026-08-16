CREATE FUNCTION [dbo].[getEquipmentRequirementName](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
 
AS
BEGIN
    DECLARE @equipmentRequirementName VARCHAR(255)
	DECLARE @globalObjectName VARCHAR(255)

	SELECT @globalObjectName = gos.globalObjectName
	FROM [content].[globalObjects] gos
	WHERE gos.globalObject = @globalObject

	SET @equipmentRequirementName = @globalObjectName + ' Requirement' 

    RETURN @equipmentRequirementName
END

GO

