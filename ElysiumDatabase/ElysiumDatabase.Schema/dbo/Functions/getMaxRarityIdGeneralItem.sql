CREATE FUNCTION [dbo].[getMaxRarityIdGeneralItem](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @maxRarityId TINYINT
	DECLARE @maxRarity VARCHAR(255)
	DECLARE @generalItemTypeId TINYINT
	DECLARE @generalItemClassificationTypeId TINYINT
	DECLARE @generalItemSubTypeId TINYINT

	SET @maxRarityId = 0;

	SELECT @generalItemTypeId = generalItemMainTypeId, @generalItemClassificationTypeId = generalItemClassificationTypeId, @generalItemSubTypeId = generalItemSubTypeId
	FROM [content].[scriptableGeneralItems] 
	WHERE globalObject = @globalObject

	IF @generalItemSubTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[generalItemSubTypes]
			WHERE typeId = @generalItemSubTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[generalItemSubTypes]
			WHERE typeId = @generalItemSubTypeId

	IF @generalItemClassificationTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[generalItemClassificationTypes]
			WHERE typeId = @generalItemClassificationTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[generalItemSubTypes]
			WHERE typeId = @generalItemSubTypeId

	IF @generalItemTypeId > 0 
		IF @isImbued  = 1
			SELECT @maxRarity = maxImbuedRarity
			FROM [content].[generalItemTypes]
			WHERE typeId = @generalItemTypeId
		ELSE
			SELECT @maxRarity = maxRarity
			FROM [content].[generalItemTypes]
			WHERE typeId = @generalItemTypeId

	SELECT @maxRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @maxRarity

    RETURN @maxRarityId
END

GO

