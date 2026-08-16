CREATE TABLE [content].[scriptableLootTableDrops] (
    [scriptableLootTableDropsId] INT            IDENTITY (1, 1) NOT NULL,
    [globalObject]               VARCHAR (255)  NOT NULL,
    [itemGlobalObject]           VARCHAR (255)  NOT NULL,
    [recipeGlobalObject]         VARCHAR (255)  NOT NULL,
    [qualityId]                  TINYINT        NOT NULL,
    [dropChance]                 DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_scriptableLootTables] PRIMARY KEY CLUSTERED ([scriptableLootTableDropsId] ASC),
    CONSTRAINT [FK_scriptableLootTableDrops_scriptableItems] FOREIGN KEY ([itemGlobalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [scriptableLootTableDrops_scriptableLootTables_globalObjectCode_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableLootTables] ([globalObject]),
    CONSTRAINT [scriptableLootTableDrops_scriptableQualities_scriptableQualityId_fk] FOREIGN KEY ([qualityId]) REFERENCES [content].[scriptableQualities] ([typeId]),
    CONSTRAINT [scriptableLootTableDrops_scriptableRecipes_globalObject_fk] FOREIGN KEY ([recipeGlobalObject]) REFERENCES [content].[scriptableRecipes] ([globalObject]),
    CONSTRAINT [scriptableLootTableDrops_globalObject_itemGlobalObject] UNIQUE NONCLUSTERED ([globalObject] ASC, [itemGlobalObject] ASC)
);


GO

