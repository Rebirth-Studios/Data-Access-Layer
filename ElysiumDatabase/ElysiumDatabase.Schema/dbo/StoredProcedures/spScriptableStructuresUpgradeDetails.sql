

CREATE PROCEDURE [dbo].[spScriptableStructuresUpgradeDetails]
	
AS
	SELECT 
	ss.id,
	ss.globalObject,
	ss.minVillageTierId,
	ss.upgradeStructureGlobalObject,
	glo.globalObjectName, 
	glo2.globalObjectName AS 'upgradeStructureName',
	gt.typeName AS 'minVillageTier'
	FROM [content].[scriptableStructuresUpgradeDetails] ss
	JOIN [content].[globalObjects] glo ON ss.globalObject = glo.globalObject
	JOIN [content].[globalObjects] glo2 ON ss.upgradeStructureGlobalObject = glo2.globalObject
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId

GO

