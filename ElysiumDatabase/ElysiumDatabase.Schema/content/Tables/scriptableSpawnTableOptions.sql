CREATE TABLE [content].[scriptableSpawnTableOptions] (
    [globalObject]              VARCHAR (255)  NOT NULL,
    [worldObjectGlobalObject]   AS             ([dbo].[getGlobalObjectFromScriptableObjectSpawnable]([scriptableObjectSpawnable])),
    [scriptableObjectSpawnable] VARCHAR (255)  NOT NULL,
    [minRange]                  INT            NOT NULL,
    [maxRange]                  INT            NOT NULL,
    [prefabSizeMin]             DECIMAL (7, 2) NOT NULL,
    [prefabSizeMax]             DECIMAL (7, 2) NOT NULL,
    [prefabName]                VARCHAR (255)  NOT NULL,
    [levelId]                   TINYINT        NOT NULL,
    [variationId]               TINYINT        NOT NULL,
    CONSTRAINT [FK__scriptabl__scrip__1BF39766] FOREIGN KEY ([scriptableObjectSpawnable]) REFERENCES [content].[scriptableObjectSpawnables] ([scriptableObjectSpawnable]),
    CONSTRAINT [scriptableSpawnTableOptions_scriptableSpawnTables_globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableSpawnTables] ([globalObject])
);


GO

