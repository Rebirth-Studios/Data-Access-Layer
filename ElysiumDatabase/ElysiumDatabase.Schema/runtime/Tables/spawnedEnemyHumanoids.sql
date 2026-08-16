CREATE TABLE [runtime].[spawnedEnemyHumanoids] (
    [lastUpdate]           DATETIME         NOT NULL,
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [spawnedEnemyHumanoids_pk] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [spawnedEnemyHumanoids_spawnedEntities_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedEntities] ([spawnedWorldObjectId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [spawnedEnemyHumanoids_spawnedWorldObjectId_uindex]
    ON [runtime].[spawnedEnemyHumanoids]([spawnedWorldObjectId] ASC);


GO

