CREATE TABLE [ops].[_configNamesColumnTypes] (
    [columnTypeId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [columnTypeName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK__configNamesColumnTypes] PRIMARY KEY CLUSTERED ([columnTypeId] ASC),
    UNIQUE NONCLUSTERED ([columnTypeName] ASC)
);


GO

