CREATE TABLE [ops].[_configDetailsTablesData] (
    [tableName]              VARCHAR (100) NOT NULL,
    [tableTypeName]          VARCHAR (100) NOT NULL,
    [updateType]             VARCHAR (100) NOT NULL,
    [globalObjectColumn]     VARCHAR (100) NOT NULL,
    [globalObjectNameColumn] VARCHAR (100) NOT NULL,
    [objectNameColumn]       VARCHAR (100) NOT NULL,
    [pathColumn]             VARCHAR (100) NOT NULL,
    [typeColumn]             VARCHAR (100) NOT NULL,
    [panelName]              VARCHAR (100) NOT NULL,
    [gridViewName]           VARCHAR (100) NOT NULL,
    [dataRowId]              VARCHAR (100) NOT NULL,
    [sortGroupType]          VARCHAR (100) NOT NULL,
    [sortColumnName1]        VARCHAR (100) NOT NULL,
    [sortColumnName2]        VARCHAR (100) NOT NULL,
    [sortColumnName3]        VARCHAR (100) NOT NULL,
    [searchKeyColumn]        VARCHAR (100) NOT NULL,
    [listViewPanelName]      VARCHAR (100) NOT NULL,
    [listViewName]           VARCHAR (100) NOT NULL,
    [listViewRow]            VARCHAR (100) NOT NULL,
    [sqlUpdatePriority]      TINYINT       NOT NULL,
    [storedProcedure]        VARCHAR (100) NOT NULL,
    [title]                  VARCHAR (100) NOT NULL,
    [cssClass]               VARCHAR (255) NOT NULL
);


GO

