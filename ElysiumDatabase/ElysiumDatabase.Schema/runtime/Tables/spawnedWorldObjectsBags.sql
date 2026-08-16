CREATE TABLE [runtime].[spawnedWorldObjectsBags] (
    [characterBagId]       INT              IDENTITY (1, 1) NOT NULL,
    [instancedItemId]      UNIQUEIDENTIFIER NULL,
    [bagLocationId]        TINYINT          NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    [lastUpdate]           DATETIME         NOT NULL,
    CONSTRAINT [charactersBags_primaryKey] PRIMARY KEY CLUSTERED ([characterBagId] ASC),
    CONSTRAINT [FK_charactersBags_instancedItems] FOREIGN KEY ([instancedItemId]) REFERENCES [runtime].[instancedItems] ([instancedItemId]),
    CONSTRAINT [spawnedWorldObjectsBags_spawnedWorldObjects_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedWorldObjects] ([spawnedWorldObjectId])
);


GO

