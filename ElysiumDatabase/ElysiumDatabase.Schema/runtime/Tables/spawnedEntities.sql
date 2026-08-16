CREATE TABLE [runtime].[spawnedEntities] (
    [spawnedWorldObjectId] UNIQUEIDENTIFIER NOT NULL,
    [entityTypeId]         TINYINT          NOT NULL,
    [lastUpdate]           DATETIME         NOT NULL,
    CONSTRAINT [spawnedEntities_pk] PRIMARY KEY CLUSTERED ([spawnedWorldObjectId] ASC),
    CONSTRAINT [spawnedEntities_spawnedWorldObjects_spawnedWorldObjectId_fk] FOREIGN KEY ([spawnedWorldObjectId]) REFERENCES [runtime].[spawnedWorldObjects] ([spawnedWorldObjectId])
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [spawnedEntities_spawnedWorldObjectId_uindex]
    ON [runtime].[spawnedEntities]([spawnedWorldObjectId] ASC);


GO

