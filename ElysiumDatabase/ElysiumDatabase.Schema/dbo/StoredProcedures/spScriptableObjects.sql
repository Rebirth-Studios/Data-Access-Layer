CREATE PROCEDURE [dbo].[spScriptableObjects]
	
AS
	

SELECT
	so.globalObject,
	so.scriptableObjectTypeId,
	glo.globalObjectName AS 'globalObjectName',
	st.typeName AS 'scriptableObjectTypeName',
	st.baseScriptableObjectPath AS 'scriptableObjectPath'
	FROM [content].[scriptableObjects] so
	JOIN [content].[globalObjects] glo ON so.globalObject = glo.globalObject
	JOIN [content].[scriptableObjectTypes] st ON so.scriptableObjectTypeId = st.typeId

GO

