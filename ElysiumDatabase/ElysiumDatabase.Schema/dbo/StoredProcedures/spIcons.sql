


CREATE PROCEDURE [dbo].[spIcons]
	
AS
	SELECT 
	ic.rarityId,
	ic.globalObject,
	ic.iconName,
	glo.globalObjectName,
	sr.typeName AS 'rarity',
	si.iconPath AS 'iconFilePath'
	FROM [content].[Icons] ic
	JOIN [content].[globalObjects] glo ON ic.globalObject = glo.globalObject
	JOIN [content].[scriptableRarities] sr ON ic.rarityId = sr.typeId
	JOIN [content].[scriptableIcons] si ON ic.iconName = si.iconName

GO

