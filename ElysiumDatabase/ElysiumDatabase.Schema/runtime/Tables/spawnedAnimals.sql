CREATE TABLE [runtime].[spawnedAnimals] (
    [lastUpdate]           DATETIME         NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [spawnedAnimals_pk] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [spawnedAnimals_spawnedEntities_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedEntities] ([spawnedWorldObjectId])
);


GO

