CREATE TABLE [ops].[_configNamesDataTables] (
    [dataTableId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [dataTable]     VARCHAR (100) NOT NULL,
    [dataTableName] VARCHAR (100) NOT NULL,
    [description]   VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configNamesDataTables] PRIMARY KEY CLUSTERED ([dataTableId] ASC),
    UNIQUE NONCLUSTERED ([dataTable] ASC),
    UNIQUE NONCLUSTERED ([dataTable] ASC)
);


GO

