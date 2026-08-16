CREATE TABLE [ops].[_configNamesDefaultValues] (
    [defaultValueId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [defaultValueName] VARCHAR (100) NOT NULL,
    [defaultValueType] VARCHAR (100) NOT NULL,
    [description]      VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configNamesDefaultValues] PRIMARY KEY CLUSTERED ([defaultValueId] ASC),
    UNIQUE NONCLUSTERED ([defaultValueName] ASC)
);


GO

