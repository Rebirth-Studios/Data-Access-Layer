
CREATE FUNCTION [dbo].[getEquipmentRequirement](@globalObject VARCHAR(255))
RETURNS VARCHAR(255)
WITH SCHEMABINDING
AS
BEGIN
    DECLARE @equipmentRequirement VARCHAR(255)
	DECLARE @firstCharacterUpper VARCHAR(1)

	SET @firstCharacterUpper = UPPER(SUBSTRING(@globalObject, 1, 1));


	SET @equipmentRequirement = 'requirement' + @firstCharacterUpper + SUBSTRING(@globalObject, 2, 255);

    RETURN @equipmentRequirement
END

GO

