CREATE TABLE [runtime].[spawnedVendorInventory] (
    [spawnedVendorInventoryId] INT              IDENTITY (1, 1) NOT NULL,
    [rarityId]                 TINYINT          NOT NULL,
    [currentStock]             TINYINT          NOT NULL,
    [spawnedWorldObjectId]     UNIQUEIDENTIFIER NULL,
    [lastUpdate]               DATETIME         NOT NULL,
    [globalObject]             VARCHAR (255)    NOT NULL,
    CONSTRAINT [PK_spawnedVendorInventory] PRIMARY KEY CLUSTERED ([spawnedVendorInventoryId] ASC),
    CONSTRAINT [spawnedVendorInventory_scriptableItems_globalObject_fk] FOREIGN KEY ([globalObject]) REFERENCES [content].[scriptableItems] ([globalObject]),
    CONSTRAINT [spawnedVendorInventory_scriptableRarities_scriptableRarityId_fk] FOREIGN KEY ([rarityId]) REFERENCES [content].[scriptableRarities] ([typeId])
);


GO

