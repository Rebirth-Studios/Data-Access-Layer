CREATE TYPE [dbo].[tmpRestore_configDetailsColumnsDataTables] AS TABLE (
    [id]                 SMALLINT      NOT NULL,
    [tableName]          VARCHAR (100) NOT NULL,
    [columnName]         VARCHAR (100) NOT NULL,
    [columnId]           SMALLINT      NOT NULL,
    [columnType]         VARCHAR (100) NOT NULL,
    [dataType]           VARCHAR (100) NOT NULL,
    [propertyName]       VARCHAR (100) NOT NULL,
    [webControlName]     VARCHAR (100) NOT NULL,
    [webControlType]     VARCHAR (100) NOT NULL,
    [dontUpdateGoogle]   BIT           NOT NULL,
    [defaultValue]       VARCHAR (100) NOT NULL,
    [defaultValueType]   VARCHAR (100) NOT NULL,
    [dropDownSource]     VARCHAR (100) NOT NULL,
    [dropDownFilter]     VARCHAR (100) NOT NULL,
    [dropDownSourceType] VARCHAR (100) NOT NULL,
    [doNotLoad]          BIT           NOT NULL,
    [gridViewName]       VARCHAR (100) NOT NULL,
    [overrideValue]      BIT           NOT NULL);


GO

