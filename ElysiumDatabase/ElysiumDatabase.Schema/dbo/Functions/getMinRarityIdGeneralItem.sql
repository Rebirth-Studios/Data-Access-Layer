CREATE FUNCTION [dbo].[getMinRarityIdGeneralItem](@globalObject VARCHAR(255), @isImbued BIT)
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @minRarityId TINYINT
	DECLARE @minRarity VARCHAR(255)
	DECLARE @generalItemTypeId TINYINT
	DECLARE @generalItemClassificationTypeId TINYINT
	DECLARE @generalItemSubTypeId TINYINT

	SET @minRarityId = 0;

	SELECT @generalItemTypeId = generalItemMainTypeId, @generalItemClassificationTypeId = generalItemClassificationTypeId, @generalItemSubTypeId = generalItemSubTypeId
	FROM [content].[scriptableGeneralItems] 
	WHERE globalObject = @globalObject

	IF @generalItemSubTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[generalItemSubTypes]
			WHERE typeId = @generalItemSubTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[generalItemSubTypes]
			WHERE typeId = @generalItemSubTypeId

	IF @generalItemClassificationTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[generalItemClassificationTypes]
			WHERE typeId = @generalItemClassificationTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[generalItemClassificationTypes]
			WHERE typeId = @generalItemClassificationTypeId

	IF @generalItemTypeId > 0 
		IF @isImbued  = 1
			SELECT @minRarity = minImbuedRarity
			FROM [content].[generalItemTypes]
			WHERE typeId = @generalItemTypeId
		ELSE
			SELECT @minRarity = minRarity
			FROM [content].[generalItemTypes]
			WHERE typeId = @generalItemTypeId

	SELECT @minRarityId = typeId
	FROM [content].[scriptableRarities]
	WHERE typeName = @minRarity

    RETURN @minRarityId
END

GO

