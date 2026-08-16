CREATE TABLE [ops].[_configDetailsColumnsDataTables] (
    [tableName]             VARCHAR (100) NOT NULL,
    [columnName]            VARCHAR (100) NOT NULL,
    [columnType]            VARCHAR (100) NOT NULL,
    [dataType]              VARCHAR (100) NOT NULL,
    [propertyName]          VARCHAR (100) NOT NULL,
    [webControlName]        VARCHAR (100) NOT NULL,
    [webControlType]        VARCHAR (100) NOT NULL,
    [dontUpdateSql]         BIT           NOT NULL,
    [defaultValue]          VARCHAR (100) NOT NULL,
    [defaultValueType]      VARCHAR (100) NOT NULL,
    [dropDownSource]        VARCHAR (100) NOT NULL,
    [dropDownFilter]        VARCHAR (100) NOT NULL,
    [dropDownSourceType]    VARCHAR (100) NOT NULL,
    [doNotLoad]             BIT           NOT NULL,
    [overrideValue]         BIT           NOT NULL,
    [associatedColumnName]  VARCHAR (100) NOT NULL,
    [loadOrder]             TINYINT       NOT NULL,
    [childControlTableName] VARCHAR (100) NOT NULL,
    [childControlName]      VARCHAR (100) NOT NULL,
    [hideSetName]           BIT           NOT NULL,
    [skipDropDownSourceSet] BIT           NOT NULL,
    [typeLevelId]           TINYINT       NOT NULL,
    [associatedLabel]       VARCHAR (100) NOT NULL,
    [cssClass]              VARCHAR (255) NOT NULL,
    [width]                 SMALLINT      NOT NULL,
    [textAlign]             VARCHAR (50)  NOT NULL,
    [label]                 VARCHAR (255) NOT NULL,
    [gridViewName]          AS            ([dbo].[getGridViewNameFromConfig]([tableName])),
    [panelName]             AS            ([dbo].[getPanelNameFromConfig]([tableName])),
    [isEnum]                AS            ([dbo].[getIsEnumConfig]([dataType])),
    [typeLevel]             AS            ([dbo].[getTypeLevel]([typeLevelId])),
    [parentTableName]       AS            ([dbo].[getParentTableNameFromConfig]([tableName],[webControlName])),
    [parentControlName]     AS            ([dbo].[getParentControlNameFromConfig]([tableName],[webControlName])),
    CONSTRAINT [CHK_ValidConfigChildControlName] CHECK ([dbo].[IsValidConfigChildControlName]([childControlTableName],[childControlName])=(1)),
    CONSTRAINT [FK___configDe__webCo__5DEF70A8] FOREIGN KEY ([webControlName]) REFERENCES [ops].[_configNamesControls] ([controlName]),
    CONSTRAINT [ConstraintName] UNIQUE NONCLUSTERED ([tableName] ASC, [columnName] ASC)
);


GO

CREATE NONCLUSTERED INDEX [IX__configDetailsColumnsDataTables]
    ON [ops].[_configDetailsColumnsDataTables]([tableName] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_configDetailsColumnsDataTables_tableName_columnName_Unique]
    ON [ops].[_configDetailsColumnsDataTables]([tableName] ASC, [columnName] ASC) WHERE ([columnName]<>'None');


GO

