CREATE TABLE [content].[spawnablesToLootTables] (
    [id]                          INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]                VARCHAR (255) NOT NULL,
    [scriptableObjectSpawnable]   VARCHAR (255) NOT NULL,
    [allowedRolls]                TINYINT       NOT NULL,
    [minCurrencyReward]           INT           NOT NULL,
    [maxCurrencyReward]           INT           NOT NULL,
    [lootTableGlobalObject]       VARCHAR (255) NOT NULL,
    [additionalQuantityInherited] TINYINT       NOT NULL,
    [additionalRarityInherited]   TINYINT       NOT NULL,
    CONSTRAINT [PK_worldObjectsToLootTables] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK__spawnable__scrip__76BB1E72] FOREIGN KEY ([scriptableObjectSpawnable]) REFERENCES [content].[scriptableObjectSpawnables] ([scriptableObjectSpawnable]),
    CONSTRAINT [worldObjectsRanksToLootTables_scriptableLootTables_globalObject_fk] FOREIGN KEY ([lootTableGlobalObject]) REFERENCES [content].[scriptableLootTables] ([globalObject]),
    CONSTRAINT [worldObjectsRanksToLootTables_scriptableWorldObjects_globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableWorldObjects] ([globalObject]),
    CONSTRAINT [UQ__spawnabl__6ADA9D13A10915E9] UNIQUE NONCLUSTERED ([scriptableObjectSpawnable] ASC)
);


GO

