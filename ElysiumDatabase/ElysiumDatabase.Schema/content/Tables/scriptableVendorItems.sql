CREATE TABLE [content].[scriptableVendorItems] (
    [scriptableVendorItemId]  INT            IDENTITY (1, 1) NOT NULL,
    [npcGlobalObject]         VARCHAR (255)  NOT NULL,
    [itemGlobalObject]        VARCHAR (255)  NOT NULL,
    [rarityId]                TINYINT        NOT NULL,
    [price_money_gold]        INT            NOT NULL,
    [price_money_silver]      TINYINT        NOT NULL,
    [price_money_copper]      TINYINT        NOT NULL,
    [price_token_adventuring] INT            NOT NULL,
    [price_token_crafting]    INT            NOT NULL,
    [price_token_gathering]   INT            NOT NULL,
    [tierAvailableId]         TINYINT        NOT NULL,
    [maxStock]                SMALLINT       NOT NULL,
    [restockAmt]              SMALLINT       NOT NULL,
    [spawnChance]             DECIMAL (5, 2) NOT NULL,
    [globalObjectName]        AS             ([dbo].[getGlobalObjectName]([npcGlobalObject])),
    [itemGlobalObjectName]    AS             ([dbo].[getGlobalObjectName]([itemGlobalObject])),
    [tierAvailable]           AS             ([dbo].[getGlobalTierName]([tierAvailableId])),
    [rarity]                  AS             ([dbo].[getRarityType]([rarityId])),
    CONSTRAINT [PK_scriptableVendorItems] PRIMARY KEY CLUSTERED ([scriptableVendorItemId] ASC),
    CONSTRAINT [FK_scriptableVendorItems_scriptableItemRarities] FOREIGN KEY ([itemGlobalObject], [rarityId]) REFERENCES [content].[scriptableItemRarities] ([globalObject], [rarityId]),
    CONSTRAINT [scriptableVendorItems_globalTiers_globalTierId_fk] FOREIGN KEY ([tierAvailableId]) REFERENCES [content].[globalTiers] ([typeId]),
    CONSTRAINT [scriptableVendorItems_scriptableVendors_globalObjectCode_fk] FOREIGN KEY ([npcGlobalObject]) REFERENCES [content].[scriptableVendors] ([globalObject])
);


GO

