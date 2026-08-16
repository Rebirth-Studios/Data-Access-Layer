CREATE PROCEDURE [dbo].[RestoreConfigDetailsColumnsDataTables]
   @_configDetailsColumnsDataTablesDtl dbo.tmpRestore_configDetailsColumnsDataTables READONLY
AS 
BEGIN
   SET NOCOUNT ON 

   INSERT INTO [ops].[_configDetailsColumnsDataTables](id, tableName, columnName, columnId, columnType, dataType, propertyName, webControlName, webControlType, dontUpdateGoogle, defaultValue, defaultValueType, dropDownSource, dropDownFilter, dropDownSourceType, doNotLoad, gridViewName, overrideValue)
   SELECT id, tableName, columnName, columnId, columnType, dataType, propertyName, webControlName, webControlType, dontUpdateGoogle, defaultValue, defaultValueType, dropDownSource, dropDownFilter, dropDownSourceType, doNotLoad, gridViewName, overrideValue FROM @_configDetailsColumnsDataTablesDtl
END

GO

