
CREATE PROCEDURE [dbo].[spScriptableItemRarities]
	
AS
	

SELECT
	sir.globalObject,
	sir.rarityId,
	(sir.globalObject + 'Rarity' + CONVERT(VARCHAR, sir.rarityId)) AS 'scriptableItemRarity',
	si.isImbued,
	glo.globalObjectName AS 'globalObjectName',
	sot.typeName AS 'scriptableObjectType',
	sr.typeName AS 'rarity',
	(glo.globalObjectName + ' ' + sr.typeName) AS 'scriptableItemRarityName',
	sir.description
	FROM [content].[scriptableItemRarities] sir
	JOIN [content].[globalObjects] glo ON sir.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectTypes] sot ON glo.scriptableObjectTypeId = sot.typeId
	JOIN [content].[scriptableItems] si ON sir.globalObject = si.globalObject
	JOIN [content].[scriptableRarities] sr ON sir.rarityId = sr.typeId

GO

