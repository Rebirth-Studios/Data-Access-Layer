CREATE TABLE [runtime].[spawnedMonsters] (
    [lastUpdate]           DATETIME         NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [spawnedMonsters_pk] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [spawnedMonsters_spawnedEntities_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedEntities] ([spawnedWorldObjectId])
);


GO

