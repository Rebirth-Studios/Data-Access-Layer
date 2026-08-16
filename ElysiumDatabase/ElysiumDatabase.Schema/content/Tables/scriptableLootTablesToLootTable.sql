CREATE TABLE [content].[scriptableLootTablesToLootTable] (
    [scriptableLootTablesToLootTableId] INT           IDENTITY (1, 1) NOT NULL,
    [globalObject]                      VARCHAR (255) NOT NULL,
    [inheritedLootTableGlobalObject]    VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_scriptableLootTablesToLootTable] PRIMARY KEY CLUSTERED ([scriptableLootTablesToLootTableId] ASC),
    CONSTRAINT [scriptableLootTablesToLootTable_scriptableLootTables_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableLootTables] ([globalObject]),
    CONSTRAINT [scriptableLootTablesToLootTable_scriptableLootTables_globalObjectCode_fk_2] FOREIGN KEY ([inheritedLootTableGlobalObject]) REFERENCES [content].[scriptableLootTables] ([globalObject]),
    CONSTRAINT [UC_GlobalObjectInheritedLootTableGlobalObject] UNIQUE NONCLUSTERED ([globalObject] ASC, [inheritedLootTableGlobalObject] ASC)
);


GO

