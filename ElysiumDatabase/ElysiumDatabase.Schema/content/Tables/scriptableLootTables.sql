CREATE TABLE [content].[scriptableLootTables] (
    [globalObject]                  VARCHAR (255) NOT NULL,
    [lootTableTypeId]               TINYINT       NOT NULL,
    [lootTableClassificationTypeId] TINYINT       NOT NULL,
    CONSTRAINT [PK__scriptab__5AB532D5203C7A69] PRIMARY KEY NONCLUSTERED ([globalObject] ASC),
    CONSTRAINT [FK_scriptableLootTables_scriptableObjects] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableObjects] ([globalObject]),
    CONSTRAINT [scriptableLootTables_lootTableSubTypes_lootTableSubTypeId_fk] FOREIGN KEY ([lootTableClassificationTypeId]) REFERENCES [content].[lootTableClassificationTypes] ([typeId]),
    CONSTRAINT [scriptableLootTables_lootTableTypes_lootTableTypeId_fk] FOREIGN KEY ([lootTableTypeId]) REFERENCES [content].[lootTableTypes] ([typeId]),
    CONSTRAINT [UQ__scriptab__5AB532D5CD1DC788] UNIQUE NONCLUSTERED ([globalObject] ASC)
);


GO

EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'THIS IS ACTUALLY SUBTYPE, not main type.', @level0type = N'SCHEMA', @level0name = N'content', @level1type = N'TABLE', @level1name = N'scriptableLootTables', @level2type = N'COLUMN', @level2name = N'lootTableClassificationTypeId';


GO

