CREATE FUNCTION [dbo].[getWorldObjectClassificationTypeName](@globalObject VARCHAR(100))
RETURNS VARCHAR(100)
AS
BEGIN

	DECLARE @worldObjectClassificationTypeName VARCHAR(100)
	DECLARE @worldObjectTypeName VARCHAR(100)

	SET @worldObjectTypeName = dbo.getWorldObjectTypeNameFromGlobalObject(@globalObject);


	IF (@worldObjectTypeName = 'Entity') 
		SELECT @worldObjectClassificationTypeName = entityTypeName
		FROM [content].[scriptableEntities] se
		WHERE se.globalObject = @globalObject
	ELSE IF (@worldObjectTypeName = 'Interactable') 
		SELECT @worldObjectClassificationTypeName = interactableTypeName
		FROM [content].[scriptableInteractables] si
		WHERE si.globalObject = @globalObject
	ELSE IF (@worldObjectTypeName = 'Structure') 
		SELECT @worldObjectClassificationTypeName = typeName
		FROM [content].[scriptableStructures] si
		JOIN [content].[structureTypes] it ON si.structureTypeId = it.typeId
		WHERE si.globalObject = @globalObject
	
    RETURN @worldObjectClassificationTypeName
END

GO

