

CREATE PROCEDURE [dbo].[spScriptableStructures]
	
AS
	SELECT 
	ss.id,
	ss.globalObject,
	ss.structureTypeId,
	ss.playerUpgradable,
	ss.autoUpgrades,
	ss.description, 
	glo.globalObjectName, 
	st.typeName AS 'structureTypeName',
	gt.typeName AS 'tierAvailable'
	FROM [content].[scriptableStructures] ss
	JOIN [content].[globalObjects] glo ON ss.globalObject = glo.globalObject
	JOIN [content].[structureTypes] st ON ss.structureTypeId = st.typeId
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId

GO

