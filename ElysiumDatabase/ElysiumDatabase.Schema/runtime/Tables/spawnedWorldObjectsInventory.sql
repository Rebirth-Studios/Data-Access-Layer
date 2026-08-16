CREATE TABLE [runtime].[spawnedWorldObjectsInventory] (
    [characterInventoryId] INT              IDENTITY (1, 1) NOT NULL,
    [instancedItemId]      UNIQUEIDENTIFIER NULL,
    [characterBagId]       INT              NOT NULL,
    [locationInsideBag]    TINYINT          NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    [lastUpdate]           DATETIME         NOT NULL,
    CONSTRAINT [FK_charactersInventory_charactersBags] FOREIGN KEY ([characterBagId]) REFERENCES [runtime].[spawnedWorldObjectsBags] ([characterBagId]),
    CONSTRAINT [FK_charactersInventory_spawnedWorldObjects] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedWorldObjects] ([spawnedWorldObjectId]),
    CONSTRAINT [FK_spawnedWorldObjectsInventory_instancedItems] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId]),
    CONSTRAINT [spawnedWorldObjectsInventory_UQ_2] UNIQUE NONCLUSTERED ([characterBagId] ASC, [locationInsideBag] ASC)
);


GO

