CREATE TABLE [content].[scriptableLootTableRarities] (
    [lootRarityId]     INT            IDENTITY (1, 1) NOT NULL,
    [globalObject]     VARCHAR (255)  NOT NULL,
    [itemGlobalObject] VARCHAR (255)  NOT NULL,
    [dropGlobalObject] VARCHAR (255)  NOT NULL,
    [rarityId]         TINYINT        NOT NULL,
    [rarityChance]     DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_lootRarities] PRIMARY KEY CLUSTERED ([lootRarityId] ASC),
    CONSTRAINT [FK_scriptableLootTableRarities_scriptableItemRarities] FOREIGN KEY ([itemGlobalObject], [rarityId]) REFERENCES [content].[scriptableItemRarities] ([globalObject], [rarityId]),
    CONSTRAINT [FK_scriptableLootTableRarities_scriptableItems1] FOREIGN KEY ([dropGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [scriptableLootTableRarities_scriptableLootTables_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableLootTables] ([globalObject]),
    CONSTRAINT [scriptableLootTableRarities_globalObject_itemGlobalObject_rarityId] UNIQUE NONCLUSTERED ([globalObject] ASC, [itemGlobalObject] ASC, [rarityId] ASC)
);


GO

