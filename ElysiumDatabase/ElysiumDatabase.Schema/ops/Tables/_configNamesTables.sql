CREATE TABLE [ops].[_configNamesTables] (
    [id]        SMALLINT      IDENTITY (1, 1) NOT NULL,
    [tableName] VARCHAR (100) NOT NULL,
    [tableType] VARCHAR (50)  NULL,
    CONSTRAINT [PK__configNamesSheets] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [UQ___configN__06EA5CF41999A7F4] UNIQUE NONCLUSTERED ([tableName] ASC)
);


GO

