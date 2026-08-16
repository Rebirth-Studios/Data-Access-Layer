CREATE TABLE [ops].[_configDetailsDefaultOverrides] (
    [gameObjectType]           AS            ([dbo].[getGameObjectType]([gameObjectTypeId])),
    [tableName]                VARCHAR (100) NOT NULL,
    [columnName]               VARCHAR (100) NOT NULL,
    [defaultValue]             VARCHAR (100) NOT NULL,
    [defaultValueType]         VARCHAR (100) NOT NULL,
    [defaultMethod]            VARCHAR (100) NOT NULL,
    [rowNumber]                TINYINT       NOT NULL,
    [advancedDefaultValue]     VARCHAR (100) NOT NULL,
    [suppressOnLoad]           BIT           NOT NULL,
    [suppressOnSetName]        BIT           NOT NULL,
    [propertyGameObjectType]   AS            ([dbo].[getGameObjectType]([propertyGameObjectTypeId])),
    [propertyGameObjectTypeId] TINYINT       NOT NULL,
    [gameObjectTypeId]         TINYINT       NOT NULL,
    [gridViewName]             AS            ([dbo].[getGridViewNameFromConfig]([tableName]))
);


GO

