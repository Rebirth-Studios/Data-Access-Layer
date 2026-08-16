CREATE TABLE [ops].[_configTypesToTableNames] (
    [id]           TINYINT       IDENTITY (1, 1) NOT NULL,
    [typeName]     VARCHAR (100) NOT NULL,
    [sqlTableName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK__configTypesToSheetNames] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

