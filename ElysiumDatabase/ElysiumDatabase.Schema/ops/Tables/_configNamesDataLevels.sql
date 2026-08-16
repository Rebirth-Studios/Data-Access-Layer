CREATE TABLE [ops].[_configNamesDataLevels] (
    [dataLevelId]   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [dataLevelName] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK__configNamesDataLevels] PRIMARY KEY CLUSTERED ([dataLevelId] ASC),
    UNIQUE NONCLUSTERED ([dataLevelName] ASC)
);


GO

