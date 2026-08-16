CREATE TABLE [content].[scriptableSpawnTables] (
    [respawnTime]                     INT           NOT NULL,
    [globalObject]                    VARCHAR (255) NOT NULL,
    [baseSpawnableObjectGlobalObject] VARCHAR (255) NOT NULL,
    [globalObjectName]                AS            ([dbo].[getGlobalObjectName]([globalObject])),
    [baseSpawnableObjectName]         AS            ([dbo].[getGlobalObjectName]([baseSpawnableObjectGlobalObject])),
    PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [scriptableSpawnTables_scriptableObjects_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableSpawnTables_scriptableWorldObjects_globalObject_fk] FOREIGN KEY ([baseSpawnableObjectGlobalObject]) REFERENCES [content].[scriptableWorldObjects] ([globalObject]),
    UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

