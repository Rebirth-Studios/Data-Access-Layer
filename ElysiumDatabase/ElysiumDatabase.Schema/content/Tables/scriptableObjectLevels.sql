CREATE TABLE [content].[scriptableObjectLevels] (
    [id]                        SMALLINT      IDENTITY (0, 1) NOT NULL,
    [globalObject]              VARCHAR (255) NOT NULL,
    [levelId]                   TINYINT       NOT NULL,
    [scriptableObjectLevel]     VARCHAR (255) NOT NULL,
    [scriptableObjectLevelName] VARCHAR (255) NOT NULL,
    CONSTRAINT [scriptableObjectLevels_pk] PRIMARY KEY CLUSTERED ([globalObject] ASC, [levelId] ASC),
    CONSTRAINT [scriptableObjectsLevel_scriptableObjects_globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [UQ__scriptab__5F32B1B3CD37A823] UNIQUE NONCLUSTERED ([scriptableObjectLevel] ASC)
);


GO

CREATE STATISTICS [_dta_stat_797177881_4_3]
    ON [content].[scriptableObjectLevels]([scriptableObjectLevel], [levelId]);


GO

