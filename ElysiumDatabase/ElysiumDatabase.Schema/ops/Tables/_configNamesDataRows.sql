CREATE TABLE [ops].[_configNamesDataRows] (
    [dataRowId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [dataRow]     VARCHAR (100) NOT NULL,
    [dataRowName] VARCHAR (100) NOT NULL,
    [description] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configNamesDataRows] PRIMARY KEY CLUSTERED ([dataRowId] ASC),
    UNIQUE NONCLUSTERED ([dataRow] ASC)
);


GO

