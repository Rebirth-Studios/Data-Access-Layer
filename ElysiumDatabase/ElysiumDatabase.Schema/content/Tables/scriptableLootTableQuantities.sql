CREATE TABLE [content].[scriptableLootTableQuantities] (
    [lootQuantityId]   INT            IDENTITY (1, 1) NOT NULL,
    [globalObject]     VARCHAR (255)  NOT NULL,
    [itemGlobalObject] VARCHAR (255)  NOT NULL,
    [quantity]         TINYINT        NOT NULL,
    [quantityChance]   DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_lootQuantity] PRIMARY KEY CLUSTERED ([lootQuantityId] ASC),
    CONSTRAINT [FK_scriptableLootTableQuantities_scriptableItems] FOREIGN KEY ([itemGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [scriptableLootTableQuantities_scriptableLootTables_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableLootTables] ([globalObject]),
    CONSTRAINT [scriptableLootTableQuantities_globalObject_itemGlobalObject] UNIQUE NONCLUSTERED ([globalObject] ASC, [itemGlobalObject] ASC, [quantity] ASC)
);


GO

