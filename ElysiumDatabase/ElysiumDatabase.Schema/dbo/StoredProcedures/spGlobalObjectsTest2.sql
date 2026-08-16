


CREATE PROCEDURE [dbo].[spGlobalObjectsTest2]
	
AS

	SELECT TOP 10 glo.globalObjectCode, 
	glo.globalObject, 
	glo.globalObjectName, 
	glo.globalObjectNamePlural, 
	glo.globalObjectTypeId, 
	glo.globalObjectSubTypeId, 
	glo.scriptableObjectTypeId,
	glo.globalTierId,
	glo.statusId,
	glo.specialEventTypeId,
	glo.globalSubTierId,
	got.typeName AS 'globalObjectType', 
	gbt.typeName AS 'globalObjectSubType', 
	sot.typeName AS 'scriptableObjectType', 
	gt.typeName AS 'globalTier', 
	gs.typeName AS 'status', 
	spt.typeName AS 'specialEventType', 
	gst.typeName AS 'globalSubTier',
	glo.customName
	FROM [content].[globalObjects] glo
	JOIN [content].[globalObjectTypes] got ON glo.globalObjectTypeId = got.typeId
	JOIN [content].[globalObjectSubTypes] gbt ON glo.globalObjectSubTypeId = gbt.typeId
	JOIN [content].[scriptableObjectTypes] sot ON glo.scriptableObjectTypeId = sot.typeId
	JOIN [content].[globalTiers] gt ON glo.globalTierId = gt.typeId
	JOIN [content].[globalStatuses] gs ON glo.statusId = gs.typeId
	JOIN [content].[specialEventTypes] spt ON glo.specialEventTypeId = spt.typeId
	JOIN [content].[globalSubTiers] gst ON glo.globalSubTierId = gst.typeId

GO

